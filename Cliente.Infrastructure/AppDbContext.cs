using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Cliente.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Client> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=crudsolid.db");
        }
    }
}
