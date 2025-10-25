using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Domain.Models.Enum;

namespace Cliente.Domain.Models
{
    public class Vendedor : BaseEntities
    {
        public Vendedor(string nomeVendedor, NumeroVendedor numero)
        {
            NomeVendedor = nomeVendedor;
            Numero = numero;
        }

        public string NomeVendedor { get; set; }
        public NumeroVendedor Numero { get; set; }

        public decimal CalcularComissao(decimal totalVendas)
        {
            decimal percentual = 0.05m; // 5% de comissão padrão
            return totalVendas * percentual;
        }
    }
}
