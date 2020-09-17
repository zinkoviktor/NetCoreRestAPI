using Common.Converter;
using DataLayer.EF.Converters;
using DataLayer.EF.Entities;
using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.DataLayer.EF.Converters.ProductModelConverterTests
{
    [TestClass]
    public class ConvertFrom
    {        
        IConverter<ProductEntity, ProductModel> _converter;
        IComparer _comparer;

        [TestInitialize]
        public void TestInitialize()
        {
            var categoryConverter = new CategoryModelConverter();
            _converter = new ProductModelConverter(categoryConverter);

            static bool predicate(ProductEntity entity1, ProductEntity entity2) =>
                entity1.Id.Equals(entity2.Id) &&
                entity1.Name.Equals(entity2.Name) &&
                entity1.Description.Equals(entity2.Description) &&
                entity1.Price.Equals(entity2.Price) &&
                entity1.AvailableCount.Equals(entity2.AvailableCount);

            _comparer = new BaseComparer<ProductEntity>(predicate);
        }  

        [TestMethod]        
        public void AllItemsAreNotNull()
        {
            // Arrange
            var productModelStub = new ProductModel()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description",
                AvailableCount = 5,
                Price = 19
            };

            var categoryModelStub = new CategoryModel()
            {
                Id = 1,
                Name = "Name 1!@~#$%^&*()_+=-\\||'\"?/.><,",
                Description = "Name 1 !@~#$%^&*()_+=-\\||'\"?/.><,"
            };
            var categoryModel2Stub = new CategoryModel()
            {
                Id = 2,
                Name = "Test Name 2",
                Description = "Test Description 2",
            };
            var categoryList = new List<CategoryModel>
            {
                categoryModelStub,
                categoryModel2Stub
            };

            productModelStub.CategoryList = categoryList;
            var productModelsStub = new List<ProductModel>()
            {
                productModelStub,
                new ProductModel()
                {
                        Id = 0,
                        Name = "",
                        Description = null,
                        AvailableCount = -9,
                        Price = 9.999m,
                        CategoryList = categoryList
                }
            };

            // Act
            var actual = _converter.ConvertFrom(productModelsStub).ToList();

            // Assert                
            CollectionAssert.AllItemsAreNotNull(actual);        
        }

        [TestMethod]
        public void AllFieldsConverted()
        {
            // Arrange
            var productModelStub = new ProductModel()
            {
                Id = 1,
                Name = "Name 1!@~#$%^&*()_+=-\\||'\"?/.><,",
                Description = "Name 1!@~#$%^&*()_+=-\\||'\"?/.><,",
                AvailableCount = 5,
                Price = 19
            };          

            var categoryModelStub = new CategoryModel()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description"
            };
            var categoryModel2Stub = new CategoryModel()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description",
            };
            var categoryList = new List<CategoryModel>
            {
                categoryModelStub,
                categoryModel2Stub
            };

            productModelStub.CategoryList = categoryList;
            var productModelsStub = new List<ProductModel>()
            {
                productModelStub,
                new ProductModel()
                {
                        Id = 0,
                        Name = "",
                        Description = "",
                        AvailableCount = -9,
                        Price = 9.999m,
                        CategoryList = categoryList
                }
            };

            var expected = new List<ProductEntity>()
            {
                new ProductEntity()
                {
                    Id = 1,
                    Name = "Name 1!@~#$%^&*()_+=-\\||'\"?/.><,",
                    Description = "Name 1!@~#$%^&*()_+=-\\||'\"?/.><,",
                    AvailableCount = 5,
                    Price = 19
                },
                new ProductEntity()
                {
                    Id = 0,
                    Name = "",
                    Description = "",
                    AvailableCount = -9,
                    Price = 9.999m,
                }
            };

            // Act
            var actual = _converter.ConvertFrom(productModelsStub).ToList();

            // Assert                
            CollectionAssert.AreEqual(expected, actual, _comparer);
        }
    }
}
