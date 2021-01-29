using BusinessLayer.Managers;
using DataLayer.EF;
using DataLayer.EF.Entities;
using DataLayer.Models;
using DataLayer.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTests.Helpers.ProductHelpers;

namespace UnitTests.BusinessLayer.Managers
{
    [TestClass]
    public class ProductManagerTests : BaseTest
    {
        private IDbContext DbContext { get; set; }
        private IProductManager ProductManager { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            Services.AddSingleton<ProductsDbContext>()
                    .AddSingleton<IUnitOfWorkContext>(sp => sp.GetRequiredService<ProductsDbContext>())
                    .AddSingleton<IDbContext>(sp => sp.GetRequiredService<ProductsDbContext>())
                    .AddDbContext<ProductsDbContext>(opt => opt.UseInMemoryDatabase(
                        databaseName: Guid.NewGuid().ToString()), ServiceLifetime.Singleton, ServiceLifetime.Singleton);

            ConfigureServices();

            ProductManager = ServiceProvider.GetRequiredService<IProductManager>();
            DbContext = ServiceProvider.GetRequiredService<IDbContext>();
        }

        [TestMethod]
        public void ProductManager_GetAll_ReturnListOfProductModels()
        {
            // Arrange
            var entities = new List<ProductEntity>()
            {
                new ProductEntity()
                {
                    Id = 1,
                    Name = "First",
                    ProductCategoryEntities = new List<ProductCategoryEntity>()
                },
                new ProductEntity()
                {
                    Id = 2,
                    Name = "Second",
                    ProductCategoryEntities = new List<ProductCategoryEntity>()
                }
            };
            DbContext.GetDbSet<ProductEntity>().AddRange(entities);
            DbContext.Save();

            var productModelsList = new List<ProductModel>()
            {
                new ProductModel()
                {
                    Id = 1,
                    Name = "First"
                },
                new ProductModel()
                {
                    Id = 2,
                    Name = "Second"
                }
            };
            var expected = productModelsList;

            // Act
            var actual = ProductManager.GetAll(null)?.ToList();

            // Assert            
            Assert.IsTrue(ProductModelComparer.Instance.AreEquals(expected, actual));
        }

        [TestMethod]
        public void ProductManager_Create_ReturnListOfCreatedProductModels()
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
            ProductManager.Create(products.AsEnumerable());
            var actual = DbContext.GetDbSet<ProductEntity>().ToList();

            // Assert     
            Assert.IsTrue(ProductEntityComparer.Instance.AreEquals(expected, actual));
        }

        [TestMethod]
        public void Update_ProductEntity()
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

            DbContext.GetDbSet<ProductEntity>().AddRange(products);
            DbContext.Save();

            var productsForUpdate = new List<ProductModel>()
            {
                new ProductModel()
                {
                    Id = 1,
                    Name = "HP 410",
                    Description = "",
                    Price = 50,
                    AvailableCount = 9
                },
                new ProductModel()
                {
                    Id = 2,
                    Name = "Epson L3152",
                    Description = "WiFi All in One Ink Tank Printer",
                    Price = 50,
                    AvailableCount = 19
                }
            };

            // Act
            ProductManager.Update(productsForUpdate);
            var actualProducs = DbContext.GetDbSet<ProductEntity>().ToList();
            var actual = actualProducs.FirstOrDefault(p => p.Id == 1).Description;
            var expected = productsForUpdate.FirstOrDefault(p => p.Id == 1).Description;

            // Assert     
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Delete_ProductEntity()
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

            DbContext.GetDbSet<ProductEntity>().AddRange(products);
            DbContext.Save();

            var productsForUpdate = new List<ProductModel>()
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
            ProductManager.Delete(productsForUpdate);
            var actual = DbContext.GetDbSet<ProductEntity>().ToList();

            // Assert     
            Assert.IsTrue(actual.Count == 0);
        }

        [TestMethod]
        public void Create_ProductCategoryEntitiesFieldTest()
        {
            // Arrange
            var categoryName1 = "Category Name 1";
            var categoryName2 = "Category Name 2";

            var products = new List<ProductModel>()
            {
                new ProductModel()
                {
                    Id = 1,
                    Name = "HP 410",
                    Description = "All-in-One Wireless Ink Tank Color Printer",
                    Price = 90,
                    AvailableCount = 9,
                    CategoryList = new List<CategoryModel>()
                    {
                        new CategoryModel()
                        {
                            Name = categoryName1
                        },
                        new CategoryModel()
                        {
                            Name = categoryName2
                        }
                    }
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
            ProductManager.Create(products.AsEnumerable());

            var createdProducts = DbContext.GetDbSet<ProductEntity>().ToList();
            var productCategoryEntities = createdProducts.First(p => p.Id == 1).ProductCategoryEntities;
            var createdCategories = from pc in productCategoryEntities
                                    select pc.Category;

            var productCategoryEntity = productCategoryEntities.First(pc => pc.Category.Name == categoryName1);

            // Assert   
            Assert.IsTrue(createdCategories.Count() == 2);
            Assert.AreEqual(productCategoryEntity.CategoryId, productCategoryEntity.Category.Id);
            Assert.AreEqual(productCategoryEntity.ProductId, productCategoryEntity.Product.Id);
        }
    }
}
