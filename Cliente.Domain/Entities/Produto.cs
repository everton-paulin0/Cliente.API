using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Domain.Models
{
    public class Produto : BaseEntities
    {
       
        public Produto(string nomeProduto, int quantidade, decimal valorUnitario, int pedidoId) : base()
        {
            NomeProduto = nomeProduto;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            PedidoId = pedidoId;
        }
        [Description("Nome do Produto")]
        public string NomeProduto { get; set; }
        [Description("Quantidade")]
        public int Quantidade { get; set; }
        [Description("Valor Unitário")]
        public decimal ValorUnitario { get; set; }
        [Description("Numero do Pedido")]
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public decimal CalcularValorTotal() => Quantidade * ValorUnitario;
    }
}
