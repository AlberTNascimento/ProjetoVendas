using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMvc.Services;

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



    }
}
