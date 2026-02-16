using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Domain.Models;

namespace Cliente.Application.Model
{
    public class VendedorViewModel
    {
        public VendedorViewModel(int id, string nomeVendedor)
        {
            Id = id;
            NomeVendedor = nomeVendedor;
            
        }

        public int Id { get; set; }
        public string NomeVendedor { get; set; }
        

        public static VendedorViewModel FromEntityVendedor(Vendedor entity)
             => new(entity.Id, entity.NomeVendedor);
    }
}
