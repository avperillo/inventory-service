using DDD.abstracts;
using Inventory.Domain.Aggregates.Items;
using Inventory.Infrastructure.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Infrastructure
{

    public class InventoryContext : DbContext, IUnitOfWork
    {
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating (ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ItemEntityTypeConfiguration());
        }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
