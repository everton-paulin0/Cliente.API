using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Cliente.Infrastructure
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseSqlServer(
                "Data Source=DESKTOP-RME3DV4\\SQLEXPRESS;Initial Catalog=ClienteDb;Integrated Security=True;Trust Server Certificate=True"
            );

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
