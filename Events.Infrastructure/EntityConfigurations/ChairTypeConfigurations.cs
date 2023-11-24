

using Events.Domain.Entities;
using Events.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.EntityConfigurations
{
    public class ChairTypeConfigurations : IBaseEntityConfiguration, IEntityTypeConfiguration<ChairType>
    {
        public void Configure(EntityTypeBuilder<ChairType> builder)
        {
            builder.ToTable("ChairTypes", "Lookups");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
        }
    }
}
