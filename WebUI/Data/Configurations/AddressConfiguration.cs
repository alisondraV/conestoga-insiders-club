using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConestogaInsidersClub.Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(e => e.Address1).HasMaxLength(50);

            builder.Property(e => e.Address2).HasMaxLength(25);

            builder.Property(e => e.PostalCode).HasMaxLength(10);

            builder.Property(e => e.City).HasMaxLength(50);

            builder.Property(e => e.Province).HasMaxLength(2);

            builder.Property(e => e.Country).HasMaxLength(50);
        }
    }
}
