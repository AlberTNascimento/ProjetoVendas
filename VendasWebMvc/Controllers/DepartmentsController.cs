using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMvc.Models;

namespace VendasWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            // Criando uma lista de departamentos
            List<Department> list = new List<Department>();
            // Preenchendo a lista
            list.Add(new Department { Id = 1, Name = "Eletronics" });
            list.Add(new Department { Id = 2, Name = "Fashioon" });

            return View(list); // Para enviar a lista do controlller para a view
        }
    }
}
