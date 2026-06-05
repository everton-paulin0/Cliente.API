using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Application.Model
{
    public class TendenciaViewModel
    {
        public string Indicador { get; set; }

        public decimal MediaPeriodo { get; set; }

        public decimal UltimoPeriodo { get; set; }

        public bool TendenciaAlta { get; set; }
    }
}
