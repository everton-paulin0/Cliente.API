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
       
        public Produto(string nomeProduto, int quantidade, decimal valorUnitario) : base()
        {
            NomeProduto = nomeProduto;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            
        }
        [Description("Nome do Produto")]
        public string NomeProduto { get; set; }
        [Description("Quantidade")]
        public int Quantidade { get; set; }
        [Description("Valor Unitário")]
        public decimal ValorUnitario { get; set; }
        

        public void Update(string nomeProduto, int quantidade, decimal valorUnitario, int pedidoId)
        {
            NomeProduto = nomeProduto;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            

             UpdatedAt = DateTime.UtcNow;
        }

        public decimal CalcularValorTotal() => Quantidade * ValorUnitario;

        public void Update(string nomeProduto, int quantidade)
        {
            throw new NotImplementedException();
        }
    }
}
