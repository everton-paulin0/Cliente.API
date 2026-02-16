using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Domain.Models;
using Cliente.Domain.Models.Enum;

namespace Cliente.Application.Model
{
    public class VendedorItemViewModel
    {
        public VendedorItemViewModel(int id, string nomeVendedor)
        {
            Id = id;
            NomeVendedor = nomeVendedor;
            
        }

        public int Id { get; set; }
        public string NomeVendedor { get; set; }        
        

        public static VendedorItemViewModel FromEntityVendedor(Vendedor vendedor)
           => new VendedorItemViewModel(vendedor.Id, vendedor.NomeVendedor);
    }
}
