using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Application.Model
{
    public class UpdateItemPedidoInputModel
    {
        public int IdItemPedido { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
