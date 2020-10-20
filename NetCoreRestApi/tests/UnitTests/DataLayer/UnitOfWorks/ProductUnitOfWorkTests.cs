using BusinessLayer.Managers;
using DataLayer.EF;
using DataLayer.EF.Entities;
using DataLayer.Models;
using DataLayer.Repositories.Intefaces;
using DataLayer.UnitOfWorks;
using DataLayer.UnitOfWorks.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTests.Helpers;

namespace UnitTests.DataLayer.UnitOfWorks
{
    [TestClass]
    public class ProductUnitOfWorkTests : BaseTest
    {
        private IProductUnitOfWork UnitOfWork { get; set; }        

        [TestInitialize]
        public void TestInitialize()
        {
            //var products = new List<ProductEntity>()
            //{
            //    new ProductEntity()
            //    {
            //        Id = 1,
            //        Name = "HP 410",
            //        Description = "All-in-One Wireless Ink Tank Color Printer",
            //        Price = 90,
            //        AvailableCount = 9,
            //        ProductCategoryEntities = new List<ProductCategoryEntity>()
            //    },
            //    new ProductEntity()
            //    {
            //        Id = 2,
            //        Name = "Epson L3152",
            //        Description = "WiFi All in One Ink Tank Printer",
            //        Price = 60,
            //        AvailableCount = 19,
            //        ProductCategoryEntities = new List<ProductCategoryEntity>()
            //    }
            //};

            //var categories = new List<CategoryEntity>()
            //{
            //    new CategoryEntity()
            //    {
            //        Id = 1,
            //        Name = "Laptops",
            //        Description = "Shop Laptops and find popular brands. Save money.",
            //        ProductCategoryEntities = new List<ProductCategoryEntity>()
            //    },
            //    new CategoryEntity()
            //    {
            //        Id = 2,
            //        Name = "Printers",
            //        Description = "The Best Printers for 2020.",
            //        ProductCategoryEntities = new List<ProductCategoryEntity>()
            //    },
            //    new CategoryEntity()
            //    {
            //        Id = 3,
            //        Name = "Sale",
            //        Description = "Shop all sale items",
            //        ProductCategoryEntities = new List<ProductCategoryEntity>()
            //    }
            //};

            //var mock = new Mock<IDbContext>();

            //var productsDbSet = DbSetMockHelper.GetQueryableMockDbSet(products);
            //var categoriesDbSet = DbSetMockHelper.GetQueryableMockDbSet(categories);

            //mock.Setup(d => d.GetDbSet<ProductEntity>()).Returns(productsDbSet);
            //mock.Setup(d => d.GetDbSet<CategoryEntity>()).Returns(categoriesDbSet);

            Services.AddSingleton<ProductsDbContext>()
                    .AddSingleton<IUnitOfWorkContext>(x => x.GetRequiredService<ProductsDbContext>())
                    .AddSingleton<IDbContext>(x => x.GetRequiredService<ProductsDbContext>())
                    .AddDbContext<ProductsDbContext>(opt => opt.UseInMemoryDatabase(databaseName: 
                        Guid.NewGuid().ToString()),ServiceLifetime.Scoped, ServiceLifetime.Scoped);

            ConfigureServices();

            UnitOfWork = ServiceProvider.GetRequiredService<IProductUnitOfWork>();               
        }

        [TestMethod]
        public void test()
        {
            // Arrange
            var products = new List<ProductModel>()
            {
                new ProductModel()
                {
                    Id = 1,
                    Name = "HP 410",
                    Description = "All-in-One Wireless Ink Tank Color Printer",
                    Price = 90,
                    AvailableCount = 9                    
                },
                new ProductModel()
                {
                    Id = 2,
                    Name = "Epson L3152",
                    Description = "WiFi All in One Ink Tank Printer",
                    Price = 60,
                    AvailableCount = 19                    
                }
            };

            // Act
            var result = UnitOfWork.Create(products.AsEnumerable());
            UnitOfWork.Save();
            var all = UnitOfWork.GetAll();
            var x = UnitOfWork.GetById(2);
            products.First().Name = "New name";
            products.Last().Name = " ";
            UnitOfWork.Update(products.AsEnumerable());
            UnitOfWork.Save();
            all = UnitOfWork.GetAll();

            UnitOfWork.Delete(products.AsEnumerable());
            UnitOfWork.Save();
            all = UnitOfWork.GetAll();

            // Assert            

        }
    }
}
