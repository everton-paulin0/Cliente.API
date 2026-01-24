using Cliente.Domain.Models;
using Cliente.Domain.Models.Enum;

namespace Cliente.Application.Model
{
    public class UpdatePedidoInputModel
    {
        public int IdPedido { get; set; }
        public int ClientId { get; set; }
        public int VendedorId { get; set; }
        public Status StatusVenda { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
