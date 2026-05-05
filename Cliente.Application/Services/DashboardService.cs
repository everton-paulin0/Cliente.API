using Cliente.Application.Model;
using Cliente.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cliente.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly AppDbContext _context;

        public DashboardService(AppDbContext context)
        {
            _context = context;
        }
        public ResultViewModel<DashboardViewModel> GetDashboard(DashboardFiltroInputModel filtro)
        {

            // ✅ VALIDAÇÕES 
            if (filtro.DataInicio.HasValue && filtro.DataFim.HasValue)
            {
                if (filtro.DataFim < filtro.DataInicio)
                    return ResultViewModel<DashboardViewModel>.Error("DataFim não pode ser menor que DataInicio");

                if ((filtro.DataFim - filtro.DataInicio).Value.TotalDays > 365)
                    return ResultViewModel<DashboardViewModel>.Error("Período máximo permitido é de 1 ano");
            }
            var pedidos = _context.Pedidos.AsQueryable();

            if (filtro.DataInicio.HasValue)
                pedidos = pedidos.Where(p => p.CreatedAt >= filtro.DataInicio.Value);

            if (filtro.DataFim.HasValue)
                pedidos = pedidos.Where(p => p.CreatedAt <= filtro.DataFim.Value);

            var pedidosFiltrados = pedidos.Where(p => p.IsActive);

            var pedidosIds = pedidosFiltrados.Select(p => p.Id).ToList();

            var itens = _context.ItemPedidos
                .Where(i => pedidosIds.Contains(i.PedidoId));

            var totalPedidos = pedidosFiltrados.Count();

            var totalProdutosVendidos = itens.Sum(i => i.Quantidade);

            var totalVendas = itens.Sum(i => i.Quantidade * i.ValorUnitario);

            var ticketMedio = totalPedidos > 0
                ? totalVendas / totalPedidos
                : 0;

            // ✅ RANKINGS

            var rankingProdutos = itens
                .GroupBy(i => i.Produto.NomeProduto)
                .Select(g => new RankingProdutoViewModel
                {
                    Nome = g.Key,
                    TotalVendido = g.Sum(i => i.Quantidade),
                    TotalFaturado = g.Sum(i => i.Quantidade * i.ValorUnitario)
                })
                .OrderByDescending(x => x.TotalFaturado)
                .Take(5)
                .ToList();

            var rankingVendedores = pedidosFiltrados
                .GroupBy(p => p.Vendedor.NomeVendedor)
                .Select(g => new RankingVendedorViewModel
                {
                    Vendedor = g.Key,
                    TotalPedidos = g.Count(),
                    TotalVendas = g.SelectMany(p => p.Itens)
                        .Sum(i => i.Quantidade * i.ValorUnitario)
                })
                .OrderByDescending(x => x.TotalVendas)
                .Take(5)
                .ToList();

            var model = new DashboardViewModel
            {
                TotalVendas = totalVendas,
                TotalPedidos = totalPedidos,
                TotalProdutosVendidos = totalProdutosVendidos,
                TicketMedio = ticketMedio,
                RankingProdutos = rankingProdutos,
                RankingVendedores = rankingVendedores
            };

            return ResultViewModel<DashboardViewModel>.Success(model);
        }
    }
    
}

