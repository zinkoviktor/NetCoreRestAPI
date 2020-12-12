using BusinessLayer.Managers;
using Common.Converter;
using DataLayer.EF;
using DataLayer.EF.Entities;
using DataLayer.Models;
using DataLayer.Repositories.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceLayer.DataTransferObjects;
using System.Collections.Generic;
using UnitTests.Helpers;
using UnitTests.Helpers.ProductHelpers;
using WebAPI.Controllers;

namespace UnitTests.WebApi.Controllers
{
    [TestClass]
    public class ProductsControllerTests : BaseTest
    {
        private IProductManager Manager { get; set; }
        private IConverter<ProductDto, ProductModel> Converter { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
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

            var categories = new List<CategoryEntity>()
            {
                new CategoryEntity()
                {
                    Id = 1,
                    Name = "Laptops",
                    Description = "Shop Laptops and find popular brands. Save money.",
                    ProductCategoryEntities = new List<ProductCategoryEntity>()
                },
                new CategoryEntity()
                {
                    Id = 2,
                    Name = "Printers",
                    Description = "The Best Printers for 2020.",
                    ProductCategoryEntities = new List<ProductCategoryEntity>()
                },
                new CategoryEntity()
                {
                    Id = 3,
                    Name = "Sale",
                    Description = "Shop all sale items",
                    ProductCategoryEntities = new List<ProductCategoryEntity>()
                }
            };

            var mock = new Mock<IDbContext>();

            var productsDbSet = DbSetMockHelper.GetQueryableMockDbSet(products);
            var categoriesDbSet = DbSetMockHelper.GetQueryableMockDbSet(categories);

            mock.Setup(d => d.GetDbSet<ProductEntity>()).Returns(productsDbSet);
            mock.Setup(d => d.GetDbSet<CategoryEntity>()).Returns(categoriesDbSet);

            InjectService(mock.Object);
            InjectService<IUnitOfWorkContext>(mock.Object);

            ConfigureServices();

            Manager = ServiceProvider.GetRequiredService<IProductManager>();
            Converter = ServiceProvider.GetRequiredService<IConverter<ProductDto, ProductModel>>();
        }

        [TestMethod]
        public void Get_AllProductsRequest_ReturnsExpectedProducts()
        {
            // Arrange
            var controller = new ProductsController(Manager, Converter);
            var expected = new List<ProductDto>()
            {
                new ProductDto()
                {
                    Id = 1,
                    Name = "HP 410",
                    Description = "All-in-One Wireless Ink Tank Color Printer",
                    Price = 90,
                    AvailableCount = 9
                },
                new ProductDto()
                {
                    Id = 2,
                    Name = "Epson L3152",
                    Description = "WiFi All in One Ink Tank Printer",
                    Price = 60,
                    AvailableCount = 19
                }
            };

            // Act
            var result = controller.Get(null) as OkObjectResult;
            var actual = result.Value;

            // Assert            
            Assert.IsTrue(ProductDtoComparer.Instance.AreEquals(expected, actual));
        }

        [TestMethod]
        public void Get_AllProductsRequest_ReturnsStatusCode200()
        {
            // Arrange
            var controller = new ProductsController(Manager, Converter);

            // Act
            var actual = controller.Get(null) as OkObjectResult;

            // Assert            
            Assert.AreEqual(200, actual.StatusCode);
        }
    }
}
