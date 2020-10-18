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
using UnitTests.Helpers.CategoryHelpers;
using WebAPI.Controllers;

namespace UnitTests.WebApi.Controllers
{
    [TestClass]
    public class CategoriesControllerTests : BaseTest
    {
        private ICategoryManager Manager { get; set; }
        private IConverter<CategoryDto, CategoryModel> Converter { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
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

            var categoriesDbSet = DbSetMockHelper.GetQueryableMockDbSet(categories);

            mock.Setup(d => d.GetDbSet<CategoryEntity>()).Returns(categoriesDbSet);

            InjectService(mock.Object);
            InjectService<IUnitOfWorkContext>(mock.Object);

            ConfigureServices();

            Manager = ServiceProvider.GetRequiredService<ICategoryManager>();
            Converter = ServiceProvider.GetRequiredService<IConverter<CategoryDto, CategoryModel>>();
        }

        [TestMethod]
        public void Get_AllCategoriesRequest_ReturnsExpectedCategories()
        {
            // Arrange 
            var categoriesController = new CategoriesController(Manager, Converter);
            var expected = new List<CategoryDto>()
            {
                new CategoryDto()
                {
                    Id = 1,
                    Name = "Laptops",
                    Description = "Shop Laptops and find popular brands. Save money."
                },
                new CategoryDto()
                {
                    Id = 2,
                    Name = "Printers",
                    Description = "The Best Printers for 2020."
                },
                new CategoryDto()
                {
                    Id = 3,
                    Name = "Sale",
                    Description = "Shop all sale items"
                }
            };

            // Act
            var result = categoriesController.Get() as OkObjectResult;
            var actual = result.Value;

            // Assert            
            Assert.IsTrue(CategoryDtoComparer.Instance.AreEquals(expected, actual));
        }

        [TestMethod]
        public void Get_AllCategoriesRequest_ReturnsStatusCode200()
        {
            // Arrange           
            var categoriesController = new CategoriesController(Manager, Converter);

            // Act
            var result = categoriesController.Get();
            var actual = result as OkObjectResult;

            // Assert            
            Assert.AreEqual(200, actual.StatusCode);
        }
    }
}
