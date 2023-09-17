using Microsoft.EntityFrameworkCore;

namespace KitaplikProje.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-PKFQ0FE\\SQLEXPRESS;database=KitaplikProje;integrated security=true;TrustServerCertificate=True");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
