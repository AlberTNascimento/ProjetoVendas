using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMvc.Services;
using VendasWebMvc.Models;
using VendasWebMvc.Models.ViewModels;

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

    }
}
