using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Domain.Models;
using Cliente.Domain.Models.Enum;

namespace Cliente.Application.Model
{
    public class CreateClientInputModel
    {
        [Required]       
        public string NomeCliente { get; set; }        
        public string NumeroDocumento { get; set; }        
        public string Endereco { get; set; }        
        public int Numero { get; set; }
        public string Complemento { get; set; }      
        public string Cidade { get; set; }        
        public Estados Estado { get; set; }

        public Client ToEntityClient()
            => new Client(NomeCliente, NumeroDocumento, Endereco, Numero, Complemento, Cidade, Estado);
    }
}
