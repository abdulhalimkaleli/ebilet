using ebilet.Model.ORM;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ebilet.Context
{
    public class Mycontext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-SLTQKDI\\MSSQLSERVER02; Database=EventDb; Trusted_Connection=True");
        }
         
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event>Events { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Place> Places { get; set; } 
        

    }
}
