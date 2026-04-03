using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Domain.Models;

namespace Cliente.Application.Model
{
    public class CreateItemPedidoInputModel
    {
        [Required]
        public int ProdutoId { get; private set; }
        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }

        public ItemPedido ToEntityItemPedido()
            => new ItemPedido(ProdutoId, Quantidade,ValorUnitario,Produto);

    }
}

