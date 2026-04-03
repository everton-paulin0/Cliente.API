using Cliente.Domain.Entities;
using Cliente.Domain.Models.Enum;

namespace Cliente.Domain.Models
{
    public class Pedido : BaseEntities
    {
        public Pedido(int clientId, int vendedorId, Status statusVenda)
        {
            if (clientId <= 0)
                throw new Exception("Cliente inválido");

            if (vendedorId <= 0)
                throw new Exception("Vendedor inválido");

            ClientId = clientId;
            VendedorId = vendedorId;
            StatusVenda = statusVenda;

            Itens = new List<PedidoItem>();
        }
        public int ClientId { get; set; }
        public Client Cliente { get; set; } = null!;

        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; } = null!;

        public Status StatusVenda { get; set; }

        public List<PedidoItem> Itens { get; private set; } = new();

        // ✅ UPDATE
        public void UpdatePedido(int clientId, int vendedorId, Status statusVenda)
        {
            if (clientId <= 0)
                throw new Exception("Cliente inválido");

            if (vendedorId <= 0)
                throw new Exception("Vendedor inválido");

            ClientId = clientId;
            VendedorId = vendedorId;
            StatusVenda = statusVenda;

            UpdatedAt = DateTime.UtcNow;
        }

        // ✅ LIMPAR ITENS (resolve erro do Clear)
        public void LimparItens()
        {
            foreach (var item in Itens)
            {
                item.Produto.Quantidade += item.Quantidade;
            }

            Itens.Clear();
        }

        // ✅ ADICIONAR PRODUTO
        public void AdicionarProduto(Produto produto, int quantidade)
        {
            if (produto == null)
                throw new Exception("Produto inválido");

            if (quantidade <= 0)
                throw new Exception("Quantidade inválida");

            produto.BaixarEstoque(quantidade);

            var item = Itens.FirstOrDefault(i => i.ProdutoId == produto.Id);

            if (item != null)
            {
                item.Quantidade += quantidade;
            }
            else
            {
                Itens.Add(new PedidoItem
                {
                    ProdutoId = produto.Id,
                    Produto = produto,
                    Quantidade = quantidade,
                    ValorUnitario = produto.ValorUnitario
                });
            }
        }

        public decimal GetTotal()
            => Itens.Sum(i => i.Total);
    }

}

