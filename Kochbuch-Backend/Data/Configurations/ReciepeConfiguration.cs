using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kochbuch_Backend.Data.Configurations
{
    public class ReciepeConfiguration : IEntityTypeConfiguration<Reciepe>
    {
        public void Configure(EntityTypeBuilder<Reciepe> builder)
        {
            builder.HasData(
                new Reciepe
                {
                    Name = "Tortellini Käse Sahne",
                    Description = "Mega nice und mega lecker",
                    DurationMinutes = 5,
                },
                new Reciepe
                {
                    Name = "Nudeln Pesto",
                    Description = "Mega einfach",
                    DurationMinutes = 12,
                }
                );
        }
    }
}
