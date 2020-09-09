using Common.Converter;
using DataLayer.EF.Converters;
using DataLayer.EF.Entities;
using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.ConvertersTests.DataLayer.EF.ProductConverter
{
    [TestClass]
    public class ConvertToProductEntityTests
    {        
        CategoryEntity categoryEntityStub;
        CategoryEntity categoryEntity2Stub;
        CategoryModel categoryModelStub;
        ProductEntity productEntityStub;
        ProductCategoryEntity productCategoryEntityStub;
        List<ProductEntity> productEntitiesStub;
        IConverter<CategoryEntity, CategoryModel> categoryConverter;

        [TestInitialize]
        public void TestInitialize()
        {
            categoryEntityStub = new CategoryEntity()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description",
            };

            categoryEntity2Stub = new CategoryEntity()
            {
                Id = 2,
                Name = "Name2",
                Description = "description"
            };

            categoryModelStub = new CategoryModel()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description"
            };

            productEntityStub = new ProductEntity()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description",
                AvailableCount = 5,
                Price = 19
            };

            productCategoryEntityStub = new ProductCategoryEntity()
            {
                ProductId = productEntityStub.Id,
                Product = productEntityStub,
                CategoryId = categoryEntityStub.Id,
                Category = categoryEntityStub
            };

            productEntitiesStub = new List<ProductEntity>()
            {
                productEntityStub,
                new ProductEntity()
                {
                        Id = 0,
                        Name = "",
                        Description = null,
                        AvailableCount = -9,
                        Price = 9.999m
                }
            };

            var mockCategotyConverter = new Mock<IConverter<CategoryEntity, CategoryModel>>();
            mockCategotyConverter
                .Setup(x => x.ConvertTo(categoryEntityStub))
                .Returns(categoryModelStub);
            categoryConverter = mockCategotyConverter.Object;
        }

        [TestMethod]        
        public void CorrectClassTypeConvertedToModel()
        {
            // Arrange
            productEntityStub.ProductCategoryEntities = new List<ProductCategoryEntity>() { productCategoryEntityStub };
            var converter = new ProductModelConverter(categoryConverter);

            // Act
            var actualProductModel = converter.ConvertTo(productEntityStub);

            // Assert            
            Assert.IsInstanceOfType(actualProductModel, typeof(ProductModel));
        }

        [TestMethod]
        public void ConvertToModelIsNotNull()
        {
            // Arrange 
            productEntityStub.ProductCategoryEntities = new List<ProductCategoryEntity>() { productCategoryEntityStub };
            var converter = new ProductModelConverter(categoryConverter);

            // Act
            var actualProductDto = converter.ConvertTo(productEntityStub);

            // Assert            
            Assert.IsNotNull(actualProductDto);
        }

        [TestMethod]
        [DataRow(1, "name", "Description", 5, 9.99595)]
        public void AllPropertyCorrectConvertedToModel(int id, string name, string description, int count, double price)
        {
            // Arrange            
            var productEntity = new ProductEntity() 
            { 
                Id = id, 
                Name = name, 
                Description = description, 
                AvailableCount = count, 
                Price = (decimal)price 
            };
            var categoryEntity = new CategoryEntity()
            {
                Id = id,
                Name = name,
                Description = description
            };
            var categoryModel = new CategoryModel()
            {
                Id = id,
                Name = name,
                Description = description
            };
            var productCategoryEntity = new ProductCategoryEntity() 
            { 
                Product = productEntity, 
                ProductId = productEntity.Id, 
                Category = categoryEntity,
                CategoryId = categoryEntity.Id
            };
            productEntity.ProductCategoryEntities = new List<ProductCategoryEntity>() { productCategoryEntity };
            categoryEntity.ProductCategoryEntities = new List<ProductCategoryEntity>() { productCategoryEntity };

            var categotyConverter = new Mock<IConverter<CategoryEntity, CategoryModel>>();
            categotyConverter
                .Setup(x => x.ConvertTo(categoryEntity))
                .Returns(categoryModel);

            var converter = new ProductModelConverter(categotyConverter.Object);

            // Act
            var actualProductModel = converter.ConvertTo(productEntity);

            // Assert     
            Assert.AreEqual(id, actualProductModel.Id, "Id property");
            Assert.AreEqual(name, actualProductModel.Name, "Name property");
            Assert.AreEqual(description, actualProductModel.Description, "Description property");
            Assert.AreEqual(count, actualProductModel.AvailableCount, "AvailableCount property");
            Assert.AreEqual((decimal)price, actualProductModel.Price, "Price property");           
        }

        [TestMethod]
        [DataRow(1, "name", "Description")]
        public void CategoryAddedToModel(int id, string name, string description)
        {
            // Arrange           
            var categoryModel = new CategoryModel()
            {
                Id = id,
                Name = name,
                Description = description
            };
            productEntityStub.ProductCategoryEntities = new List<ProductCategoryEntity>
            {
                productCategoryEntityStub
            };

            var categotyConverter = new Mock<IConverter<CategoryEntity, CategoryModel>>();
            categotyConverter
                .Setup(x => x.ConvertTo(It.IsAny<List<CategoryEntity>>()))
                .Returns(new List<CategoryModel>() { categoryModel, categoryModelStub });

            var converter = new ProductModelConverter(categotyConverter.Object);

            // Act
            var actualProductModel = converter.ConvertTo(productEntityStub);

            // Assert     
            Assert.IsTrue(actualProductModel.CategoryList.Any(categoryModel => categoryModel.Name.Equals(name)));
        }

    }
}
