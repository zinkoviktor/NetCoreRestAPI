using Common.Converter;
using DataLayer.EF.Converters;
using DataLayer.EF.Entities;
using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.ConvertersTests
{
    [TestClass]
    public class ProductModelConverterConvertToTests
    {        
        CategoryEntity categoryEntityStub;       
        CategoryModel categoryModelStub;
        ProductEntity productEntityStub;
        ProductCategoryEntity productCategoryEntityStub;
        List<ProductEntity> productEntitiesStub;        

        [TestInitialize]
        public void TestInitialize()
        {
            categoryEntityStub = new CategoryEntity()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description",
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
        }

        [TestMethod]        
        public void CorrectClassTypeConvertedToModel()
        {
            // Arrange
            productEntityStub.ProductCategoryEntities = new List<ProductCategoryEntity>() 
            { 
                productCategoryEntityStub 
            };

            var categotyConverter = new Mock<IConverter<CategoryEntity, CategoryModel>>();
            categotyConverter
                .Setup(x => x.ConvertTo(It.IsAny<CategoryEntity>()))
                .Returns(categoryModelStub);

            var converter = new ProductModelConverter(categotyConverter.Object);

            // Act
            var actualProductModel = converter.ConvertTo(productEntityStub);

            // Assert            
            Assert.IsInstanceOfType(actualProductModel, typeof(ProductModel));
        }

        [TestMethod]
        public void ConvertToModelIsNotNull()
        {
            // Arrange 
            productEntityStub.ProductCategoryEntities = new List<ProductCategoryEntity>() 
            { 
                productCategoryEntityStub 
            };

            var categotyConverter = new Mock<IConverter<CategoryEntity, CategoryModel>>();
            categotyConverter
                .Setup(x => x.ConvertTo(It.IsAny<CategoryEntity>()))
                .Returns(categoryModelStub);

            var converter = new ProductModelConverter(categotyConverter.Object);

            // Act
            var actualProductModel = converter.ConvertTo(productEntityStub);

            // Assert            
            Assert.IsNotNull(actualProductModel);
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
            productEntity.ProductCategoryEntities = new List<ProductCategoryEntity>() 
            { 
                productCategoryEntity 
            };

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
                .Returns(new List<CategoryModel>() 
                { 
                    categoryModel, 
                    categoryModelStub 
                });

            var converter = new ProductModelConverter(categotyConverter.Object);

            // Act
            var actualProductModel = converter.ConvertTo(productEntityStub);

            // Assert     
            Assert.IsTrue(actualProductModel.CategoryList.Any(categoryModel => categoryModel.Name.Equals(name)));
        }

        [TestMethod]        
        public void CorrectConvertedToModelCollection()
        {
            // Arrange
            var categoryMode = new CategoryModel();
            foreach(var pe in productEntitiesStub)
            {
                pe.ProductCategoryEntities = new List<ProductCategoryEntity> 
                { 
                    productCategoryEntityStub 
                };
            }    

            var categotyConverter = new Mock<IConverter<CategoryEntity, CategoryModel>>();
            categotyConverter
                .Setup(x => x.ConvertTo(It.IsAny<List<CategoryEntity>>()))
                .Returns(new List<CategoryModel>() 
                { 
                    categoryMode, 
                    categoryModelStub 
                });

            var converter = new ProductModelConverter(categotyConverter.Object);

            // Act
            var actualProductModels = converter.ConvertTo(productEntitiesStub).ToList();

            // Assert     
            CollectionAssert.AllItemsAreInstancesOfType(actualProductModels, typeof(ProductModel));
            CollectionAssert.AllItemsAreNotNull(actualProductModels);
            Assert.AreEqual(actualProductModels.Count, 2, "Count of ProductModel items");
            Assert.AreEqual(actualProductModels.First().CategoryList.ToList().Count, 2, "Count of CategoryModel items in ProductModel");
        }

        [TestMethod]
        [DataRow(1, "name", "Description", 5, 9.99595)]
        public void AllPropertiesConvertedToModelInCollection(int id, string name, string description, int count, double price)
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
            productEntity.ProductCategoryEntities = new List<ProductCategoryEntity>()
            {
                productCategoryEntity
            };
            productEntityStub.ProductCategoryEntities = new List<ProductCategoryEntity>()
            {
                productCategoryEntityStub
            };
            var productEntities = new List<ProductEntity>()
            {
                productEntityStub,
                productEntity
            };

            var categotyConverter = new Mock<IConverter<CategoryEntity, CategoryModel>>();
            categotyConverter
                .Setup(x => x.ConvertTo(It.IsAny<List<CategoryEntity>>()))
                .Returns(new List<CategoryModel>() 
                { 
                    categoryModel, 
                    categoryModelStub 
                });

            var converter = new ProductModelConverter(categotyConverter.Object);

            // Act
            var actualProductModels = converter.ConvertTo(productEntities).ToList();
            Assert.IsTrue(actualProductModels.Any(productModel => productModel.Name.Equals(name)),
                "ProductModel is not found in converter collection");
            var actualProductModel = actualProductModels.First(productModel => productModel.Name.Equals(name));

            // Assert 
            Assert.AreEqual(id, actualProductModel.Id, "Id property");
            Assert.AreEqual(name, actualProductModel.Name, "Name property");
            Assert.AreEqual(description, actualProductModel.Description, "Description property");
            Assert.AreEqual(count, actualProductModel.AvailableCount, "AvailableCount property");
            Assert.AreEqual((decimal)price, actualProductModel.Price, "Price property");
        }
    }
}
