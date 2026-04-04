using Cliente.Domain.Models;

namespace Cliente.Application.Model
{
    public class PedidoItemViewModel
    {
        public PedidoItemViewModel(int produtoId, string nomeProduto, int quantidade, decimal valorUnitario)
        {
            ProdutoId = produtoId;
            NomeProduto = nomeProduto;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }

        // ✅ MÉTODO QUE ESTAVA FALTANDO
        public static PedidoItemViewModel ItemPedidoFromEntity(ItemPedido item)
        {
            return new PedidoItemViewModel(
                item.ProdutoId,
                item.Produto.NomeProduto,
                item.Quantidade,
                item.ValorUnitario
            );
        }
    }
}


