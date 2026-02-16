using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Domain.Models;

namespace Cliente.Application.Model
{
    public class CreateProdutoInputModel
    {
        [Required]
        public string NomeProduto { get; set; }
        public string MarcaProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
       

        public Produto ToEntityProduto()
            => new Produto(NomeProduto, MarcaProduto, Quantidade, ValorUnitario);
    }
}
