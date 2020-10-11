using BusinessLayer.Managers;
using Common.Converter;
using DataLayer.EF;
using DataLayer.EF.Entities;
using DataLayer.Models;
using DataLayer.Repositories.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceLayer.DataTransferObjects;
using System.Collections.Generic;
using System.Linq;
using UnitTests.Helpers;
using WebAPI;
using WebAPI.Controllers;

namespace UnitTests.WebApi.Controllers
{
    [TestClass]
    public class ProductsControllerTests : BaseTest
    {
        IProductManager manager;
        IConverter<ProductDto, ProductModel> converter;

        private IQueryable<ProductModel> _models;
        private IEnumerable<ProductDto> _dtos;

        [TestInitialize]
        public void TestInitialize()
        {
            

            var productModelsList = new List<ProductModel>()
            {
                new ProductModel()
                {
                    Id = 1,
                    Name = "First"
                },
                new ProductModel()
                {
                    Id = 1,
                    Name = "Second"
                }
            };
            _models = productModelsList.AsQueryable();

            var productDtosList = new List<ProductEntity>()
            {
                new ProductEntity()
                {
                    Name = "HP 410",
                    Description = "All-in-One Wireless Ink Tank Color Printer",
                    Price = 90,
                    AvailableCount = 9,
                    ProductCategoryEntities = new List<ProductCategoryEntity>()
                },
                new ProductEntity()
                {
                    Name = "Epson L3152",
                    Description = "WiFi All in One Ink Tank Printer",
                    Price = 60,
                    AvailableCount = 19,
                ProductCategoryEntities = new List<ProductCategoryEntity>()
        }
            };

            var categoryEntities = new List<CategoryEntity>()
            {
                new CategoryEntity()
                {
                    Name = "Laptops",
                    Description = "Shop Laptops and find popular brands. Save money."
                },
                new CategoryEntity()
                {
                    Name = "Printers",
                    Description = "The Best Printers for 2020."
                },
                new CategoryEntity()
                {
                    Name = "Sale",
                    Description = "Shop all sale items"
                }
            };

            var mock = new Mock<IDbContext>();
            var productsDbSet = GetQueryableMockDbSet(productDtosList);
            var categoriesDbSet = GetQueryableMockDbSet(categoryEntities);
            mock.Setup(d => d.GetDbSet<ProductEntity>()).Returns(productsDbSet);
            mock.Setup(d => d.GetDbSet<CategoryEntity>()).Returns(categoriesDbSet);
            InjectService(mock.Object);
            InjectService<IUnitOfWorkContext>(mock.Object);
            ConfigureServices();

            manager = ServiceProvider.GetRequiredService<IProductManager>();
            converter = ServiceProvider.GetRequiredService<IConverter<ProductDto, ProductModel>>();
            
        }

        [TestMethod]
        public void ProductsController_Get_ReturnsCategoryDtosList()
        {
            // Arrange
            var controller = new ProductsController(manager, converter);

            var expected = _dtos;

            // Act
            var result = controller.Get();
            var actual = result as OkObjectResult;

            // Assert            
            Assert.AreEqual(expected, actual.Value);
        }

        [TestMethod]
        public void ProductsController_Get_ReturnsStatusCode200()
        {
            // Arrange
            var productModelsList = new List<ProductModel>()
            {
                new ProductModel()
                {
                    Id = 1,
                    Name = "First"
                },
                new ProductModel()
                {
                    Id = 1,
                    Name = null
                }
            };

            var x = new CategoryModel()
            {
                Id = 1,
                Name = null
            };

            // Assert            
            Assert.IsTrue(ObjectPropertiesComparer.AreEqual(productModelsList.First(), productModelsList.Last()));
        }

        bool Equal(object a, object b)
        {
            // They're both null.
            if (a == null && b == null) return true;
            // One is null, so they can't be the same.
            if (a == null || b == null) return false;
            // How can they be the same if they're different types?
            if (a.GetType() != b.GetType()) return false;
            var Props = a.GetType().GetProperties();
            foreach (var Prop in Props)
            {
                // See notes *
                var aPropValue = Prop.GetValue(a) ?? string.Empty;
                var bPropValue = Prop.GetValue(b) ?? string.Empty;
                if (aPropValue.ToString() != bPropValue.ToString())
                    return false;
            }
            return true;
        }

        private DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));

            return dbSet.Object;
        }
    }
}
