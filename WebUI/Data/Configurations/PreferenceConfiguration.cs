using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConestogaInsidersClub.Data.Configurations
{
    public class PreferenceConfiguration : IEntityTypeConfiguration<Preference>
    {
        public void Configure(EntityTypeBuilder<Preference> builder)
        {
            builder.HasKey(e => e.UserId);

            builder.Property(e => e.UserId)
                .HasMaxLength(450);

            builder.Property(e => e.Platform)
                .HasMaxLength(50);

            builder.Property(e => e.Platform)
                .HasMaxLength(25);

            builder.HasOne(d => d.Genre)
                .WithMany(p => p.Preferences)
                .HasForeignKey(d => d.GenreName)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(d => d.FavouriteGame)
                .WithMany(g => g.Preferences)
                .HasForeignKey(d => d.FavouriteGameId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
