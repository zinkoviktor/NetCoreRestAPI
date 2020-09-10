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
    public class ProductModelConverterConvertFromTests
    {
        CategoryModel categoryModelStub;
        CategoryModel categoryModel2Stub;
        CategoryEntity categoryEntityStub;
        ProductModel productModelStub;      
        List<ProductModel> productEntitiesStub;        

        [TestInitialize]
        public void TestInitialize()
        {
            categoryModel2Stub = new CategoryModel()
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

            categoryEntityStub = new CategoryEntity()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description",
            };

            productModelStub = new ProductModel()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description",
                AvailableCount = 5,
                Price = 19
            };

            productEntitiesStub = new List<ProductModel>()
            {
                productModelStub,
                new ProductModel()
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
        public void CorrectClassTypeConvertedFromModel()
        {
            // Arrange
            var categotyConverter = new Mock<IConverter<CategoryEntity, CategoryModel>>();
            categotyConverter
                .Setup(x => x.ConvertFrom(It.IsAny<CategoryModel>()))
                .Returns(categoryEntityStub);

            var converter = new ProductModelConverter(categotyConverter.Object);

            // Act
            var actualProductEntity = converter.ConvertFrom(productModelStub);

            // Assert            
            Assert.IsInstanceOfType(actualProductEntity, typeof(ProductEntity));
        }

        [TestMethod]
        public void ConvertFromModelIsNotNull()
        {
            // Arrange
            var categotyConverter = new Mock<IConverter<CategoryEntity, CategoryModel>>();
            categotyConverter
                .Setup(x => x.ConvertFrom(It.IsAny<CategoryModel>()))
                .Returns(categoryEntityStub);

            var converter = new ProductModelConverter(categotyConverter.Object);

            // Act
            var actualProductEntity = converter.ConvertFrom(productModelStub);

            // Assert            
            Assert.IsNotNull(actualProductEntity);
        }

        [TestMethod]
        [DataRow(1, "name", "Description", 5, 9.99595)]
        public void AllPropertyCorrectConvertedFromModel(int id, string name, string description, int count, double price)
        {
            // Arrange            
            var productModel = new ProductModel() 
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
            productModelStub.CategoryList = new List<CategoryModel>() 
            { 
                categoryModel 
            };

            var categotyConverter = new Mock<IConverter<CategoryEntity, CategoryModel>>();
            categotyConverter
                .Setup(x => x.ConvertFrom(categoryModel))
                .Returns(categoryEntity);

            var converter = new ProductModelConverter(categotyConverter.Object);

            // Act
            var actualProductEntity = converter.ConvertFrom(productModel);

            // Assert     
            Assert.AreEqual(id, actualProductEntity.Id, "Id property");
            Assert.AreEqual(name, actualProductEntity.Name, "Name property");
            Assert.AreEqual(description, actualProductEntity.Description, "Description property");
            Assert.AreEqual(count, actualProductEntity.AvailableCount, "AvailableCount property");
            Assert.AreEqual((decimal)price, actualProductEntity.Price, "Price property");           
        }

        [TestMethod]
        [DataRow(1, "name", "Description")]
        public void CategoryAddedToEntity(int id, string name, string description)
        {
            // Arrange           
            var categoryEntity = new CategoryEntity()
            {
                Id = id,
                Name = name,
                Description = description
            };
            productModelStub.CategoryList = new List<CategoryModel>
            {
                categoryModelStub
            };

            var categotyConverter = new Mock<IConverter<CategoryEntity, CategoryModel>>();
            categotyConverter
                .Setup(x => x.ConvertFrom(It.IsAny<List<CategoryModel>>()))
                .Returns(new List<CategoryEntity>() 
                {
                    categoryEntity,
                    categoryEntityStub
                });

            var converter = new ProductModelConverter(categotyConverter.Object);

            // Act
            var actualProductEntity = converter.ConvertFrom(productModelStub);

            // Assert     
            Assert.IsTrue(actualProductEntity.ProductCategoryEntities.Any(productCategory => productCategory.Category.Name.Equals(name)));
        }

        [TestMethod]        
        public void CorrectConvertedFromModelCollection()
        {
            // Arrange
            var categoryEntity = new CategoryEntity();
            productModelStub.CategoryList = new List<CategoryModel>
            {
                categoryModelStub,
                categoryModel2Stub
            };

            var categotyConverter = new Mock<IConverter<CategoryEntity, CategoryModel>>();
            categotyConverter
                .Setup(x => x.ConvertFrom(It.IsAny<List<CategoryModel>>()))
                .Returns(new List<CategoryEntity>() 
                { 
                    categoryEntityStub, 
                    categoryEntity 
                });

            var converter = new ProductModelConverter(categotyConverter.Object);

            // Act
            var actualProductEntities = converter.ConvertFrom(productEntitiesStub).ToList();

            // Assert     
            CollectionAssert.AllItemsAreInstancesOfType(actualProductEntities, typeof(ProductModel));
            CollectionAssert.AllItemsAreNotNull(actualProductEntities);
            Assert.AreEqual(actualProductEntities.Count, 2, "Count of ProductModel items");           
        }

        [TestMethod]
        [DataRow(1, "name", "Description", 5, 9.99595)]
        public void AllPropertiesConvertedFromModelInCollection(int id, string name, string description, int count, double price)
        {
            // Arrange            
            var productModel = new ProductModel()
            {
                Id = id,
                Name = name,
                Description = description,
                AvailableCount = count,
                Price = (decimal)price
            };
            var categoryModel = new CategoryModel()
            {
                Id = id,
                Name = name,
                Description = description
            };            
           
            var productModels = new List<ProductModel>()
            {
                productModel,
                productModelStub
            };

            var categotyConverter = new Mock<IConverter<CategoryEntity, CategoryModel>>();
            categotyConverter
                .Setup(x => x.ConvertFrom(It.IsAny<List<CategoryModel>>()))
                .Returns(new List<CategoryEntity>() 
                {                    
                    categoryEntityStub 
                });

            var converter = new ProductModelConverter(categotyConverter.Object);

            // Act
            var actualProductEntities = converter.ConvertFrom(productModels).ToList();
            Assert.IsTrue(actualProductEntities.Any(productEntity => productEntity.Name.Equals(name)),
                "ProductModel is not found in converter collection");
            var actualProductModel = actualProductEntities.First(productEntity => productEntity.Name.Equals(name));

            // Assert 
            Assert.AreEqual(id, actualProductModel.Id, "Id property");
            Assert.AreEqual(name, actualProductModel.Name, "Name property");
            Assert.AreEqual(description, actualProductModel.Description, "Description property");
            Assert.AreEqual(count, actualProductModel.AvailableCount, "AvailableCount property");
            Assert.AreEqual((decimal)price, actualProductModel.Price, "Price property");
        }
    }
}
