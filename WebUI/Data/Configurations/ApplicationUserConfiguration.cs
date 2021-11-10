using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConestogaInsidersClub.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(e => e.FirstName).HasMaxLength(50);

            builder.Property(e => e.LastName).HasMaxLength(50);
            
            builder.Property(e => e.Gender)
                    .HasConversion<int>();
            
            builder.HasOne(e => e.MailingAddress)
                .WithMany(a => a.MailingUsers)
                .HasForeignKey(u => u.MailingAddressId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasOne(e => e.ShippingAddress)
                .WithMany(a => a.ShippingUsers)
                .HasForeignKey(u => u.ShippingAddressId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
