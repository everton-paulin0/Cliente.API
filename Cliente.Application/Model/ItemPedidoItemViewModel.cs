using Cliente.Domain.Models;

namespace Cliente.Application.Model
{
    public class ItemPedidoItemViewModel

    {
        public ItemPedidoItemViewModel(int produtoId, Produto produto, int quantidade, decimal valorUnitario)
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

        public static ItemPedidoItemViewModel ItemPedidoFromEntity(ItemPedido itemPedido)
           => new ItemPedidoItemViewModel(itemPedido.ProdutoId, itemPedido.Produto, itemPedido.Quantidade, itemPedido.ValorUnitario);
    };

}
    


