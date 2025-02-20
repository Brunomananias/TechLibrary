using Microsoft.EntityFrameworkCore;
using TechLibraryApi.Domain.Entities;
namespace TechLibraryApi.Infrastructure.DataAccess

{
    public class TechLibraryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\Bruno Ananias\\Downloads\\TechLibraryDb.db");
        }
    }
}
