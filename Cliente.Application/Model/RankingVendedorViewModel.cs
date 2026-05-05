using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Application.Model
{
    public class RankingVendedorViewModel
    {
        public string Vendedor { get; set; }
        public decimal TotalVendas { get; set; }
        public int TotalPedidos { get; set; }
    }
}
