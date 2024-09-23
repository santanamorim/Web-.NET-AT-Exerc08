using Microsoft.EntityFrameworkCore;
using Web_.NET_AT_Exerc08.Models;

namespace Web_.NET_AT_Exerc08.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=WebNETATExerc08.db");
        }
    }
}
