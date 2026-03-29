using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Domain.Models.Enum;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cliente.Domain.Models
{
    public class Produto : BaseEntities
    {
       
        public Produto(string nomeProduto,string marcaProduto, int quantidade, decimal valorUnitario) : base()
        {
            NomeProduto = nomeProduto;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            MarcaProduto = marcaProduto;

        }
        [Description("Nome do Produto")]
        public string NomeProduto { get; set; }
        [Description("Marca do Produto")]
        public string MarcaProduto { get; set; }
        [Description("Quantidade")]
        public int Quantidade { get; set; }
        [Description("Valor Unitário")]
        public decimal ValorUnitario { get; set; }

        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }



        public decimal CalcularValorTotal() => Quantidade * ValorUnitario;

        public void UpdateProduto(string nomeProduto, string marcaProduto, int quantidade, decimal valorUnitario)
        {
            NomeProduto = nomeProduto;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            MarcaProduto = marcaProduto;
            UpdatedAt = DateTime.Now;
        }
    }
}
