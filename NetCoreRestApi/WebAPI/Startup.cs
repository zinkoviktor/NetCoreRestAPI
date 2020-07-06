using BusinessLayer.Interfaces;
using BusinessLayer.Managers;
using Common.Converter;
using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceLayer.Converters;
using ServiceLayer.DataTransferObjects;

namespace WebAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IManager<ProductModel<int>>, ProductManager<int>>();
            services.AddTransient<IManager<CategoryModel<int>>, CategoryManager<int>>();
            services.AddTransient<IConverter<ProductDto<int>, ProductModel<int>>, ProductServiceConverter<int>>();           
            services.AddTransient<IConverter<CategoryDto<int>, CategoryModel<int>>, CategoryServiceConverter<int>>();
            services.AddTransient<IRepository<CategoryModel<int>, int>, CategoryRepository<int>>();
            services.AddTransient<IRepository<ProductModel<int>, int>, ProductRepository<int>>();
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
