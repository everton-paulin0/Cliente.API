using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Domain.Models.Enum;

namespace Cliente.Domain.Models
{
    public class Client: BaseEntities
    {
        
        public Client(string nomeCliente, string numeroDocumento, string endereco, int numero, string complemento, string cidade, Estados estado):base()
        {
            NomeCliente = nomeCliente;
            NumeroDocumento = numeroDocumento;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado;
        }
        [Description("Nome do Cliente")]
        public string NomeCliente { get; set; }
        [Description("Documento do Cliente")]
        public string NumeroDocumento { get; set; }
        [Description("Endereço")]
        public string Endereco { get; set; }
        [Description("Numero")]
        public int Numero { get; set; }
        [Description("Complemento")]
        public string Complemento { get; set; }
        [Description("Cidade")]
        public string Cidade { get; set; }
        [Description("Estado")]
        public Estados Estado { get; set; }
        public List<Pedido> Pedidos { get; set; }

        public void Update(string nomeCliente, string numeroDocumento, string endereco, int numero, string complemento, string cidade, Estados estado)
        {
            NomeCliente = nomeCliente;
            NumeroDocumento = numeroDocumento;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado;

            UpdatedAt = DateTime.UtcNow; 
        }

        
    }    
}
