using Cliente.Application.Model;
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
            throw new NotImplementedException();
        }

        public ResultViewModel<PedidoViewModel> GetById(int id)
        {
            var pedido = _context.Pedidos.SingleOrDefault(p => p.Id == id && p.IsActive);

            if (pedido == null)
                return ResultViewModel<PedidoViewModel>.Error("Pedido não encontrado");

            var model = PedidoViewModel.FromEntity(pedido);

            return ResultViewModel<PedidoViewModel>.Success(model);
        }


        public ResultViewModel<int> Insert(CreatePedidoInputModel model)
        {
            var pedido = model.ToEntityPedido();

            foreach (var item in model.Itens)
            {
                var produto = _context.Produtos
                    .SingleOrDefault(p => p.Id == item.ProdutoId);

                if (produto == null)
                    return ResultViewModel<int>.Error($"Produto {item.ProdutoId} não encontrado");

                pedido.AdicionarProduto(produto, item.Quantidade);
            }

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(pedido.Id);
        }

        public ResultViewModel UpdatePedido(UpdatePedidoInputModel model)
        {
            throw new NotImplementedException();
        }
    }
}


