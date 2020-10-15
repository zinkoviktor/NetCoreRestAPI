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
            var categories = CategoryEntityHelper.GetCategoryEntities();

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
        public void CategoriesController_Get_ReturnsCategoryDtosList()
        {
            // Arrange 
            var categoriesController = new CategoriesController(Manager, Converter);
            var expected = CategoryDtoHelper.GetCategoryDtos();

            // Act
            var result = categoriesController.Get() as OkObjectResult;
            var actual = result.Value;

            // Assert            
            Assert.IsTrue(CategoryDtoHelper.Instance.AreEquals(expected, actual));
        }

        [TestMethod]
        public void CategoriesController_Get_ReturnsStatusCode200()
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
