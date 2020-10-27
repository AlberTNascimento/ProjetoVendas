using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace VendasWebMvc.Models
{
    public class Department
    {

        public int Id { get; set; }
        public string Name { get; set; }
        // Fazendo associação das entidades Department e Seller - lado MUITOS e depois instanciando uma lista
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime inicial, DateTime final)
        {
            return Sellers.Sum(seller => seller.totalSales(inicial, final));
        }

    }
}
