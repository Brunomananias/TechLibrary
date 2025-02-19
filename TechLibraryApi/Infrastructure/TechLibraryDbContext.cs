using Microsoft.EntityFrameworkCore;
using TechLibraryApi.Domain.Entities;
namespace TechLibraryApi.Infrastructure

{
    public class TechLibraryDbContext : DbContext
    {       
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\Bruno Ananias\\Downloads\\TechLibraryDb.db");
        }
    }
}
