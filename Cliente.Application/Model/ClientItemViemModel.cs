using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Domain.Models;
using Cliente.Domain.Models.Enum;

namespace Cliente.Application.Model
{
    public  class ClientItemViemModel
    {
        public ClientItemViemModel(int id, string nomeCliente, string numeroDocumento, string endereco, int numero, string complemento, string cidade, string estado)
        {
            Id = id;
            NomeCliente = nomeCliente;
            NumeroDocumento = numeroDocumento;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado.ToString();
            ;
        }

        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public string NumeroDocumento { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public static ClientItemViemModel FromEntityOrder(Client cliente)
            => new ClientItemViemModel(cliente.Id, cliente.NomeCliente, cliente.NumeroDocumento, cliente.Endereco, cliente.Numero , cliente.Complemento, cliente.Cidade, cliente.Estado.ToString());
    }
}
