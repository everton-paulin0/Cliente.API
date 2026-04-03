using Cliente.Domain.Models;

namespace Cliente.Application.Model
{
    public class PedidoViewModel
    {
        public PedidoViewModel(int id, int clientId, int vendedorId, string statusVenda, List<PedidoItemViewModel> itens)
        {
            Id = id;
            ClientId = clientId;
            VendedorId = vendedorId;
            StatusVenda = statusVenda;
            Itens = itens;
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int VendedorId { get; set; }
        public string StatusVenda { get; set; }

        public List<PedidoItemViewModel> Itens { get; set; } = new();

        public static PedidoViewModel FromEntity(Pedido entity)
            => new PedidoViewModel(
                entity.Id,
                entity.ClientId,
                entity.VendedorId,
                entity.StatusVenda.ToString(),
                entity.Itens.Select(PedidoItemViewModel.ItemPedidoFromEntity).ToList()
            );
    }
}