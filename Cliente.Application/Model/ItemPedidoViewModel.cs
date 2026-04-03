using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Domain.Models;

namespace Cliente.Application.Model
{
    public class ItemPedidoViewModel
    {
        public ItemPedidoViewModel(int produtoId, Produto produto, int quantidade, decimal valorUnitario)
        {
            ProdutoId = produtoId;
            Produto = produto;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public int ProdutoId { get; private set; }
        Produto Produto { get; set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }

        public static ItemPedidoViewModel ItemPedidoFromEntity(ItemPedido entity)
           => new ItemPedidoViewModel(entity.ProdutoId, entity.Produto, entity.Quantidade, entity.ValorUnitario);

    }
}
