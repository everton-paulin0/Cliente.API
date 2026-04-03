using System.ComponentModel.DataAnnotations;
using Cliente.Domain.Models;
using Cliente.Domain.Models.Enum;

namespace Cliente.Application.Model
{
    public class CreatePedidoInputModel
    {
        [Required]
        public int ClientId { get; set; }
        public int VendedorId { get; set; }
        public Status StatusVenda { get; set; }        
        public List<PedidoItemViewModel> Itens { get; set; } = new();


        public Pedido ToEntityPedido()
            => new Pedido(ClientId, VendedorId, StatusVenda);
    }

}