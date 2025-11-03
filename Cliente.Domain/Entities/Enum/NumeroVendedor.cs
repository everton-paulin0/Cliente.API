using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Domain.Models.Enum
{
    public enum NumeroVendedor
    {
        [Description("001 - JOSÉ")]
        V001 = 1,
        [Description("002 - ANTÔNIO")]
        V002 = 2,
        [Description("003 - FRANCISCO")]
        V003 = 3
    }
}
