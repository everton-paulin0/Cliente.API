using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Domain.Models;

namespace Cliente.Domain.Entities
{
    public class PedidoItem : BaseEntities
    {
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; } = null!;
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; } = null!;
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Total => Quantidade * ValorUnitario;
    }
}
