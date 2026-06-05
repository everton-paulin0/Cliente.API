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
        public string MelhorVendedor { get; set; }
        public string ProdutoMaisVendido { get; set; }
       

        public List<RankingProdutoViewModel> RankingProdutos { get; set; } = new();
        public List<RankingVendedorViewModel> RankingVendedores { get; set; } = new();
        public ComparativoViewModel ComparativoVendas { get; set; }
        public ComparativoViewModel ComparativoPedidos { get; set; }        
        public List<ComparativoProdutoViewModel> ComparativoProdutos { get; set; }
        public List<ComparativoVendedorViewModel> ComparativoVendedores { get; set; }
        public ComparativoViewModel ComparativoTicketMedio { get; set; }
        public List<VendasPeriodoViewModel> VendasPeriodo { get; set; }
        public List<TendenciaViewModel> Tendencias { get; set; }       

    }
}


