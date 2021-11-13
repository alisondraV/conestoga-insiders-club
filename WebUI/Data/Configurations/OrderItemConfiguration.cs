using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConestogaInsidersClub.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(e => new { e.OrderId, e.GameId });

            builder.Property(e => e.Quantity).HasDefaultValueSql("((1))");

            builder.HasOne(d => d.Game)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.Order)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
