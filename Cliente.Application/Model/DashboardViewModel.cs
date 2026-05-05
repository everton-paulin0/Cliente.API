using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Application.Model;

namespace Cliente.Application.Model
{
    public class DashboardViewModel
    {
        public decimal TotalVendas { get; set; }
        public int TotalPedidos { get; set; }
        public int TotalProdutosVendidos { get; set; }
        public decimal TicketMedio { get; set; }
        public List<RankingProdutoViewModel> RankingProdutos { get; set; } = new();
        public List<RankingVendedorViewModel> RankingVendedores { get; set; } = new();
    }
}


