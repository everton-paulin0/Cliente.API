using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Domain.Models;

namespace Cliente.Application.Model
{
    public class ProdutoItemViewModel
    {
        public ProdutoItemViewModel(int id, string nomeProduto,string marcaProduto, int quantidade, decimal valorUnitario)
        {
            Id = id;
            NomeProduto = nomeProduto;
            MarcaProduto = marcaProduto;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            
            
        }

        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public string MarcaProduto { get; set; }
        public int Quantidade { get; set; }       
        public decimal ValorUnitario { get; set; }        
        
        public static ProdutoItemViewModel FromEntityProduto(Produto produto)
           => new ProdutoItemViewModel(produto.Id, produto.NomeProduto, produto.MarcaProduto, produto.Quantidade, produto.ValorUnitario);

    }
}
