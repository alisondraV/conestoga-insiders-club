using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConestogaInsidersClub.Data.Configurations
{
    public class FriendshipConfiguration : IEntityTypeConfiguration<Friendship>
    {
        public void Configure(EntityTypeBuilder<Friendship> builder)
        {
            builder.HasKey(e => new { e.UserId1, e.UserId2 });

            builder.Property(e => e.UserId1).HasMaxLength(450);

            builder.Property(e => e.UserId2).HasMaxLength(450);

            builder.HasOne(d => d.User1)
                .WithMany()
                .HasForeignKey(d => d.UserId1)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.User2)
                .WithMany()
                .HasForeignKey(d => d.UserId2)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
