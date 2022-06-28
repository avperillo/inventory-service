using EventBus;
using EventBus.Contracts;
using Inventory.Application.item;
using Inventory.Domain.Aggregates.Items;
using Inventory.Infrastructure;
using Inventory.Infrastructure.Repositories;
using Inventory.Worker.Jobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Inventory.Worker
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<CheckExpirationItemJob>();

            services.AddDbContext<InventoryContext>(options => options.UseInMemoryDatabase(databaseName: "Inventory"));
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemExpiredCheckerUseCase, ItemExpiredCheckerUseCase>();
            services.AddScoped<IEventBus, FakeEventBus>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
