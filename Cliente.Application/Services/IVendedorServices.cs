using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Application.Model;

namespace Cliente.Application.Services
{
    public interface IVendedorServices
    {
        ResultViewModel<List<VendedorItemViewModel>> GetAll(string search = "");
        ResultViewModel<VendedorViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateVendedorInputModel model);
        ResultViewModel UpdateVendedor(UpdateVendedorInputModel model);
        ResultViewModel Delete(int id);
    }
}
