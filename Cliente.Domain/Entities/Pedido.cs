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

            Itens = new List<ItemPedido>();
        }
        public int ClientId { get; set; }
        public Client Cliente { get; set; } = null!;

        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; } = null!;

        public Status StatusVenda { get; set; }

        public List<ItemPedido> Itens { get; private set; } = new();

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

            if (produto.Quantidade < quantidade)
                throw new Exception("Estoque insuficiente");

            var item = Itens.FirstOrDefault(i => i.ProdutoId == produto.Id);

            if (item != null)
            {
                item.AdicionarQuantidade(quantidade);
            }
            else
            {
                Itens.Add(new ItemPedido(
                    produto.Id,
                    quantidade,
                    produto.ValorUnitario
                ));
            }

            // 🔥 MOVER PRA CÁ
            produto.BaixarEstoque(quantidade);
        }

        public decimal GetTotal()
            => Itens.Sum(i => i.Total());

        public void RemoverItem(int produtoId)
        {
            var item = Itens.FirstOrDefault(i => i.ProdutoId == produtoId);

            if (item == null)
                throw new Exception($"Produto {produtoId} não existe no pedido");

            if (item.Produto == null)
                throw new Exception("Produto não carregado");

            // devolve estoque
            item.Produto.Quantidade += item.Quantidade;

            Itens.Remove(item);
        }
    }

}

