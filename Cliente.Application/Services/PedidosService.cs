using Cliente.Application.Model;
using Cliente.Domain.Models.Enum;
using Cliente.Infrastructure;

namespace Cliente.Application.Services
{

    public class PedidosService : IPedidosServices
    {
        private readonly AppDbContext _context;
        public PedidosService(AppDbContext context)
        {
            _context = context;
        }

        public ResultViewModel Delete(int id)
        {
            var pedido = _context.Pedidos.SingleOrDefault(p => p.Id == id);

            if (pedido == null)
            {
                return ResultViewModel<PedidoViewModel>.Error("Pedido Não Encontrado");
            }

            pedido.SetAsDeleted();
            _context.Pedidos.Update(pedido);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel<List<PedidoItemViewModel>> GetAll(string search = "")
        {
            var pedidos = _context.Pedidos.Where(c => !c.IsActive).ToList();

            var model = pedidos.Select(PedidoItemViewModel.FromEntityPedido).ToList();


            return ResultViewModel<List<PedidoItemViewModel>>.Success(model);
        }

        public ResultViewModel<PedidoViewModel> GetById(int id)
        {
            var pedido = _context.Pedidos.SingleOrDefault(p => p.Id == id && p.IsActive);

            if (pedido == null)
                return ResultViewModel<PedidoViewModel>.Error("Pedido não encontrado");

            var model = PedidoViewModel.PedidoFromEntity(pedido);

            return ResultViewModel<PedidoViewModel>.Success(model);
        }

        public ResultViewModel<int> Insert(CreatePedidoInputModel model)
        {
            var pedido = model.ToEntityPedido();

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(pedido.Id);
        }

       

        

        public ResultViewModel UpdatePedido(UpdatePedidoInputModel model)
        {
            var pedido = _context.Pedidos.SingleOrDefault(c => c.Id == model.IdPedido);

            if (pedido == null)
            {
                return ResultViewModel.Error("Pedido Não Encontrado");
            }

            pedido.UpdatePedido(model.ClientId, model.VendedorId, model.StatusVenda, model.Produtos);

            _context.Pedidos.Update(pedido);

            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}

