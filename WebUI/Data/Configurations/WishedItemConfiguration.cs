using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConestogaInsidersClub.Data.Configurations
{
    public class WishedItemConfiguration : IEntityTypeConfiguration<WishedItem>
    {
        public void Configure(EntityTypeBuilder<WishedItem> builder)
        {
            builder.HasKey(e => new { e.UserId, e.GameId });

            builder.Property(e => e.UserId)
                .HasMaxLength(450)
                .IsUnicode(true);

            builder.HasOne(d => d.Game)
                .WithMany(p => p.WishedItems)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.User)
                .WithMany(p => p.WishedItems)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
