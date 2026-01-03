using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Application.Model;
using Cliente.Domain.Models;
using Cliente.Infrastructure;

namespace Cliente.Application.Services
{
    
    public class ProdutosServices : IProdutosServices
    {
        private readonly AppDbContext _context;
        public ProdutosServices(AppDbContext context)
        {
            _context = context;
        }
        public ResultViewModel Delete(int id)
        {
            var produtos = _context.Produtos.SingleOrDefault(c => c.Id == id);

            if (produtos == null)
            {
                return ResultViewModel<ProdutoViewModel>.Error("Produto Não Encontrado");
            }

            produtos.SetAsDeleted();
            _context.Produtos.Update(produtos);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel<List<ProdutoItemViewModel>> GetAll(string search = "")
        {
            var produtos = _context.Produtos.Where(c => !c.IsActive).ToList();

            var model = produtos.Select(ProdutoItemViewModel.FromEntityProduto).ToList();

            return ResultViewModel<List<ProdutoItemViewModel>>.Success(model); ;
        }

        public ResultViewModel<ProdutoViewModel> GetById(int id)
        {
            var produtos = _context.Produtos.SingleOrDefault(pr => pr.Id == id && pr.IsActive);

            if (produtos == null)
                return ResultViewModel<ProdutoViewModel>.Error("Produto não encontrado");

            var model = ProdutoViewModel.FromEntityProduto(produtos);

            return ResultViewModel<ProdutoViewModel>.Success(model);
        }

        public ResultViewModel<int> Insert(CreateProdutoInputModel model)
        {
            var produtos = model.ToEntityProduto();

            _context.Produtos.Add(produtos);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(produtos.Id);
        }

        public ResultViewModel Update(UpdateProdutoInputModel model)
        {
            var produto = _context.Produtos.SingleOrDefault(c => c.Id == model.IdProduto);

            if (produto == null)
            {
                return ResultViewModel.Error("Produto Não Encontrado");
            }

            produto.Update(model.NomeProduto, model.Quantidade);

            _context.Produtos.Update(produto);

            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
