using Cliente.Application.Model;
using Cliente.Domain.Models;

public class PedidoViewModel
{
    public int Id { get; private set; }
    public string Cliente { get; private set; }
    public string Vendedor { get; private set; }
    public string StatusVenda { get; private set; }
    public decimal Total { get; private set; }

    public List<ItemPedidoViewModel> Itens { get; private set; }

    public PedidoViewModel(
        int id,
        string cliente,
        string vendedor,
        string statusVenda,
        decimal total,
        List<ItemPedidoViewModel> itens)
    {
        Id = id;
        Cliente = cliente;
        Vendedor = vendedor;
        StatusVenda = statusVenda;
        Total = total;
        Itens = itens;
    }

    public static PedidoViewModel FromEntity(Pedido pedido)
        => new PedidoViewModel(
            pedido.Id,
            pedido.Cliente.NomeCliente,
            pedido.Vendedor.NomeVendedor,
            pedido.StatusVenda.ToString(),
            pedido.GetTotal(),
            pedido.Itens.Select(ItemPedidoViewModel.ItemPedidoFromEntity).ToList()
        );
}