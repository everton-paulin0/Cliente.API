using Cliente.Application.Model;
using Cliente.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cliente.Application.Services
{
    public class ItemPedidoServices : IItemPedidoServices
    {
        private readonly AppDbContext _context;
        public ItemPedidoServices(AppDbContext context)
        {
            _context = context;
        }

        public ResultViewModel Delete(int id)
        {
            var itemPedido = _context.ItemPedidos.SingleOrDefault(p => p.Id == id);

            if (itemPedido == null)
            {
                return ResultViewModel<ItemPedidoViewModel>.Error("Item do Pedido Não Encontrado");
            }

            itemPedido.SetAsDeleted();
            _context.ItemPedidos.Update(itemPedido);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel<List<ItemPedidoItemViewModel>> GetAll(string search = "")
        {
            throw new NotImplementedException();
        }

        public ResultViewModel<ItemPedidoViewModel> GetById(int id)
        {
            var itemPedido = _context.ItemPedidos.SingleOrDefault(p => p.Id == id && p.IsActive);

            if (itemPedido == null)
                return ResultViewModel<ItemPedidoViewModel>.Error("Item do Pedido não encontrado");

            var model = ItemPedidoViewModel.ItemPedidoFromEntity(itemPedido);

            return ResultViewModel<ItemPedidoViewModel>.Success(model);
        }

        public ResultViewModel<int> Insert(CreateItemPedidoInputModel model)
        {
            var pedido = _context.Pedidos
                .Include(p => p.Itens)
                .SingleOrDefault(p => p.Id == model.PedidoId);

            if (pedido == null)
                return ResultViewModel<int>.Error("Pedido não encontrado");

            var produto = _context.Produtos
                .SingleOrDefault(p => p.Id == model.ProdutoId);

            if (produto == null)
                return ResultViewModel<int>.Error("Produto não encontrado");

            // 🔥 REGRA DE NEGÓCIO CENTRALIZADA
            pedido.AdicionarProduto(produto, model.Quantidade);

            _context.Pedidos.Update(pedido);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(pedido.Id);
        }
        

        public ResultViewModel UpdatePedido(UpdateItemPedidoInputModel model)
        {
            var itemPedido = _context.ItemPedidos
                .SingleOrDefault(c => c.Id == model.IdItemPedido);

            if (itemPedido == null)
                return ResultViewModel.Error("Item do Pedido Não Encontrado");

            var produto = _context.Produtos
                .SingleOrDefault(p => p.Id == model.ProdutoId);

            if (produto == null)
                return ResultViewModel.Error("Produto não encontrado");

            // Atualiza dados
            itemPedido.AtualizarQuantidade(model.Quantidade);

            // (Opcional) atualizar produto também
            itemPedido.AtualizarProduto(
                produto.Id,
                produto,
                produto.ValorUnitario
            );

            _context.ItemPedidos.Update(itemPedido);
            _context.SaveChanges();

            return ResultViewModel.Success("Item do Pedido Atualizado com sucesso");
        }
    }
}

