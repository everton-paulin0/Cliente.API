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
        public ItemPedidoViewModel(string produto, int quantidade, decimal valorUnitario, decimal total)
        {
            Produto = produto;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            Total = total;
        }

        public string Produto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public decimal Total { get; private set; }

        public static ItemPedidoViewModel ItemPedidoFromEntity(ItemPedido entity)
            => new ItemPedidoViewModel(
                entity.Produto.NomeProduto,
                entity.Quantidade,
                entity.ValorUnitario,
                entity.Total()
            );
    }
}


