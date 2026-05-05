using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Application.Model;

namespace Cliente.Application.Services
{
    public interface IDashboardService
    {
        ResultViewModel<DashboardViewModel> GetDashboard(DashboardFiltroInputModel filtro);
    }
}
