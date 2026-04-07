using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Domain.Models;

namespace Cliente.Application.Model
{
    public class CreateItemPedidoInputModel
    {
        [Required]
        public int ProdutoId { get; set; }

        public int PedidoId { get; private set; }

        public int Quantidade { get; set; }

        public decimal ValorUnitario { get; set; }

        public ItemPedido ToEntityItemPedido()
            => new ItemPedido(ProdutoId,Quantidade, ValorUnitario);
    }
}

