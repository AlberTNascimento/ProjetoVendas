using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWebMvc.Models
{
    public class Seller
    {

        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Birth Day")] // Usado para mudar os labels dos atributos
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }
        // Fazendo associação das entidades Seller e Department - lado UM
        public Department Department { get; set; }
        // Garantindo a integridade referencial - Foreign key not null (referential integrity)
        public int DepartmentId { get; set; }
        // Fazendo associação das entidades Seller e SalesRecord - lado MUITOS e depois instanciando uma lista
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void addSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void removeSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double totalSales(DateTime inicial, DateTime final)
        {
            return Sales.Where(sr => sr.Date > inicial && sr.Date <= final).Sum(sr => sr.Amount);
        }

    }
}
