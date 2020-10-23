using DataLayer.EF;
using DataLayer.EF.Entities;
using DataLayer.Models;
using DataLayer.Repositories.Intefaces;
using DataLayer.UnitOfWorks.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTests.Helpers.ProductHelpers;

namespace UnitTests.DataLayer.UnitOfWorks
{
    [TestClass]
    public class ProductUnitOfWorkTests : BaseTest
    {
        private IProductUnitOfWork UnitOfWork { get; set; }  
        private IDbContext DbContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {           
            Services.AddSingleton<ProductsDbContext>()
                    .AddSingleton<IUnitOfWorkContext>(x => x.GetRequiredService<ProductsDbContext>())
                    .AddSingleton<IDbContext>(x => x.GetRequiredService<ProductsDbContext>())
                    .AddDbContext<ProductsDbContext>(opt => opt.UseInMemoryDatabase(databaseName: 
                        Guid.NewGuid().ToString()),ServiceLifetime.Scoped, ServiceLifetime.Scoped);

            ConfigureServices();

            UnitOfWork = ServiceProvider.GetRequiredService<IProductUnitOfWork>();
            DbContext = ServiceProvider.GetRequiredService<IDbContext>();
        }

        [TestMethod]
        public void Create_ProductEntity()
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
            var expected = new List<ProductEntity>()
            {
                new ProductEntity()
                {
                    Id = 1,
                    Name = "HP 410",
                    Description = "All-in-One Wireless Ink Tank Color Printer",
                    Price = 90,
                    AvailableCount = 9,
                    ProductCategoryEntities = new List<ProductCategoryEntity>()

                },
                new ProductEntity()
                {
                    Id = 2,
                    Name = "Epson L3152",
                    Description = "WiFi All in One Ink Tank Printer",
                    Price = 60,
                    AvailableCount = 19,
                    ProductCategoryEntities = new List<ProductCategoryEntity>()
                }
            };

            // Act
            UnitOfWork.Create(products.AsEnumerable());
            UnitOfWork.Save();
            var actual = DbContext.GetDbSet<ProductEntity>().ToList();

            // Assert     
            Assert.IsTrue(ProductEntityComparer.Instance.AreEquals(expected, actual));
        }

        [TestMethod]
        public void GetById_ProductEntity()
        {
            // Arrange
            var products = new List<ProductEntity>()
            {
                new ProductEntity()
                {
                    Id = 1,
                    Name = "HP 410",
                    Description = "All-in-One Wireless Ink Tank Color Printer",
                    Price = 90,
                    AvailableCount = 9,
                    ProductCategoryEntities = new List<ProductCategoryEntity>()
                },
                new ProductEntity()
                {
                    Id = 2,
                    Name = "Epson L3152",
                    Description = "WiFi All in One Ink Tank Printer",
                    Price = 60,
                    AvailableCount = 19,
                    ProductCategoryEntities = new List<ProductCategoryEntity>()
                }
            };
            var expected = new ProductModel()
            {
                Id = 1,
                Name = "HP 410",
                Description = "All-in-One Wireless Ink Tank Color Printer",
                Price = 90,
                AvailableCount = 9
            };

            // Act
            DbContext.GetDbSet<ProductEntity>().AddRange(products);
            DbContext.Save();
            var actual = UnitOfWork.GetById(expected.Id);

            // Assert     
            Assert.IsTrue(ProductModelComparer.Instance.AreEquals(expected, actual));
        }
    }
}
