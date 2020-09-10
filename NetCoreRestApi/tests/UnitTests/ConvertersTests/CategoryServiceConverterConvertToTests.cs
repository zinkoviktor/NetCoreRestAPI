using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.Converters;
using ServiceLayer.DataTransferObjects;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.ConvertersTests
{
    [TestClass]    
    public class CategoryServiceConverterConvertToTests
    {
        CategoryServiceConverter converter;
        CategoryDto categoryDto;
        List<CategoryDto> categoryDtos;

        [TestInitialize]
        public void TestInitialize()
        {
            converter = new CategoryServiceConverter();

            categoryDto = new CategoryDto()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description",
            };

            categoryDtos = new List<CategoryDto>()
            {
                categoryDto,
                new CategoryDto()
                {
                     Id = 0,
                     Name = "",
                     Description = null,
                }
            };
        }
        
        [TestMethod]         
        public void CorrectClassTypeConvertedToCategoryModel()
        {
            // Arrange

            // Act
            var actualCategoryModel = converter.ConvertTo(categoryDto);

            // Assert            
            Assert.IsInstanceOfType(actualCategoryModel, typeof(CategoryModel));           
        }

        [TestMethod]        
        public void ConvertToCategoryModelIsNotNull()
        {
            // Arrange 

            // Act
            var actualCategoryModel = converter.ConvertTo(categoryDto);

            // Assert            
            Assert.IsNotNull(actualCategoryModel);
        }

        [TestMethod]
        [Description("Is Id property value converted correct")]
        [DataRow(1)]
        [DataRow(0)]
        [DataRow(-5)]
        public void ConvertToCategoryModelIdPropertyValueIsSameId(int expectedId)
        {
            // Arrange 
            categoryDto.Id = expectedId;

            // Act
            var actualCategoryModel = converter.ConvertTo(categoryDto);

            // Assert            
            Assert.AreEqual(expectedId, actualCategoryModel.Id);
        }

        [TestMethod]
        [Description("Is name property value converted correct")]
        [DataRow("Name 1 !@~#$%^&*()_+=-\\||'\"?/.><,")]
        [DataRow(null)]
        [DataRow("")]
        public void ConvertToCategoryModelNamePropertyValueIsSameName(string expectedName)
        {
            // Arrange 
            categoryDto.Name = expectedName;

            // Act
            var actualCategoryModel = converter.ConvertTo(categoryDto);

            // Assert            
            Assert.AreEqual(expectedName, actualCategoryModel.Name);
        }

        [TestMethod]
        [Description("Is Description property value converted correct")]
        [DataRow("Description 1 !@~#$%^&*()_+=-\\||'\"?/.><,")]
        [DataRow(null)]
        [DataRow("")]
        public void ConvertToCategoryModelDescriptionPropertyValueIsSameDescription(string expectedDescription)
        {
            // Arrange 
            categoryDto.Description = expectedDescription;

            // Act
            var actualCategoryModel = converter.ConvertTo(categoryDto);

            // Assert            
            Assert.AreEqual(expectedDescription, actualCategoryModel.Description);
        }

        [TestMethod]
        public void CorrectClassTypeConvertedToCategoryModelCollection()
        {
            // Arrange             

            // Act
            var actualCategoryModels = converter.ConvertTo(categoryDtos);

            // Assert            
            Assert.IsInstanceOfType(actualCategoryModels, typeof(IEnumerable<CategoryModel>));
        }

        [TestMethod]
        public void CorrectAllItemsTypesConvertedToCategoryModelCollection()
        {
            // Arrange             

            // Act
            var actualCategoryModels = converter.ConvertTo(categoryDtos);

            // Assert            
            CollectionAssert.AllItemsAreInstancesOfType(actualCategoryModels.ToList(), typeof(CategoryModel));
        }

        [TestMethod]
        public void ConvertToCategoryModelCollectionIsNotNull()
        {
            // Arrange             

            // Act
            var actualCategoryModels = converter.ConvertTo(categoryDtos);

            // Assert            
            Assert.IsNotNull(actualCategoryModels);
        }

        [TestMethod]
        public void ConvertToCategoryModelsCollectionAllItemsAreNotNull()
        {
            // Arrange             

            // Act
            var actualCategoryModels = converter.ConvertTo(categoryDtos);

            // Assert            
            CollectionAssert.AllItemsAreNotNull(actualCategoryModels.ToList());
        }

        [TestMethod]
        [Description("Is Id property value converted correct")]
        [DataRow(7)]
        [DataRow(0)]
        [DataRow(-5)]
        public void ConvertToCategoryModelIdPropertyValueInCollectionIsSameId(int expectedId)
        {
            // Arrange 
            categoryDtos.Last().Id = expectedId;

            // Act
            var actualCategoryModels = converter.ConvertTo(categoryDtos);

            // Assert            
            Assert.AreEqual(expectedId, actualCategoryModels.Last().Id);
        }

        [TestMethod]
        [Description("Is name property value converted correct")]
        [DataRow("Name 1 !@~#$%^&*()_+=-\\||'\"?/.><,")]
        [DataRow(null)]
        [DataRow("")]
        public void ConvertToCategoryModelNamePropertyValueInCollectionIsSameName(string expectedName)
        {
            // Arrange 
            categoryDtos.First().Name = expectedName;

            // Act
            var actualCategoryModels = converter.ConvertTo(categoryDtos);

            // Assert            
            Assert.AreEqual(expectedName, actualCategoryModels.First().Name);
        }

        [TestMethod]
        [Description("Is Description property value converted correct")]
        [DataRow("Description 1 !@~#$%^&*()_+=-\\||'\"?/.><,")]
        [DataRow(null)]
        [DataRow("")]
        public void ConvertToCategoryModelDescriptionPropertyValueInCollectionIsSameDescription(string expectedDescription)
        {
            // Arrange 
            categoryDtos.Last().Description = expectedDescription;

            // Act
            var actualCategoryModels = converter.ConvertTo(categoryDtos);

            // Assert            
            Assert.AreEqual(expectedDescription, actualCategoryModels.Last().Description);
        }
    }
}
