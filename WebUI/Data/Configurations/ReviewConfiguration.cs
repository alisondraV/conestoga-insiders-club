using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConestogaInsidersClub.Data.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(e => new { e.UserId, e.GameId });

            builder.Property(e => e.UserId)
                .HasMaxLength(450);

            builder.Property(e => e.Description)
                .HasMaxLength(512);

            builder.HasOne(d => d.Game)
                .WithMany(p => p.Reviews)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.User)
                .WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
