using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Cliente.Domain.Models;
using Cliente.Domain.Models.Enum;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cliente.Application.Model
{
    public class CreatePedidoInputModel
    {
        [Required]
        public int ClientId { get; set; }
        public int VendedorId { get; set; }
        public Status StatusVenda { get; set; }

        public Pedido ToEntityPedido()
            => new Pedido(ClientId, VendedorId, StatusVenda);
    }
}
