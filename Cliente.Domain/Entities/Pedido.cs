using Cliente.Domain.Models.Enum;

namespace Cliente.Domain.Models
{
    public class Pedido : BaseEntities
    {
        public Pedido(int clientId, int vendedorId, Status statusVenda) : base()
        {
            ClientId = clientId;
            VendedorId = vendedorId;
            StatusVenda = statusVenda;
            Produtos = new List<Produto>();
        }

        public int ClientId { get; set; }
        public Client Cliente { get; set; }

        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }

        public Status StatusVenda { get; set; }

        public List<Produto> Produtos { get; set; }

        // ===== Métodos de domínio =====

        public void Cancelado()
        {
            if (StatusVenda == Status.Iniciado || StatusVenda == Status.Congelado)
            {
                StatusVenda = Status.Cancelado;
                UpdatedAt = DateTime.UtcNow;
            }
        }

        public void Finalizado()
        {
            if (StatusVenda == Status.PagamentoPendente)
            {
                StatusVenda = Status.Finalizado;
                UpdatedAt = DateTime.UtcNow;
            }
        }

        public void PendentePagamento()
        {
            if (StatusVenda == Status.Iniciado || StatusVenda == Status.Finalizado)
            {
                StatusVenda = Status.PagamentoPendente;
                UpdatedAt = DateTime.UtcNow;
            }
        }

        public void UpdatePedido(int clientId, int vendedorId, Status statusVenda, List<Produto> produtos)
        {
            ClientId = clientId;
            VendedorId = vendedorId;
            StatusVenda = statusVenda;
            Produtos = produtos;

            UpdatedAt = DateTime.UtcNow;
        }


    }
}

