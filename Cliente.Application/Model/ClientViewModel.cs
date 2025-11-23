using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Domain.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Cliente.Application.Model
{
    public class ClientViewModel
    {
        public ClientViewModel(int id, string nomeCliente, string numeroDocumento, string endereco, int numero, string complemento, string cidade, string estado)
        {
            Id = id;
            NomeCliente = nomeCliente;
            NumeroDocumento = numeroDocumento;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado.ToString();
        }

        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public string NumeroDocumento { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public static ClientViewModel FromEntity(Client entity)
            => new(entity.Id, entity.NomeCliente, entity.NumeroDocumento, entity.Endereco, entity.Numero, entity.Complemento, entity.Cidade, entity.Estado.ToString());
    }
}
