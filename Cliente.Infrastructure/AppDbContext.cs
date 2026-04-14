using Cliente.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Cliente.Infrastructure
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
            {
            }

            public DbSet<Client> Clientes { get; set; }
            public DbSet<Produto> Produtos { get; set; }
            public DbSet<Vendedor> Vendedores { get; set; }
            public DbSet<Pedido> Pedidos { get; set; }
            public DbSet<ItemPedido> ItemPedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // =========================
            // PEDIDO
            // =========================
            builder.Entity<Pedido>(e =>
            {
                e.HasKey(m => m.Id);

                e.HasOne(m => m.Cliente)
                 .WithMany(c => c.Pedidos)
                 .HasForeignKey(m => m.ClientId)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(m => m.Vendedor)
                 .WithMany(v => v.Pedidos)
                 .HasForeignKey(m => m.VendedorId)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasMany(p => p.Itens)
                  .WithOne(i => i.Pedido)
                  .HasForeignKey(i => i.PedidoId)
                  .OnDelete(DeleteBehavior.Cascade);
            });

            
                

            // =========================
            // CLIENT
            // =========================
            builder.Entity<Client>(e =>
            {
                e.HasKey(c => c.Id);

                e.Property(c => c.NomeCliente)
                 .IsRequired()
                 .HasMaxLength(100);

                e.Property(c => c.NumeroDocumento)
                 .IsRequired()
                 .HasMaxLength(20);

                e.Property(c => c.Endereco)
                 .IsRequired()
                 .HasMaxLength(150);

                e.Property(c => c.Numero)
                 .IsRequired();

                e.Property(c => c.Complemento)
                 .HasMaxLength(50);

                e.Property(c => c.Cidade)
                 .IsRequired()
                 .HasMaxLength(50);

                e.Property(c => c.Estado)
                 .HasConversion<int>()
                 .IsRequired();
            });

            // =========================
            // PRODUTO
            // =========================
            builder.Entity<Produto>(e =>
            {
                e.HasKey(p => p.Id);

                e.Property(p => p.NomeProduto)
                 .IsRequired()
                 .HasMaxLength(100);

                e.Property(p => p.MarcaProduto)
                 .IsRequired()
                 .HasMaxLength(100);

                e.Property(p => p.Quantidade)
                 .IsRequired();

                e.Property(p => p.ValorUnitario)
                 .HasPrecision(18, 2)
                 .IsRequired();
            });

            // =========================
            // VENDEDOR
            // =========================
            builder.Entity<Vendedor>(e =>
            {
                e.HasKey(v => v.Id);

                e.Property(v => v.NomeVendedor)
                 .IsRequired()
                 .HasMaxLength(100);

                e.HasMany(v => v.Pedidos)
                 .WithOne(p => p.Vendedor)
                 .HasForeignKey(p => p.VendedorId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // =========================
            // ITEM PEDIDO (🔥 IMPORTANTE)
            // =========================
            builder.Entity<ItemPedido>(e =>
            {
                e.HasKey(i => i.Id);

                e.Property(i => i.ValorUnitario)
                 .HasPrecision(18, 2)
                 .IsRequired();

                e.HasOne(i => i.Pedido)
                 .WithMany(p => p.Itens)
                 .HasForeignKey(i => i.PedidoId)
                 .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(i => i.Produto)
                 .WithMany()
                 .HasForeignKey(i => i.ProdutoId)
                 .OnDelete(DeleteBehavior.Restrict);
            });
        }

    }

}
