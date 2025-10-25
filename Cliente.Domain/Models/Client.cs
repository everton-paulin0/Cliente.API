using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Domain.Models.Enum;

namespace Cliente.Domain.Models
{
    public class Client: BaseEntities
    {
        public Client(string nomeCliente, string numeroDocumento, string endereco, int numero, string complemento, string cidade, Estados estado)
        {
            NomeCliente = nomeCliente;
            NumeroDocumento = numeroDocumento;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado;
        }

        public string NomeCliente { get; set; }
        public string NumeroDocumento { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public Estados Estado { get; set; }
    }
}
