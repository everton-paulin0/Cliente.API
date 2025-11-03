using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Application.Model;
using Cliente.Infrastructure;

namespace Cliente.Application.Services
{
    public class ClientsServices : IClientesServices
    {
        private readonly AppDbContext _context;
        public ClientsServices(AppDbContext context)
        {
            _context = context;

        }
        public ResultViewModel Cancel(int id)
        {
            throw new NotImplementedException();
        }

        public ResultViewModel Complete(int id)
        {
            throw new NotImplementedException();
        }

        public ResultViewModel Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ResultViewModel<List<ClientItemViemModel>> GetAll(string search = "")
        {
            throw new NotImplementedException();
        }

        public ResultViewModel<ClientViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ResultViewModel<int> Insert(CreateClientInputModel model)
        {
            throw new NotImplementedException();
        }

        public ResultViewModel SetPaymentPending(int id)
        {
            throw new NotImplementedException();
        }

        public ResultViewModel Update(UpdateClientInputModel model)
        {
            throw new NotImplementedException();
        }
    }
}
