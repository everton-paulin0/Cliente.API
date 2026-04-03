using Cliente.Application.Model;

namespace Cliente.Application.Services
{
    public interface IItemPedidoServices 
    {

        ResultViewModel<List<ItemPedidoItemViewModel>> GetAll(string search = "");
        ResultViewModel<ItemPedidoViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateItemPedidoInputModel model);
        ResultViewModel UpdatePedido(UpdateItemPedidoInputModel model);
        ResultViewModel Delete(int id);

    }
            
}
