using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Application.Model;

namespace Cliente.Application.Services
{
    public interface IProdutosServices
    {
        ResultViewModel<List<ProdutoItemViewModel>> GetAll(string search = "");
        ResultViewModel<ProdutoViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateProdutoInputModel model);
        ResultViewModel Update(UpdateProdutoInputModel model);
        ResultViewModel Delete(int id);
    }
}
