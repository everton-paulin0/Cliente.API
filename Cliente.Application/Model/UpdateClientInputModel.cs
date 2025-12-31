using Cliente.Domain.Models.Enum;

namespace Cliente.Application.Model
{
    public class UpdateClientInputModel
    {
        public int IdCliente { get; set; }
        public int IdPedido { get; set; }
        public string NomeCliente { get; set; }
        public string NumeroDocumento { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public Estados Estado { get; set; }
    }

}
