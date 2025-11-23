using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Application.Model;

namespace Cliente.Application.Services
{
    public interface IClientesServices
    {
        ResultViewModel<List<ClientItemViemModel>> GetAll(string search = "");
        ResultViewModel<ClientViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateClientInputModel model);
        ResultViewModel Update(UpdateClientInputModel model);
        ResultViewModel Delete(int id);
        
    }
}
