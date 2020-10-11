using BusinessLayer.Managers;
using Common.Converter;
using DataLayer.EF;
using DataLayer.EF.Converters;
using DataLayer.EF.Entities;
using DataLayer.EF.Repositories;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.UnitOfWorks;
using DataLayer.UnitOfWorks.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.Converters;
using ServiceLayer.DataTransferObjects;
using System;

namespace UnitTests
{
    public abstract class BaseTest
    {
        public TestContext TestContext { get; set; }

        public IServiceProvider ServiceProvider { get; set; }
        private ServiceCollection _services;

        public BaseTest()
        {
            InitializeBaseServices();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            
        }

        public void ConfigureServices()
        {
            ServiceProvider = _services.BuildServiceProvider();

        }

        private void InitializeBaseServices()
        {
            _services = new ServiceCollection();
            _services.AddTransient<IProductManager, ProductManager>()
                    .AddTransient<ICategoryManager, CategoryManager>()
                    .AddTransient<IConverter<ProductDto, ProductModel>, ProductServiceConverter>()
                    .AddTransient<IConverter<CategoryDto, CategoryModel>, CategoryServiceConverter>()
                    .AddTransient<IConverter<ProductEntity, ProductModel>, ProductModelConverter>()
                    .AddTransient<IConverter<CategoryEntity, CategoryModel>, CategoryModelConverter>()
                    .AddTransient<IProductUnitOfWork, ProductUnitOfWork>()
                    .AddTransient<ICategoryUnitOfWork, CategoryUnitOfWork>()
                    .AddTransient<IProductRepository, ProductRepository>()
                    .AddTransient<ICategoryRepository, CategoryRepository>();                      
        }

        public void InjectService<InternalService>(InternalService implementation) where InternalService : class
        {
            _services.AddTransient(p => {
                return implementation;
            });
        }

        public void UseInMemoryDatabase()
        {
            _services.AddEntityFrameworkInMemoryDatabase();
        }
    }
}
