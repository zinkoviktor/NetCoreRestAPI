using BusinessLayer.Managers;
using Common.Converter;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceLayer.DataTransferObjects;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Controllers;

namespace UnitTests.WebApi.Controllers
{
    [TestClass]
    public class ProductsControllerTests
    {
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

            var productDtosList = new List<ProductDto>()
            {
                new ProductDto()
                {
                    Id = 1,
                    Name = "First"
                },
                new ProductDto()
                {
                    Id = 1,
                    Name = "Second"
                }
            };
            _dtos = productDtosList.AsQueryable();
        }

        [TestMethod]
        public void ProductsController_Get_ReturnsCategoryDtosList()
        {
            // Arrange
            var managerMock = new Mock<IProductManager>();
            managerMock
                .Setup(m => m.GetAll())
                .Returns(_models);

            var converterMock = new Mock<IConverter<ProductDto, ProductModel>>();
            converterMock
                .Setup(c => c.ConvertFrom(It.IsAny<IEnumerable<ProductModel>>()))
                .Returns(_dtos);

            var controller = new ProductsController(managerMock.Object, converterMock.Object);

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
            var managerMock = new Mock<IProductManager>();
            managerMock
                .Setup(m => m.GetAll())
                .Returns(_models);

            var converterMock = new Mock<IConverter<ProductDto, ProductModel>>();
            converterMock
                .Setup(c => c.ConvertFrom(It.IsAny<IEnumerable<ProductModel>>()))
                .Returns(_dtos);

            var controller = new ProductsController(managerMock.Object, converterMock.Object);

            // Act
            var result = controller.Get();
            var actual = result as OkObjectResult;

            // Assert            
            Assert.AreEqual(200, actual.StatusCode);
        }
    }
}
