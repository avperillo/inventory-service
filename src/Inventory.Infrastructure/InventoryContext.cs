using DDD.abstracts;
using Inventory.Domain.Aggregates.Items;
using Inventory.Infrastructure.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Infrastructure
{

    public class InventoryContext : DbContext, IUnitOfWork
    {
        public DbSet<Item> Items { get; set; }

        public InventoryContext(DbContextOptions<InventoryContext> options)
       : base(options) { }

        protected override void OnModelCreating (ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ItemEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            _ = await base.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
