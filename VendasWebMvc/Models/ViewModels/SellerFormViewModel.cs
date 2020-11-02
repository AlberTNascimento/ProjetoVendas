
using System.Collections.Generic;

namespace VendasWebMvc.Models.ViewModels
{
    public class SellerFormViewModel
    {
        // Propriedades da classe: um vendedor e uma lista de departamentos
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
