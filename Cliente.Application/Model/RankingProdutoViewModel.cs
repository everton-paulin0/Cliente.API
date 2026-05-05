using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Application.Model
{
    public class RankingProdutoViewModel
    {
        public string Nome { get; set; } = string.Empty;

        public int TotalVendido { get; set; }

        public decimal TotalFaturado { get; set; }


    }
}
