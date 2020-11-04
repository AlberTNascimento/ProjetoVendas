using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMvc.Services;
using VendasWebMvc.Models;
using VendasWebMvc.Models.ViewModels;
using VendasWebMvc.Services.Exceptions;
using System.Data;

namespace VendasWebMvc.Controllers
{
    public class SellersController : Controller
    {
        // Declarando dependência para o SellerService
        private readonly SellerService _sellerService;
        // Declarando dependência para o DepartmentService
        private readonly DepartmentService _departmentService;

        // Criando o construtor do sellerscontroller recebendo o sellerservice + acrescentar DepartmentService ao construtor
        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            // Implementando a chamada da operação FindAll
            var list = _sellerService.FindAll();
            // Passando a list que retorna como argumento para o return da View
            return View(list);
        }

        // Criando a ação create
        public IActionResult Create()
        {
            // Carregando os departments
            var departments = _departmentService.FindAll();
            // Instanciar o objeto ViewModel
            var viewModel = new SellerFormViewModel { Departments = departments };
            // Chama a View chamada Create + passar viewModel para dentro da view
            return View(viewModel);
        }

        // Criando a ação POST para gravar no BD
        // Para indicar que o método abaixo é um POST devemos:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        // Criando uma ação para apresentação da confirmação do vendedor
        public IActionResult Delete(int? id)
        {
            // Verificando se a consulta retornou nula - CASO SIM
            if (id == null)
            {
                return NotFound();
            }
            // Pegar objeto caso retorno diferente de nulo
            var obj = _sellerService.FindById(id.Value);
            // Verificar se o objeto é nulo
            if (obj == null)
            {
                return NotFound();
            }
            // Caso retorno seja encontrado corretamente
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var obj = _sellerService.FindById(id.Value);

            if ( obj == null )
            {
                return NotFound();
            }

            List<Department> departments = _departmentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (id != seller.Id)
            {
                return BadRequest();
            }
            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }

    }
}
