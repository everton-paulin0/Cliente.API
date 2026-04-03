using Cliente.Domain.Models;

public class ItemPedido:BaseEntities
{
    public ItemPedido(int produtoId, int quantidade, decimal valorUnitario, Produto produto)
    {
        ProdutoId = produtoId;
        Produto = produto;
        Quantidade = quantidade;
        ValorUnitario = valorUnitario;
    }

    public int ProdutoId { get; private set; }
    public Produto Produto { get; private set; }
    public int Quantidade { get; private set; }
    public decimal ValorUnitario { get; private set; }

   

    public void AdicionarQuantidade(int quantidade)
    {
        if (quantidade <= 0)
            throw new Exception("Quantidade inválida");

        Quantidade += quantidade;
    }

    public decimal Total()
    {
        return Quantidade * ValorUnitario;
    }

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
