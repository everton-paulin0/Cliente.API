using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Domain.Models.Enum
{
    public enum Status
    {
        [Description("Iniciado")]
        Iniciado,
        [Description("Cancelado")]
        Cancelado,
        [Description("Congelado")]
        Congelado,
        [Description("Finalizado")]
        Finalizado,
        [Description("Pagamento Pendente")]
        PagamentoPendente
    }
}
