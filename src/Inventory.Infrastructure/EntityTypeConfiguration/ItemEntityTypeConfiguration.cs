using DDD.abstracts;
using Inventory.Domain.Aggregates.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.EntityTypeConfiguration
{
    class ItemEntityTypeConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder.Property(b => b.ExpirationDate);
            builder.Property(b => b.Type)
                .HasConversion(
                v => v.Id,
                v => Enumeration.FromValue<ItemType>(v));

        }
    }
}
