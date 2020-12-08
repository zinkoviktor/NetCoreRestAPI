using BusinessLayer.Managers;
using Common.Converter;
using DataLayer.EF;
using DataLayer.EF.Converters;
using DataLayer.EF.Entities;
using DataLayer.EF.Repositories;
using DataLayer.interfaces;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.Repositories.Intefaces;
using DataLayer.UnitOfWorks;
using DataLayer.UnitOfWorks.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceLayer.Converters;
using ServiceLayer.DataTransferObjects;
using System;

namespace WebAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IProductManager, ProductManager>()
                    .AddTransient<ICategoryManager, CategoryManager>()
                    .AddTransient<IConverter<ProductDto, ProductModel>, ProductServiceConverter>()
                    .AddTransient<IConverter<CategoryDto, CategoryModel>, CategoryServiceConverter>()
                    .AddTransient<IConverter<ProductEntity, ProductModel>, ProductModelConverter>()
                    .AddTransient<IConverter<CategoryEntity, CategoryModel>, CategoryModelConverter>()
                    .AddTransient<IProductUnitOfWork, ProductUnitOfWork>()
                    .AddTransient<ICategoryUnitOfWork, CategoryUnitOfWork>()
                    .AddTransient<IProductRepository, ProductRepository>()
                    .AddTransient<ICategoryRepository, CategoryRepository>()
                    .AddTransient<IUnitOfWorkContext, ProductMockDbContext>()
                    .AddTransient<IDbContext, ProductMockDbContext>()
                    .AddTransient<DbContext, ProductMockDbContext>()
                    .AddTransient<ITransactionManager, EfTransactionManagerMock>()
                    .AddDbContext<ProductMockDbContext>(opt => opt.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                        .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)), ServiceLifetime.Transient, ServiceLifetime.Transient);
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
                endpoints.MapControllers();
            });
        }
    }
}
