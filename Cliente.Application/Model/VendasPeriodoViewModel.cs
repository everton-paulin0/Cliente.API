using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Application.Model
{
    public class VendasPeriodoViewModel
    {
        public string Periodo { get; set; }

        public decimal TotalVendas { get; set; }


    }

    var vendasPeriodo = _context.Pedidos
    .Where(p => p.IsActive)
    .AsEnumerable()
    .GroupBy(p => new
    {
        p.CreatedAt.Year,
        p.CreatedAt.Month
    })
    .Select(g => new VendasPeriodoViewModel
    {
        Periodo = $"{g.Key.Year}-{g.Key.Month:D2}",
        TotalVendas = g
            .SelectMany(p => p.Itens)
            .Sum(i => i.Quantidade * i.ValorUnitario)
    })
    .OrderBy(x => x.Periodo)
    .ToList();
    }
