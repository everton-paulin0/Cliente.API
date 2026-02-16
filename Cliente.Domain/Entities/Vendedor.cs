using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Domain.Models.Enum;

namespace Cliente.Domain.Models
{
    public class Vendedor : BaseEntities
    {
        public Vendedor(string nomeVendedor) : base()
        {
            NomeVendedor = nomeVendedor;
            
        }
        [Description("Nome do Vendedor")]
        public string NomeVendedor { get; set; }
        [Description("Numero do Vendedor")]
        

        public List<Pedido> Pedidos { get; set; }

        public decimal CalcularComissao(decimal totalVendas)
        {
            decimal percentual = 0.05m; // 5% de comissão padrão
            return totalVendas * percentual;
        }

        public void UpdateVendedor(string nomeVendedor)
        {
            NomeVendedor = nomeVendedor;           
            UpdatedAt = DateTime.Now;
        }
    }
}
