using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inventory.Infrastructure;
using Inventory.Domain.Aggregates.Items;
using Inventory.Infrastructure.Repositories;
using Inventory.Application.item;
using Mapster;
using Inventory.API.Shared;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomControllers(this IServiceCollection services)
        {
            services.AddControllers();
            return services;
        }

        public static IServiceCollection AddInventoryDbContext(this IServiceCollection services)
        {
            services.AddDbContext<InventoryContext>(options => options.UseInMemoryDatabase(databaseName: "Inventory"));
            return services;
        }

        public static IServiceCollection AddItemDependencies(this IServiceCollection services)
        {
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IAddItemUseCase, AddItemUseCase>();
            services.AddScoped<IRemoveItemUseCase, RemoveItemUseCase>();
            return services;
        }

        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            Assembly applicationAssembly = typeof(MapeableDto<,>).Assembly;

            var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
            typeAdapterConfig.Scan(applicationAssembly);
            return services;
        }


    }
}
