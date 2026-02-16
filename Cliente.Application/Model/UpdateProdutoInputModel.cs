using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Application.Model
{
    public class UpdateProdutoInputModel
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public string MarcaProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        
    }
}
