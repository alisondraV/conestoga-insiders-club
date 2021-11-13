using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConestogaInsidersClub.Data.Configurations
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.Property(e => e.CardNumber)
                    .HasMaxLength(16);

            builder.Property(e => e.UserId)
                .HasMaxLength(450);

            builder.HasOne(e => e.User)
                .WithMany(u => u.Cards)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
