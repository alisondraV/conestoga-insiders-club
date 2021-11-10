using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConestogaInsidersClub.Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(e => e.Address1).IsUnicode(false);
            builder.Property(e => e.Address2).IsUnicode(false);
            builder.Property(e => e.City).IsUnicode(false);
            builder.Property(e => e.Country).IsUnicode(false);
            builder.Property(e => e.PostalCode).IsUnicode(false);
            builder.Property(e => e.Province).IsUnicode(false);
        }
    }
}
