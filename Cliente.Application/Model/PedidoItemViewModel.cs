


namespace Cliente.Application.Model
{
    public class PedidoItemViewModel
    {
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }

        public static PedidoItemViewModel PedidoFromEntity(ItemPedido item)
        {
            return new PedidoItemViewModel
            {
                ProdutoId = item.ProdutoId,
                NomeProduto = item.Produto.NomeProduto,
                Quantidade = item.Quantidade,
                ValorUnitario = item.ValorUnitario
            };
        }
    }
}


