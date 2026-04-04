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

        public ResultViewModel<List<PedidoViewModel>> GetAll(string search = "")
        {
            var pedidos = _context.Pedidos
                .Where(c => c.IsActive)
                .ToList();

            var model = pedidos
                .Select(p => PedidoViewModel.FromEntity(p))
                .ToList();

            return ResultViewModel<List<PedidoViewModel>>.Success(model);
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

        //public ResultViewModel UpdatePedido(UpdatePedidoInputModel model)
        //{
        //    var pedido = _context.Pedidos
        //        .SingleOrDefault(p => p.Id == model.IdPedido);

        //    if (pedido == null)
        //        return ResultViewModel.Error("Pedido não encontrado");

        //    // atualiza dados básicos
        //    pedido.UpdatePedido(model.ClientId, model.VendedorId, model.StatusVenda);


        //    _context.SaveChanges();

        //    return ResultViewModel.Success("Pedido atualizado com sucesso");
        //}

        public ResultViewModel UpdatePedido(UpdatePedidoInputModel model)
        {
            var pedido = _context.Pedidos
                .SingleOrDefault(p => p.Id == model.IdPedido);

            if (pedido == null)
                return ResultViewModel.Error("Pedido não encontrado");

            // 1. Atualiza dados básicos
            pedido.UpdatePedido(model.ClientId, model.VendedorId, model.StatusVenda);

            // 2. Devolve estoque e limpa itens
            pedido.LimparItens();

            // 3. Adiciona novamente
            foreach (var item in model.Itens)
            {
                var produto = _context.Produtos
                    .SingleOrDefault(p => p.Id == item.ProdutoId);

                if (produto == null)
                    return ResultViewModel.Error($"Produto {item.ProdutoId} não encontrado");

                if (produto.Quantidade < item.Quantidade)
                    return ResultViewModel.Error($"Estoque insuficiente para {produto.NomeProduto}");

                pedido.AdicionarProduto(produto, item.Quantidade);
            }

            // 4. Salva
            _context.SaveChanges();

            return ResultViewModel.Success("Pedido atualizado com sucesso");
        }
    }
}


