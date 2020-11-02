using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Data;
using VendasWebMvc.Models;

namespace VendasWebMvc.Services
{
    public class DepartmentService
    {
        // Criando uma dependência para a classe DepartmentWebMvcContext.cs
        private readonly VendasWebMvcContext _context;
        // Criando um construtor para a injeção de dependência
        public DepartmentService (VendasWebMvcContext context)
        {
            _context = context;
        }

        // Criando um método para retornar todos os departments
        public List<Department> FindAll()
        {
            // Retornando os departments por ordem alfabética
            return _context.Department.OrderBy(x => x.Name).ToList();
        }

    }
}
