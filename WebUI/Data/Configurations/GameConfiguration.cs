using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConestogaInsidersClub.Data.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.GenreName)
                .HasMaxLength(25);

            builder.HasOne(d => d.Genre)
                .WithMany(p => p.Games)
                .HasForeignKey(d => d.GenreName)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
