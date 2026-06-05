using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Application.Model
{
    public class ComparativoProdutoViewModel
    {
        public string Produto { get; set; }

        public decimal Atual { get; set; }

        public decimal Anterior { get; set; }

        public decimal CrescimentoPercentual { get; set; }
    }
}
