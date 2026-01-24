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
        public ResultViewModel Delete(int id)
        {
            var client = _context.Clientes.SingleOrDefault(c => c.Id == id);

            if (client == null)
            {
                return ResultViewModel<ClientViewModel>.Error("Cliente Não Encontrado");
            }

            client.SetAsDeleted();
            _context.Clientes.Update(client);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel<List<ClientItemViemModel>> GetAll(string search = "")
        {
            var clients = _context.Clientes.Where(c => !c.IsActive).ToList();

            var model = clients.Select(ClientItemViemModel.FromEntityClient).ToList();

            return ResultViewModel<List<ClientItemViemModel>>.Success(model);
        }

        public ResultViewModel<ClientViewModel> GetById(int id)
        {
            var client = _context.Clientes.SingleOrDefault(c => c.Id == id && c.IsActive);

            if (client == null)
                return ResultViewModel<ClientViewModel>.Error("Cliente não encontrado");

            var model = ClientViewModel.FromEntity(client);

            return ResultViewModel<ClientViewModel>.Success(model);
        }


        public ResultViewModel<int> Insert(CreateClientInputModel model)
        {
            var client = model.ToEntityClient();

            _context.Clientes.Add(client);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(client.Id);
        }

        public ResultViewModel Update(UpdateClientInputModel model)
        {
            var client = _context.Clientes.SingleOrDefault(c => c.Id == model.IdCliente);

            if (client == null)
            {
                return ResultViewModel.Error("Cliente Não Encontrado");
            }

            client.Update(model.NomeCliente, model.NumeroDocumento, model.Endereco, model.Numero, model.Complemento, model.Cidade, model.Estado);

            _context.Clientes.Update(client);

            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}











