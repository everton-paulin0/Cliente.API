using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Domain.Models.Enum;

namespace Cliente.Application.Model
{
    public class UpdateVendedorInputModel
    {
        public int IdVendedor { get; set; }
        public string NomeVendedor { get; set; }
        public NumeroVendedor Numero { get; set; }
    }
}
