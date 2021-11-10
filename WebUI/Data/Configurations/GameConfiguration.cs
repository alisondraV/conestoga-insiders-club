using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConestogaInsidersClub.Data.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.Property(e => e.GameId);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.GenreName)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.HasOne(d => d.Genre)
                .WithMany(p => p.Games)
                .HasForeignKey(d => d.GenreName)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
