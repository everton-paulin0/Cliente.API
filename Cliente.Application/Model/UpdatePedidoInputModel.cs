using Cliente.Domain.Models;

namespace Cliente.Application.Model
{
    public class UpdatePedidoInputModel
    {
        public int IdPedido { get; set; }
        public int ClientId { get; set; }
        public int VendedorId { get; set; }
        public string StatusVenda { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
