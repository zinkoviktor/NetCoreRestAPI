using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.Converters;
using ServiceLayer.DataTransferObjects;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.ConvertersTests
{
    [TestClass]
    public class ProductServiceConverterConvertFromTests
    {
        ProductServiceConverter converter;
        CategoryModel categoryModel;
        CategoryModel categoryModel2;
        ProductModel productModel;        
        List<ProductModel> productModels;

        [TestInitialize]
        public void TestInitialize()
        {
            converter = new ProductServiceConverter();

            categoryModel = new CategoryModel()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description",
            };

            categoryModel2 = new CategoryModel()
            {
                Id = 2,
                Name = "Name2",
                Description = "description"
            };

            productModel = new ProductModel()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description",
                AvailableCount = 5,
                Price = 19,
                CategoryList = new List<CategoryModel>() { categoryModel }
            };

            productModels = new List<ProductModel>()
            {
                productModel,
                new ProductModel()
                {
                        Id = 0,
                        Name = "",
                        Description = null,
                }
            };
        }

        [TestMethod]
        public void CorrectClassTypeConvertedFromDto()
        {
            // Arrange

            // Act
            var actualProductDto = converter.ConvertFrom(productModel);

            // Assert            
            Assert.IsInstanceOfType(actualProductDto, typeof(ProductDto));
        }

        [TestMethod]
        public void ConvertFromDtoIsNotNull()
        {
            // Arrange 

            // Act
            var actualProductDto = converter.ConvertFrom(productModel);

            // Assert            
            Assert.IsNotNull(actualProductDto);
        }

        [TestMethod]
        [Description("Is Id property value converted correct")]
        [DataRow(1)]
        [DataRow(0)]
        [DataRow(-5)]
        public void ConvertFromDtoIdPropertyValueIsSameId(int expectedId)
        {
            // Arrange 
            productModel.Id = expectedId;

            // Act
            var actualProductDto = converter.ConvertFrom(productModel);

            // Assert            
            Assert.AreEqual(expectedId, actualProductDto.Id);
        }

        [TestMethod]
        [Description("Is name property value converted correct")]
        [DataRow("Name 1 !@~#$%^&*()_+=-\\||'\"?/.><,")]
        [DataRow(null)]
        [DataRow("")]
        public void ConvertFromDtoNamePropertyValueIsSameName(string expectedName)
        {
            // Arrange 
            productModel.Name = expectedName;

            // Act
            var actualProductDto = converter.ConvertFrom(productModel);

            // Assert            
            Assert.AreEqual(expectedName, actualProductDto.Name);
        }

        [TestMethod]
        [Description("Is Description property value converted correct")]
        [DataRow("Description 1 !@~#$%^&*()_+=-\\||'\"?/.><,")]
        [DataRow(null)]
        [DataRow("")]
        public void ConvertFromDtoDescriptionPropertyValueIsSameDescription(string expectedDescription)
        {
            // Arrange 
            productModel.Description = expectedDescription;

            // Act
            var actualProductDto = converter.ConvertFrom(productModel);

            // Assert            
            Assert.AreEqual(expectedDescription, actualProductDto.Description);
        }

        [TestMethod]
        [Description("Is AvailableCount property value converted correct")]
        [DataRow(1)]
        [DataRow(0)]
        [DataRow(-5)]
        public void ConvertFromDtoAvailableCountPropertyValueIsSameId(int expectedAvailableCount)
        {
            // Arrange 
            productModel.AvailableCount = expectedAvailableCount;

            // Act
            var actualProductDto = converter.ConvertFrom(productModel);

            // Assert            
            Assert.AreEqual(expectedAvailableCount, actualProductDto.AvailableCount);
        }

        [TestMethod]
        [Description("Is Price property value converted correct")]
        [DataRow(1)]
        [DataRow(0)]
        [DataRow(-5.996)]
        public void ConvertFromDtoPricePropertyValueIsSameId(double expectedPrice)
        {
            // Arrange 
            var decimalExpectedPrice = (decimal)expectedPrice;
            productModel.Price = decimalExpectedPrice;

            // Act
            var actualProductDto = converter.ConvertFrom(productModel);

            // Assert            
            Assert.AreEqual(decimalExpectedPrice, actualProductDto.Price);
        }

        [TestMethod]        
        public void ConvertFromDtoCategoriesPropertyValueIsNotNull()
        {
            // Arrange 
            productModel.CategoryList = new List<CategoryModel>() { categoryModel };

            // Act
            var actualProductDto = converter.ConvertFrom(productModel);

            // Assert
            Assert.IsNotNull(actualProductDto.Categories);
        }

        [TestMethod]
        public void ConvertFromDtoCategoriesPropertyValuesIsConverted()
        {
            // Arrange            
            productModel.CategoryList = new List<CategoryModel>() { categoryModel, categoryModel2 };
            var expectedCategories = categoryModel.Name + ", " + categoryModel2.Name;

            // Act
            var actualProductDto = converter.ConvertFrom(productModel);

            // Assert
            Assert.AreEqual(expectedCategories, actualProductDto.Categories);
        }

        [TestMethod]
        public void CorrectClassTypeConvertedFromDtoCollection()
        {
            // Arrange             

            // Act
            var actualProductDtos = converter.ConvertFrom(productModels);

            // Assert            
            Assert.IsInstanceOfType(actualProductDtos, typeof(IEnumerable<ProductDto>));
        }

        [TestMethod]
        public void CorrectAllItemsTypesConvertedFromDtoCollection()
        {
            // Arrange             

            // Act
            var actualProductDtos = converter.ConvertFrom(productModels);

            // Assert            
            CollectionAssert.AllItemsAreInstancesOfType(actualProductDtos.ToList(), typeof(ProductDto));
        }

        [TestMethod]
        public void ConvertFromDtoCollectionIsNotNull()
        {
            // Arrange             

            // Act
            var actualProductDtos = converter.ConvertFrom(productModels);

            // Assert            
            Assert.IsNotNull(actualProductDtos);
        }

        [TestMethod]
        public void ConvertFromDtoCollectionAllItemsAreNotNull()
        {
            // Arrange             

            // Act
            var actualProductDtos = converter.ConvertFrom(productModels);

            // Assert            
            CollectionAssert.AllItemsAreNotNull(actualProductDtos.ToList());
        }

        [TestMethod]
        [Description("Is Id property value converted correct")]
        [DataRow(7)]
        [DataRow(0)]
        [DataRow(-5)]
        public void ConvertFromDtoIdPropertyValueInCollectionIsSameId(int expectedId)
        {
            // Arrange 
            productModels.Last().Id = expectedId;

            // Act
            var actualProductDtos = converter.ConvertFrom(productModels);

            // Assert            
            Assert.AreEqual(expectedId, actualProductDtos.Last().Id);
        }

        [TestMethod]
        [Description("Is name property value converted correct")]
        [DataRow("Name 1 !@~#$%^&*()_+=-\\||'\"?/.><,")]
        [DataRow(null)]
        [DataRow("")]
        public void ConvertFromDtoNamePropertyValueInCollectionIsSameName(string expectedName)
        {
            // Arrange 
            productModels.First().Name = expectedName;

            // Act
            var actualProductDtos = converter.ConvertFrom(productModels);

            // Assert            
            Assert.AreEqual(expectedName, actualProductDtos.First().Name);
        }

        [TestMethod]
        [Description("Is Description property value converted correct")]
        [DataRow("Description 1 !@~#$%^&*()_+=-\\||'\"?/.><,")]
        [DataRow(null)]
        [DataRow("")]
        public void ConvertFromDtoDescriptionPropertyValueInCollectionIsSameDescription(string expectedDescription)
        {
            // Arrange 
            productModels.Last().Description = expectedDescription;

            // Act
            var actualProductDtos = converter.ConvertFrom(productModels);

            // Assert            
            Assert.AreEqual(expectedDescription, actualProductDtos.Last().Description);
        }

        [TestMethod]
        [Description("Is AvailableCount property value converted correct")]
        [DataRow(7)]
        [DataRow(0)]
        [DataRow(-5)]
        public void ConvertFromDtoAvailableCountPropertyValueInCollectionIsSameAvailableCount(int expectedAvailableCount)
        {
            // Arrange 
            productModels.Last().AvailableCount = expectedAvailableCount;

            // Act
            var actualProductDtos = converter.ConvertFrom(productModels);

            // Assert            
            Assert.AreEqual(expectedAvailableCount, actualProductDtos.Last().AvailableCount);
        }

        [TestMethod]
        [Description("Is Price property value converted correct")]
        [DataRow(7.0)]
        [DataRow(0.0)]
        [DataRow(-5.894948)]
        public void ConvertFromDtoPricePropertyValueInCollectionIsSamePrice(double expectedPrice)
        {
            // Arrange 
            var decimalExpectedPrice = (decimal)expectedPrice;            
            productModels.Last().Price = decimalExpectedPrice;

            // Act
            var actualProductDtos = converter.ConvertFrom(productModels);

            // Assert            
            Assert.AreEqual(decimalExpectedPrice, actualProductDtos.Last().Price);
        }

        [TestMethod]
        [DataRow("name 1", "Description 1 !@~#$%^&*()_+=-\\||'\"?/.><")]
        [DataRow("", "")]       
        public void ConvertFromDtoCategoriesPropertyValueInCollectionIsSameCategories(string name1, string name2)
        {
            // Arrange 
            productModel.CategoryList = new List<CategoryModel>() { categoryModel, categoryModel2 };
            var productModels = new List<ProductModel>()
            {
                new ProductModel
                {
                    Name = "Test Name",
                    CategoryList = new List<CategoryModel>()
                    {
                        new CategoryModel
                        {
                            Name = name1
                        },
                        new CategoryModel
                        {
                            Name = name2
                        }
                    }
                }
            };

            var expectedCategories = name1 + ", " + name2;

            // Act
            var actualProductDtos = converter.ConvertFrom(productModels);

            // Assert            
            Assert.AreEqual(expectedCategories, actualProductDtos.Last().Categories);
        }
    }
}
