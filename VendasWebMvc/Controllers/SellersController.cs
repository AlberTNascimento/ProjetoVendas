using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMvc.Services;
using VendasWebMvc.Models;

namespace VendasWebMvc.Controllers
{
    public class SellersController : Controller
    {
        // Declarando dependência para o SellerService
        private readonly SellerService _sellerService;
        // Criando o construtor do sellerscontroller recebendo o sellerservice
        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
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
            // Chama a View chamada Create
            return View();
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
