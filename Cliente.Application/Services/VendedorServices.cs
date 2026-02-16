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
    public class VendedorServices : IVendedorServices
    {
        private readonly AppDbContext _context;
        public VendedorServices(AppDbContext context)
        {
            _context = context;
        }

        public ResultViewModel Delete(int id)
        {
            var vendedor = _context.Vendedores.SingleOrDefault(v => v.Id == id);

            if (vendedor == null)
            {
                return ResultViewModel<ClientViewModel>.Error("Vendedor Não Encontrado");
            }

            vendedor.SetAsDeleted();
            _context.Vendedores.Update(vendedor);
            _context.SaveChanges();

            return ResultViewModel.Success("Vendedor Deletado com sucesso.");
        }

        public ResultViewModel<List<VendedorItemViewModel>> GetAll(string search = "")
        {
            var vendedores = _context.Vendedores.Where(v => v.IsActive).ToList();

            var model = vendedores.Select(VendedorItemViewModel.FromEntityVendedor).ToList();

            return ResultViewModel<List<VendedorItemViewModel>>.Success(model);
        }

        public ResultViewModel<VendedorViewModel> GetById(int id)
        {
            var vendedores = _context.Vendedores.SingleOrDefault(v => v.Id == id && v.IsActive);

            if (vendedores == null)
                return ResultViewModel<VendedorViewModel>.Error("Vendedores não encontrado");

            var model = VendedorViewModel.FromEntityVendedor(vendedores);

            return ResultViewModel<VendedorViewModel>.Success(model);
        }

        public ResultViewModel<int> Insert(CreateVendedorInputModel model)
        {
            var vendedor = model.ToEntityVendedor();

            _context.Vendedores.Add(vendedor);
            _context.SaveChanges();

           return ResultViewModel<int>.Success(vendedor.Id,"Vendedor Cadastrado com sucesso.");
        }

        public ResultViewModel UpdateVendedor(UpdateVendedorInputModel model)
        {
            var vendedor = _context.Vendedores.SingleOrDefault(c => c.Id == model.IdVendedor);

            if (vendedor == null)
            {
                return ResultViewModel.Error("Vendedor Não Encontrado");
            }

            vendedor.UpdateVendedor(model.NomeVendedor);

            _context.Vendedores.Update(vendedor);

            _context.SaveChanges();

            return ResultViewModel.Success("Vendedor Atualizado com sucesso.");
        }
    }
}
