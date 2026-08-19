using Cliente.Application.Constants;
using Cliente.Application.Model;
using Cliente.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace Cliente.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly AppDbContext _context;
        private readonly IDateTimeService _dateTimeService;

        public DashboardService(AppDbContext context, IDateTimeService dateTimeService)
        {
            _context = context;
            _dateTimeService = dateTimeService;
        }
        public ResultViewModel<DashboardViewModel> GetDashboard(DashboardFiltroInputModel filtro)
        {

            // ✅ VALIDAÇÕES 
            if (filtro.DataInicio.HasValue && filtro.DataFim.HasValue)
            {

                if ((filtro.DataFim - filtro.DataInicio).Value.TotalDays >
                DashboardConstants.MaximoDiasConsulta)
                            {
                                return ResultViewModel<DashboardViewModel>.Error(
                        $"Período máximo permitido é de {DashboardConstants.MaximoDiasConsulta} dias");
                }
                if (filtro.DataFim < filtro.DataInicio)
                    return ResultViewModel<DashboardViewModel>.Error("DataFim não pode ser menor que DataInicio");

                
            }
            var pedidos = _context.Pedidos.AsNoTracking().AsQueryable();

            if (filtro.DataInicio.HasValue)
                pedidos = pedidos.Where(p => p.CreatedAt >= filtro.DataInicio.Value);

            if (filtro.DataFim.HasValue)
                pedidos = pedidos.Where(p => p.CreatedAt <= filtro.DataFim.Value);

            var pedidosFiltrados = pedidos.Where(p => p.IsActive);

            var pedidosIds = pedidosFiltrados.Select(p => p.Id).ToList();

            var itens = _context.ItemPedidos
                .AsNoTracking()
                .Where(i => pedidosFiltrados
                .Select(p => p.Id)
                .Contains(i.PedidoId));

            var totalPedidos = pedidosFiltrados.Count();

            //var totalProdutosVendidos = itens.Sum(i => i.Quantidade);

            var totalProdutosVendidos = itens.Any()? itens.Sum(i => i.Quantidade): 0;

            var totalVendas = itens.Sum(i => i.Quantidade * i.ValorUnitario);

            var ticketMedio = totalPedidos == 0 ? 0: totalVendas / totalPedidos;

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

            var produtoMaisVendido = rankingProdutos
                .OrderByDescending(x => x.TotalVendido)
                .FirstOrDefault()?.Nome;

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

            

            var vendasPeriodo = pedidosFiltrados
                .GroupBy(p => new
                {
                    p.CreatedAt.Year,
                    p.CreatedAt.Month
                })
                .Select(g => new
                {
                    g.Key.Year,
                    g.Key.Month,

                    TotalVendas = g
                        .SelectMany(p => p.Itens)
                        .Sum(i => i.Quantidade * i.ValorUnitario)
                })
                .ToList()
                .Select(x => new VendasPeriodoViewModel
                {
                    Periodo = $"{x.Year}-{x.Month:D2}",
                    TotalVendas = x.TotalVendas
                })
                .OrderBy(x => x.Periodo)
                .ToList();



            // =============================
            // COMPARATIVO DE VENDAS
            // =============================

            var inicioMesAtual =
                new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);

            var inicioMesAnterior =
                inicioMesAtual.AddMonths(-1);

            var fimMesAnterior =
                inicioMesAtual.AddDays(-1);

            var mediaHistorica =
                vendasPeriodo.Any()
                    ? vendasPeriodo.Average(x => x.TotalVendas)
                    : 0;

            var ultimoMes = vendasPeriodo
                .OrderByDescending(x => x.Periodo)
                .FirstOrDefault()?.TotalVendas ?? 0;

            var melhorVendedor = rankingVendedores.FirstOrDefault()?.Vendedor;

            // TOTAL MÊS ATUAL

            var atual = _context.ItemPedidos
                .Where(i =>
                    i.Pedido.CreatedAt >= inicioMesAtual &&
                    i.Pedido.IsActive)
                .Sum(i => i.Quantidade * i.ValorUnitario);

            // TOTAL MÊS ANTERIOR

            var anterior = _context.ItemPedidos
                .Where(i =>
                    i.Pedido.CreatedAt >= inicioMesAnterior &&
                    i.Pedido.CreatedAt <= fimMesAnterior &&
                    i.Pedido.IsActive)
                .Sum(i => i.Quantidade * i.ValorUnitario);

            var comparativoVendedores = pedidosFiltrados
                .GroupBy(p => p.Vendedor.NomeVendedor)
                .Select(g => new ComparativoVendedorViewModel
                {
                    Vendedor = g.Key,

                    Atual = g.Where(p =>
                            p.CreatedAt >= inicioMesAtual)
                        .SelectMany(p => p.Itens)
                        .Sum(i => i.Quantidade * i.ValorUnitario),

                    Anterior = g.Where(p =>
                            p.CreatedAt >= inicioMesAnterior &&
                            p.CreatedAt <= fimMesAnterior)
                        .SelectMany(p => p.Itens)
                        .Sum(i => i.Quantidade * i.ValorUnitario)
                })
                .ToList();
            foreach (var vendedor in comparativoVendedores)
            {
                vendedor.CrescimentoPercentual =
                    vendedor.Anterior == 0
                        ? 100
                        : ((vendedor.Atual - vendedor.Anterior)
                            / vendedor.Anterior) * 100;
            }

            var comparativoProdutos = rankingProdutos
                .Select(p => new ComparativoProdutoViewModel
                {
                    Produto = p.Nome,

                    Atual = _context.ItemPedidos
                        .Where(i =>
                            i.Produto.NomeProduto == p.Nome &&
                            i.Pedido.CreatedAt >= inicioMesAtual &&
                            i.Pedido.IsActive)
                        .Sum(i => i.Quantidade * i.ValorUnitario),

                    Anterior = _context.ItemPedidos
                        .Where(i =>
                            i.Produto.NomeProduto == p.Nome &&
                            i.Pedido.CreatedAt >= inicioMesAnterior &&
                            i.Pedido.CreatedAt <= fimMesAnterior &&
                            i.Pedido.IsActive)
                        .Sum(i => i.Quantidade * i.ValorUnitario)
                })
                .ToList();

            foreach (var produto in comparativoProdutos)
            {
                produto.CrescimentoPercentual =
                    produto.Anterior == 0
                        ? DashboardConstants.PercentualSemPeriodoAnterior
                        : ((produto.Atual - produto.Anterior)
                            / produto.Anterior) * 100;
            }


            // CRESCIMENTO %

            
            var crescimento = anterior == 0
                ? DashboardConstants.PercentualSemPeriodoAnterior
                : ((atual - anterior) / anterior) * 100;

            // =============================
            // COMPARATIVO PEDIDOS
            // =============================

            var pedidosAtual = _context.Pedidos
                .Count(p =>
                    p.CreatedAt >= inicioMesAtual &&
                    p.IsActive);

            var pedidosAnterior = _context.Pedidos
                .Count(p =>
                    p.CreatedAt >= inicioMesAnterior &&
                    p.CreatedAt <= fimMesAnterior &&
                    p.IsActive);

            
            var crescimentoPedidos =
                pedidosAnterior == 0
                ? DashboardConstants.PercentualSemPeriodoAnterior
                : ((decimal)(pedidosAtual - pedidosAnterior)
                    / pedidosAnterior) * 100;


            //TENDÊNCIAS

            var tendencias = new List<TendenciaViewModel>
{
                new()
                {
                    Indicador = "Vendas",

                    MediaPeriodo = mediaHistorica,

                    UltimoPeriodo = ultimoMes,

                    TendenciaAlta =
                        ultimoMes >= mediaHistorica
                }
            };


            // =============================
            // COMPARATIVO TICKET MÉDIO
            // =============================

            var ticketAtual =
                pedidosAtual == 0
                ? 0
                : atual / pedidosAtual;

            var ticketAnterior =
                pedidosAnterior == 0
                ? 0
                : anterior / pedidosAnterior;

            
            var crescimentoTicket =
                ticketAnterior == 0
                ? DashboardConstants.PercentualSemPeriodoAnterior
                : ((ticketAtual - ticketAnterior)
                    / ticketAnterior) * 100;



            var model = new DashboardViewModel
            {
                TotalVendas = totalVendas,

                TotalPedidos = totalPedidos,

                TotalProdutosVendidos = totalProdutosVendidos,

                TicketMedio = ticketMedio,

                Tendencias = tendencias,

                MelhorVendedor = melhorVendedor,

                ProdutoMaisVendido = produtoMaisVendido,

                RankingProdutos = rankingProdutos,

                RankingVendedores = rankingVendedores,

                ComparativoProdutos = comparativoProdutos,

                ComparativoVendedores = comparativoVendedores,
                

                ComparativoVendas = new ComparativoViewModel
                {
                    Atual = atual,
                    Anterior = anterior,
                    CrescimentoPercentual = crescimento
                },

                VendasPeriodo = vendasPeriodo,


                ComparativoPedidos = new ComparativoViewModel
                {
                    Atual = pedidosAtual,
                    Anterior = pedidosAnterior,
                    CrescimentoPercentual = crescimentoPedidos
                },

                ComparativoTicketMedio = new ComparativoViewModel
                {
                    Atual = ticketAtual,
                    Anterior = ticketAnterior,
                    CrescimentoPercentual = crescimentoTicket
                },


            };            

        return ResultViewModel<DashboardViewModel>.Success(model);

        }
    }    
}

