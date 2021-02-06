using HamVarzeshi.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace HamVarzeshi.EntityFrameworkCore.EntityFrameworkCore.Mapping
{
    public class ClubMapping : IEntityTypeConfiguration<Club>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Club> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(x => x.Description)
                .IsRequired();

            builder.Property(x => x.CostPerHour)
                .IsRequired();

            builder.Property(x => x.Rate)
                .IsRequired();
        }
    }
}