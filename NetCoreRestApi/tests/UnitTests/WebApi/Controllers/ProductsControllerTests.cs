using BusinessLayer.Managers;
using Common.Converter;
using DataLayer.EF;
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
    public class ProductsControllerTests : BaseTest, IDbContext
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

            var mock = new Mock<IDbContext>();
            var dbSetMock = new Mock<DbSet<ProductDto>>();
            dbSetMock.Setup(m => m.AsQueryable()).Returns(_dtos.AsQueryable());
            mock.Setup(d => d.GetDbSet<ProductDto>()).Returns(GetQueryableMockDbSet<ProductDto>(_dtos.ToList()));
            InjectService(typeof(IUnitOfWorkContext), mock.Object);
            InjectService(typeof(IDbContext), mock.Object.GetType());
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

        public int Save()
        {
            throw new System.NotImplementedException();
        }
    }
}
