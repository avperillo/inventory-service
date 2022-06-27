using FluentValidation.AspNetCore;
using Inventory.API;
using Inventory.API.Infrastructure.Filters;
using Inventory.API.Shared;
using Inventory.Application.item;
using Inventory.Domain.Aggregates.Items;
using Inventory.Infrastructure;
using Inventory.Infrastructure.Repositories;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomControllers(this IServiceCollection services)
        {
            services
                .AddControllers(options =>
                {
                    options.Filters.Add(typeof(HttpGlobalExceptionFilter));
                })
                .AddNewtonsoftJson()
                .AddFluentValidation(options =>
                {
                    options.RegisterValidatorsFromAssemblyContaining<Startup>();
                }
                );
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
