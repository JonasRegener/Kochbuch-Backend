using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kochbuch_Backend.Data
{
    public class KochbuchDbContext : IdentityDbContext<User>
    {

        public KochbuchDbContext(DbContextOptions options): base(options) 
        {

        }

        public DbSet<Reciepe> Reciepes { get; set; }    

        public DbSet<Ingredient> Ingredients { get; set; }

    }
}
