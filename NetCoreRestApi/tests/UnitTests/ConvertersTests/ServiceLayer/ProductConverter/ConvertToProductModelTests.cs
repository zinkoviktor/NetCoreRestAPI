using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.Converters;
using ServiceLayer.DataTransferObjects;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.ConvertersTests.ServiceLayer.ProductConverter
{
    [TestClass]
    public class ConvertToproductDtoTests
    {
        ProductServiceConverter converter;
        CategoryDto categoryDto;
        CategoryDto categoryDto2;
        ProductDto productDto;        
        List<ProductDto> productDtos;

        [TestInitialize]
        public void TestInitialize()
        {
            converter = new ProductServiceConverter();

            categoryDto = new CategoryDto()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description",
            };

            categoryDto2 = new CategoryDto()
            {
                Id = 2,
                Name = "Name2",
                Description = "description"
            };

            productDto = new ProductDto()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description",
                AvailableCount = 5,
                Price = 19,
                Categories = "Test Name, Name2"
            };

            productDtos = new List<ProductDto>()
            {
                productDto,
                new ProductDto()
                {
                        Id = 0,
                        Name = "",
                        Description = null,
                }
            };
        }

        [TestMethod]
        public void CorrectClassTypeConvertedToDto()
        {
            // Arrange

            // Act
            var actualproductDto = converter.ConvertTo(productDto);

            // Assert            
            Assert.IsInstanceOfType(actualproductDto, typeof(ProductModel));
        }

        [TestMethod]
        public void ConvertToDtoIsNotNull()
        {
            // Arrange 

            // Act
            var actualProductDto = converter.ConvertTo(productDto);

            // Assert            
            Assert.IsNotNull(actualProductDto);
        }

        [TestMethod]
        [Description("Is Id property value converted correct")]
        [DataRow(1)]
        [DataRow(0)]
        [DataRow(-5)]
        public void ConvertToDtoIdPropertyValueIsSameId(int expectedId)
        {
            // Arrange 
            productDto.Id = expectedId;

            // Act
            var actualProductDto = converter.ConvertTo(productDto);

            // Assert            
            Assert.AreEqual(expectedId, actualProductDto.Id);
        }

        [TestMethod]
        [Description("Is name property value converted correct")]
        [DataRow("Name 1 !@~#$%^&*()_+=-\\||'\"?/.><,")]
        [DataRow(null)]
        [DataRow("")]
        public void ConvertToDtoNamePropertyValueIsSameName(string expectedName)
        {
            // Arrange 
            productDto.Name = expectedName;

            // Act
            var actualProductDto = converter.ConvertTo(productDto);

            // Assert            
            Assert.AreEqual(expectedName, actualProductDto.Name);
        }

        [TestMethod]
        [Description("Is Description property value converted correct")]
        [DataRow("Description 1 !@~#$%^&*()_+=-\\||'\"?/.><,")]
        [DataRow(null)]
        [DataRow("")]
        public void ConvertToDtoDescriptionPropertyValueIsSameDescription(string expectedDescription)
        {
            // Arrange 
            productDto.Description = expectedDescription;

            // Act
            var actualProductDto = converter.ConvertTo(productDto);

            // Assert            
            Assert.AreEqual(expectedDescription, actualProductDto.Description);
        }

        [TestMethod]
        [Description("Is AvailableCount property value converted correct")]
        [DataRow(1)]
        [DataRow(0)]
        [DataRow(-5)]
        public void ConvertToDtoAvailableCountPropertyValueIsSameId(int expectedAvailableCount)
        {
            // Arrange 
            productDto.AvailableCount = expectedAvailableCount;

            // Act
            var actualProductDto = converter.ConvertTo(productDto);

            // Assert            
            Assert.AreEqual(expectedAvailableCount, actualProductDto.AvailableCount);
        }

        [TestMethod]
        [Description("Is Price property value converted correct")]
        [DataRow(1)]
        [DataRow(0)]
        [DataRow(-5.996)]
        public void ConvertToDtoPricePropertyValueIsSameId(double expectedPrice)
        {
            // Arrange 
            var decimalExpectedPrice = (decimal)expectedPrice;
            productDto.Price = decimalExpectedPrice;

            // Act
            var actualProductDto = converter.ConvertTo(productDto);

            // Assert            
            Assert.AreEqual(decimalExpectedPrice, actualProductDto.Price);
        }

        [TestMethod]        
        public void ConvertToDtoCategoryListPropertyValueIsNotNull()
        {
            // Arrange 
            productDto.Categories = categoryDto.Name + ", " + categoryDto2.Name;

            // Act
            var actualProductDto = converter.ConvertTo(productDto);

            // Assert
            Assert.IsNotNull(actualProductDto.CategoryList);
        }

        [TestMethod]
        public void ConvertToDtoCategoryListPropertyValuesIsCorrectCount()
        {
            // Arrange            
            productDto.Categories = categoryDto.Name + ", " + categoryDto2.Name;

            // Act
            var actualProductDto = converter.ConvertTo(productDto);

            // Assert
            Assert.IsTrue(actualProductDto.CategoryList.Count().Equals(2));
        }

        [TestMethod]
        public void ConvertToDtoCategoryListPropertyValuesAllIdsAreZero()
        {
            // Arrange            
            productDto.Categories = categoryDto.Name + ", " + categoryDto2.Name;

            // Act
            var actualProductDto = converter.ConvertTo(productDto);

            // Assert
            Assert.IsTrue(actualProductDto.CategoryList.All(category => category.Id.Equals(0)));
        }

        [TestMethod]
        public void ConvertToDtoCategoryListPropertyValuesAllDescriptionsAreNull()
        {
            // Arrange            
            productDto.Categories = categoryDto.Name + ", " + categoryDto2.Name;

            // Act
            var actualProductDto = converter.ConvertTo(productDto);

            // Assert
            Assert.IsTrue(actualProductDto.CategoryList.All(category => category.Description == null));
        }

        [TestMethod]
        public void CorrectClassTypeConvertedToDtoCollection()
        {
            // Arrange             

            // Act
            var actualProductDtos = converter.ConvertTo(productDtos);

            // Assert            
            Assert.IsInstanceOfType(actualProductDtos, typeof(IEnumerable<ProductModel>));
        }

        [TestMethod]
        public void CorrectAllItemsTypesConvertedToDtoCollection()
        {
            // Arrange             

            // Act
            var actualProductDtos = converter.ConvertTo(productDtos);

            // Assert            
            CollectionAssert.AllItemsAreInstancesOfType(actualProductDtos.ToList(), typeof(ProductModel));
        }

        [TestMethod]
        public void ConvertToDtoCollectionIsNotNull()
        {
            // Arrange             

            // Act
            var actualProductDtos = converter.ConvertTo(productDtos);

            // Assert            
            Assert.IsNotNull(actualProductDtos);
        }

        [TestMethod]
        public void ConvertToDtoCollectionAllItemsAreNotNull()
        {
            // Arrange             

            // Act
            var actualProductDtos = converter.ConvertTo(productDtos);

            // Assert            
            CollectionAssert.AllItemsAreNotNull(actualProductDtos.ToList());
        }

        [TestMethod]
        [Description("Is Id property value converted correct")]
        [DataRow(7)]
        [DataRow(0)]
        [DataRow(-5)]
        public void ConvertToDtoIdPropertyValueInCollectionIsSameId(int expectedId)
        {
            // Arrange 
            productDtos.Last().Id = expectedId;

            // Act
            var actualProductDtos = converter.ConvertTo(productDtos);

            // Assert            
            Assert.AreEqual(expectedId, actualProductDtos.Last().Id);
        }

        [TestMethod]
        [Description("Is name property value converted correct")]
        [DataRow("Name 1 !@~#$%^&*()_+=-\\||'\"?/.><,")]
        [DataRow(null)]
        [DataRow("")]
        public void ConvertToDtoNamePropertyValueInCollectionIsSameName(string expectedName)
        {
            // Arrange 
            productDtos.First().Name = expectedName;

            // Act
            var actualProductDtos = converter.ConvertTo(productDtos);

            // Assert            
            Assert.AreEqual(expectedName, actualProductDtos.First().Name);
        }

        [TestMethod]
        [Description("Is Description property value converted correct")]
        [DataRow("Description 1 !@~#$%^&*()_+=-\\||'\"?/.><,")]
        [DataRow(null)]
        [DataRow("")]
        public void ConvertToDtoDescriptionPropertyValueInCollectionIsSameDescription(string expectedDescription)
        {
            // Arrange 
            productDtos.Last().Description = expectedDescription;

            // Act
            var actualProductDtos = converter.ConvertTo(productDtos);

            // Assert            
            Assert.AreEqual(expectedDescription, actualProductDtos.Last().Description);
        }

        [TestMethod]
        [Description("Is AvailableCount property value converted correct")]
        [DataRow(7)]
        [DataRow(0)]
        [DataRow(-5)]
        public void ConvertToDtoAvailableCountPropertyValueInCollectionIsSameAvailableCount(int expectedAvailableCount)
        {
            // Arrange 
            productDtos.Last().AvailableCount = expectedAvailableCount;

            // Act
            var actualProductDtos = converter.ConvertTo(productDtos);

            // Assert            
            Assert.AreEqual(expectedAvailableCount, actualProductDtos.Last().AvailableCount);
        }

        [TestMethod]
        [Description("Is Price property value converted correct")]
        [DataRow(7.0)]
        [DataRow(0.0)]
        [DataRow(-5.894948)]
        public void ConvertToDtoPricePropertyValueInCollectionIsSamePrice(double expectedPrice)
        {
            // Arrange 
            var decimalExpectedPrice = (decimal)expectedPrice;            
            productDtos.Last().Price = decimalExpectedPrice;

            // Act
            var actualProductDtos = converter.ConvertTo(productDtos);

            // Assert            
            Assert.AreEqual(decimalExpectedPrice, actualProductDtos
                .Last()
                .Price);
        }

        [TestMethod]     
        [DataRow("name 1", "Description 1 !@~#$%^&*()_+=-\\||'\"?/.><")]
        [DataRow("","")]       
        public void ConvertToDtoCategoriesPropertyValueInCollectionCategoriesConvertedCorrect(string name1, string name2)
        {
            // Arrange             
            var productDto2 = new ProductDto()
            {
                Name = "Product test",
                Categories = name1 + "," + name2
            };
            
            var productDtos = new List<ProductDto>()
            {
                productDto,
                productDto2
            };

            // Act
            var actualProductDtos = converter.ConvertTo(productDtos);            
            var actualCategoryModel2 = actualProductDtos.First(pr => pr.Name.Equals(productDto2.Name));

            // Assert
            Assert.IsTrue(actualCategoryModel2.CategoryList.Any(c => c.Name == name2));
        }
    }
}
