using Kochbuch_Backend.Data.Configurations;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());

        
        }

    }
}
