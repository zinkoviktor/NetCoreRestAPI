using BusinessLayer.Managers;
using Common.Converter;
using DataLayer.EF;
using DataLayer.EF.Converters;
using DataLayer.EF.Entities;
using DataLayer.EF.Repositories;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.Repositories.Intefaces;
using DataLayer.UnitOfWorks;
using DataLayer.UnitOfWorks.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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
            services.AddTransient<IProductManager, ProductManager>();
            services.AddTransient<ICategoryManager, CategoryManager>();
            services.AddTransient<IConverter<ProductDto, ProductModel>, ProductServiceConverter>();           
            services.AddTransient<IConverter<CategoryDto, CategoryModel>, CategoryServiceConverter>();
            services.AddTransient<IConverter<ProductEntity, ProductModel>, ProductModelConverter>();
            services.AddTransient<IConverter<CategoryEntity, CategoryModel>, CategoryModelConverter>();
            services.AddTransient<ICategoryUnitOfWork, CategoryUnitOfWork>();
            services.AddTransient<IProductUnitOfWork, ProductUnitOfWork>();
            services.AddTransient<IConverter<CategoryEntity, CategoryModel>, CategoryModelConverter>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUnitOfWorkDbContext, ProductsDbContext>();
            services.AddTransient<IDbContext, ProductsDbContext>();
            services.AddDbContext<ProductsDbContext>(opt => opt.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()), ServiceLifetime.Transient, ServiceLifetime.Transient);
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
