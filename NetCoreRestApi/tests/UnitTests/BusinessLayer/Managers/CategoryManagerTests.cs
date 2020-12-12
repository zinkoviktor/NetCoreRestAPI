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
using UnitTests.Helpers.CategoryHelpers;

namespace UnitTests.BusinessLayer.Managers
{
    [TestClass]
    public class CategoryManagerTests : BaseTest
    {
        private ICategoryManager CategoryManager { get; set; }
        private IDbContext DbContext { get; set; }
        private List<CategoryModel> _models;

        [TestInitialize]
        public void TestInitialize()
        {
            Services.AddSingleton<ProductMockDbContext>()
                    .AddSingleton<IUnitOfWorkContext>(sp => sp.GetRequiredService<ProductMockDbContext>())
                    .AddSingleton<IDbContext>(sp => sp.GetRequiredService<ProductMockDbContext>())
                    .AddDbContext<ProductMockDbContext>(opt => opt.UseInMemoryDatabase(
                        databaseName: Guid.NewGuid().ToString()), ServiceLifetime.Transient, ServiceLifetime.Transient);

            ConfigureServices();

            CategoryManager = ServiceProvider.GetRequiredService<ICategoryManager>();
            DbContext = ServiceProvider.GetRequiredService<IDbContext>();

            _models = new List<CategoryModel>()
            {
                new CategoryModel()
                {
                    Id = 1,
                    Name = "Laptops",
                    Description = "Shop Laptops and find popular brands. Save money."
                },
                new CategoryModel()
                {
                    Id = 2,
                    Name = "Printers",
                    Description = "The Best Printers for 2020."
                },
                new CategoryModel()
                {
                    Id = 3,
                    Name = "Sale",
                    Description = "Shop all sale items"
                }
            };
        }

        [TestMethod]
        public void GetAll_ReturnListOfCategoryModels()
        {
            // Arrange
            var expected = _models;

            // Act
            var actual = CategoryManager.GetAll(1, 3).ToList();

            // Assert            
            Assert.IsTrue(CategoryModelComparer.Instance.AreEquals(expected, actual));
        }

        [TestMethod]
        public void Create_CategoryEntity()
        {
            // Arrange
            var categories = new List<CategoryModel>()
            {
                new CategoryModel()
                {
                    Name = "New first",
                    Description = "Fdddd"
                },
                new CategoryModel()
                {
                    Name = "Epson 9000",
                    Description = "Printer"
                }
            };

            var expected = new List<CategoryEntity>()
            {
                new CategoryEntity()
                {
                    Id = _models.Count + 1,
                    Name = "New first",
                    Description = "Fdddd"
                },
                new CategoryEntity()
                {
                    Id = _models.Count + 2,
                    Name = "Epson 9000",
                    Description = "Printer"
                }
            };

            // Act
            CategoryManager.Create(categories.AsEnumerable());
            CategoryManager.Save();

            var firstCreatedEntity = DbContext.GetDbSet<CategoryEntity>().Find(_models.Count + 1);
            var secondCreatedEntity = DbContext.GetDbSet<CategoryEntity>().Find(_models.Count + 2);
            var actual = new List<CategoryEntity>()
            {
                firstCreatedEntity,
                secondCreatedEntity
            };

            // Assert     
            Assert.IsTrue(CategoryEntityComparer.Instance.AreEquals(expected, actual));
        }

        [TestMethod]
        public void Update_CategoryEntity()
        {
            // Arrange                
            var categoriesForUpdate = new List<CategoryModel>()
            {
                new CategoryModel()
                {
                    Id = 1,
                    Name = "HP 410",
                    Description = Guid.NewGuid().ToString()
                },
                new CategoryModel()
                {
                    Id = 2,
                    Name = Guid.NewGuid().ToString(),
                    Description = "WiFi All in One Ink Tank Printer"
                }
            };

            var expectedFirstCategory = categoriesForUpdate.FirstOrDefault(p => p.Id == 1).Description;
            var expectedSecondCategory = categoriesForUpdate.FirstOrDefault(p => p.Id == 2).Name;

            // Act
            CategoryManager.Update(categoriesForUpdate);
            CategoryManager.Save();

            var actualProducs = DbContext.GetDbSet<CategoryEntity>().ToList();
            var actualFirstCategory = actualProducs.FirstOrDefault(p => p.Id == 1).Description;
            var actualSecondCategory = actualProducs.FirstOrDefault(p => p.Id == 2).Name;

            // Assert     
            Assert.AreEqual(expectedFirstCategory, actualFirstCategory);
            Assert.AreEqual(expectedSecondCategory, actualSecondCategory);
        }

        [TestMethod]
        public void Delete_CategoryEntity()
        {
            // Arrange
            var categoriesToDelete = new List<CategoryModel>()
            {
                new CategoryModel()
                {
                    Id = 1
                },
                new CategoryModel()
                {
                    Id = 2,
                    Name = "Epson L3152",
                    Description = "WiFi All in One Ink Tank Printer"
                }
            };

            var expected = _models.Count - categoriesToDelete.Count;

            // Act
            CategoryManager.Delete(categoriesToDelete);
            CategoryManager.Save();

            var actual = DbContext.GetDbSet<CategoryEntity>().ToList();

            // Assert     
            Assert.AreEqual(expected, actual.Count);
        }

        [TestMethod]
        public void ProductCategoryEntitiesFieldTest()
        {
            // Arrange
            var firstCategory = DbContext.GetDbSet<CategoryEntity>().Find(1);

            // Act
            var productCategoryEntities = firstCategory.ProductCategoryEntities;
            var actual = productCategoryEntities.First();

            // Assert  
            Assert.IsNotNull(actual.Product);
            Assert.AreNotEqual(0, actual.ProductId);
        }
    }
}
