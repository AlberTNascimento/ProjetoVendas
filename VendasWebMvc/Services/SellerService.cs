using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Data;
using VendasWebMvc.Models;

namespace VendasWebMvc.Services
{
    public class SellerService
    {

        // Criando uma dependência para a classe SellerWebMvcContext.cs
        private readonly VendasWebMvcContext _context;

        // Criando um construtor para a injeção de dependência
        public SellerService(VendasWebMvcContext context)
        {
            _context = context;
        }

        // Implementando o FindAll tetornando uma lista com todos os vendedores
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        // Implementando um método para inserir novo vendedor no BD
        public void Insert(Seller obj)
        {
            // Inserindo o objeto
            _context.Add(obj);
            // ;salvando o  objeto
            _context.SaveChanges();
        }

    }
}
