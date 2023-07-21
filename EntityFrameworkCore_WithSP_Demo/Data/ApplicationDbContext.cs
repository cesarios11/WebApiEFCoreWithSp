using EntityFrameworkCore_WithSP_Demo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkCore_WithSP_Demo.Data
{
    public class ApplicationDbContext :DbContext
    {
        protected readonly IConfiguration configuration;
        public ApplicationDbContext(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(this.configuration.GetConnectionString("ConexionSQLServer"));
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
    }
}
