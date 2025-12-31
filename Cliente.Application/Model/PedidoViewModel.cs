using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Domain.Models;

namespace Cliente.Application.Model
{
    public class PedidoViewModel
    {
        public PedidoViewModel(int id, int clientId, int vendedorId, string statusVenda, List<Produto> produtos)
        {
            Id = id;
            ClientId = clientId;
            VendedorId = vendedorId;
            StatusVenda = statusVenda.ToString();
            Produtos = [];
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int VendedorId { get; set; }
        public string StatusVenda { get; set; }
        public List<Produto> Produtos { get; set; } = new List<Produto>();

        public static PedidoViewModel PedidoFromEntity(Pedido entity)
            => new(entity.Id, entity.ClientId, entity.VendedorId, entity.StatusVenda.ToString(), entity.Produtos);
    }
}
