using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Domain.Models;
using Cliente.Domain.Models.Enum;

namespace Cliente.Application.Model
{
    public class PedidoItemViewModel
    {
        public PedidoItemViewModel(int id, int clientId, int vendedorId, string statusVenda, List<Produto> produtos)
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
        public List<Produto> Produtos { get; set; }

        public static PedidoItemViewModel FromEntityPedido(Pedido pedido)
            => new PedidoItemViewModel(pedido.Id, pedido.ClientId, pedido.VendedorId, pedido.StatusVenda.ToString(), pedido.Produtos.ToList());
    }
}
