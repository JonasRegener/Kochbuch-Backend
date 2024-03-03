using Microsoft.EntityFrameworkCore;

namespace Kochbuch_Backend.Data
{
    public class KochbuchDbContext : DbContext
    {

        public KochbuchDbContext(DbContextOptions options): base(options) 
        {

        }

        public DbSet<Reciepe> Reciepes { get; set; }    

        public DbSet<Ingredient> Ingredients { get; set; }  
    }
}
