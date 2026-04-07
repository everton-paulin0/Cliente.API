using Cliente.Domain.Models;

public class ItemPedido : BaseEntities
{
    protected ItemPedido() { } // EF

    public ItemPedido(int produtoId, int quantidade, decimal valorUnitario)
    {
        ProdutoId = produtoId;
        
        Quantidade = quantidade;
        ValorUnitario = valorUnitario;
    }

    public int ProdutoId { get; private set; }
    public Produto Produto { get; private set; }

    public int PedidoId { get; private set; }
    public Pedido Pedido { get; private set; } // ✔ CORRETO

    public int Quantidade { get; private set; }
    public decimal ValorUnitario { get; private set; }

    public void AdicionarQuantidade(int quantidade)
    {
        if (quantidade <= 0)
            throw new Exception("Quantidade inválida");

        Quantidade += quantidade;
    }

    public decimal Total() => Quantidade * ValorUnitario;

    public void AtualizarQuantidade(int quantidade)
    {
        if (quantidade <= 0)
            throw new Exception("Quantidade inválida");

        Quantidade = quantidade;
    }

    public void AtualizarProduto(int produtoId, Produto produto, decimal valorUnitario)
    {
        ProdutoId = produtoId;
        Produto = produto;
        ValorUnitario = valorUnitario;
    }
}