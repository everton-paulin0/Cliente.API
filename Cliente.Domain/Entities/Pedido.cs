using System.ComponentModel;
using Cliente.Domain.Models.Enum;


namespace Cliente.Domain.Models
{
    public class Pedido :BaseEntities
    {
        public Pedido(int clientId, int vendedorId,  Status statusVenda) : base()
        {
            ClientId = clientId;            
            VendedorId = vendedorId;            
            StatusVenda = Status.Iniciado;
            Produtos = [];
        }

        [Description("Numero do Cliente")]
        public int ClientId { get; set; }
        public Client Cliente { get; set; }

        [Description("Numero do Vendedor")]
        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
        [Description("Status da Venda")]
        public Status StatusVenda { get; set; }
        [Description("Produtos")]
        public List<Produto> Produtos { get; set; }

        public void Cancelado()
        {
            if(StatusVenda != Status.Iniciado || StatusVenda != Status.Congelado)
            {
                StatusVenda = Status.Cancelado;
                UpdatedAt = DateTime.UtcNow;
            }
        }

        public void Finalizado()
        {
            if (StatusVenda != Status.PagamentoPendente && StatusVenda != Status.Congelado && StatusVenda != Status.Cancelado)
            {
                StatusVenda = Status.Finalizado;
                UpdatedAt = DateTime.UtcNow;
            }
        }

        public void PagamentoPendente()
        {
            if (StatusVenda != Status.Iniciado || StatusVenda != Status.Finalizado)
            {
                StatusVenda = Status.PagamentoPendente;
                UpdatedAt = DateTime.UtcNow;
            }
        }

        public void UpdatePedido( int clientId, int vendedorId)
        {
            ClientId = clientId;
            VendedorId = vendedorId;            
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
