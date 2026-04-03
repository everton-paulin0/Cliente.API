using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Application.Model;

namespace Cliente.Application.Services
{
    public interface IPedidosServices
    {
        ResultViewModel<List<PedidoItemViewModel>> GetAll(string search = "");
        ResultViewModel<PedidoViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreatePedidoInputModel model);
        ResultViewModel UpdatePedido(UpdatePedidoInputModel model);
        ResultViewModel Delete(int id);

    }
}

