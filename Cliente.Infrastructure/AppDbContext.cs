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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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

            });

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

                e.HasMany(c => c.Pedidos)
                 .WithOne(p => p.Cliente)
                 .HasForeignKey(p => p.ClientId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Produto>(e =>
            {
                e.HasKey(p => p.Id);

                e.Property(p => p.NomeProduto)
                 .IsRequired()
                 .HasMaxLength(100);

                e.Property(p => p.Quantidade)
                 .IsRequired();

                e.Property(p => p.ValorUnitario)
                 .HasPrecision(18, 2)
                 .IsRequired();
            });

            builder.Entity<Vendedor>(e =>
            {
                e.HasKey(v => v.Id);

                e.Property(v => v.NomeVendedor)
                 .IsRequired()
                 .HasMaxLength(100);

                e.Property(v => v.Numero)
                 .HasConversion<int>()
                 .IsRequired();

                e.HasMany(v => v.Pedidos)
                 .WithOne(p => p.Vendedor)
                 .HasForeignKey(p => p.VendedorId)
                 .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
