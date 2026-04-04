using Cliente.Application.Model;

namespace Cliente.Application.Services
{
    public interface IPedidosServices
    {
        ResultViewModel<List<PedidoViewModel>> GetAll(string search = "");
        ResultViewModel<PedidoViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreatePedidoInputModel model);
        ResultViewModel UpdatePedido(UpdatePedidoInputModel model);
        ResultViewModel Delete(int id);

    }
}

