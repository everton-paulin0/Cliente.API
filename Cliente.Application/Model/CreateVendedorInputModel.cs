using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Domain.Models;
using Cliente.Domain.Models.Enum;

namespace Cliente.Application.Model
{
    public class CreateVendedorInputModel
    {
        [Required]
        public string NomeVendedor { get; set; }
        public NumeroVendedor Numero { get; set; }

        public Vendedor ToEntityVendedor()
                    => new Vendedor(NomeVendedor, Numero);
    }
}
