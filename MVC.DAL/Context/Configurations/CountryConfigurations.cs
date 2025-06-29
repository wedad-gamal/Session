using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVC.DAL.Context.Configurations
{
    class CountryConfigurations : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasMany(c => c.Cities)
                .WithOne(c => c.Country)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
