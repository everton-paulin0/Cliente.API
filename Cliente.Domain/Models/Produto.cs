using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Domain.Models
{
    public class Produto : BaseEntities
    {
       
        public Produto(string nomeProduto, int quantidade, decimal valorUnitario, int pedidoId)
        {
            NomeProduto = nomeProduto;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            PedidoId = pedidoId;
        }

        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public decimal CalcularValorTotal() => Quantidade * ValorUnitario;
    }
}
