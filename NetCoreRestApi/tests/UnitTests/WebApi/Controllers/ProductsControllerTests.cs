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
            var products = ProductEntityHelper.GetProductEntities();
            var categories = CategoryEntityHelper.GetCategoryEntities();

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
        public void ProductsController_Get_ReturnsCategoryDtosList()
        {
            // Arrange
            var controller = new ProductsController(Manager, Converter);
            var expected = ProductDtoHelper.GetProductDtos();

            // Act
            var result = controller.Get() as OkObjectResult;
            var actual = result.Value;

            // Assert            
            Assert.IsTrue(ProductDtoHelper.Instance.AreEquals(expected, actual));
        }

        [TestMethod]
        public void ProductsController_Get_ReturnsStatusCode200()
        {
            // Arrange
            var controller = new ProductsController(Manager, Converter);

            // Act
            var actual = controller.Get() as OkObjectResult;

            // Assert            
            Assert.AreEqual(200, actual.StatusCode);
        }
    }
}
