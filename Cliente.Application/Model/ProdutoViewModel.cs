using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Domain.Models;

namespace Cliente.Application.Model
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel(int id, string nomeProduto, int quantidade, decimal valorUnitario)
        {
            Id = id;
            NomeProduto = nomeProduto;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public int Id { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        

        public static ProdutoViewModel FromEntityProduto(Produto entity)
            => new(entity.Id, entity.NomeProduto, entity.Quantidade, entity.ValorUnitario);
    }
}
