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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.Converters;
using ServiceLayer.DataTransferObjects;
using System;

namespace UnitTests.WebApi.Controllers
{
    [TestClass]
    public abstract class BaseControllerTests
    {
        protected IServiceProvider ServiceProvider { get; set; }

       
        public BaseControllerTests()
        {
            var services = new ServiceCollection();
            
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
                    .AddDbContext<ProductMockDbContext>(opt => opt.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()),
                        ServiceLifetime.Transient, ServiceLifetime.Transient);

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
