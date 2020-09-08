using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.Converters;
using ServiceLayer.DataTransferObjects;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.ConvertersTests.ServiceLayer.CategoryConverter
{
    [TestClass]    
    public class ConvertToCategoryModelTests
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
        public void CorrectClassTypeConvertedToModel()
        {
            // Arrange

            // Act
            var actualCategoryModel = converter.ConvertTo(categoryDto);

            // Assert            
            Assert.IsInstanceOfType(actualCategoryModel, typeof(CategoryModel));           
        }

        [TestMethod]        
        public void ConvertToModelIsNotNull()
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
        public void ConvertToModelIdPropertyValueIsSameId(int expectedId)
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
        public void ConvertToModelNamePropertyValueIsSameName(string expectedName)
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
        public void ConvertToModelDescriptionPropertyValueIsSameDescription(string expectedDescription)
        {
            // Arrange 
            categoryDto.Description = expectedDescription;

            // Act
            var actualCategoryModel = converter.ConvertTo(categoryDto);

            // Assert            
            Assert.AreEqual(expectedDescription, actualCategoryModel.Description);
        }

        [TestMethod]
        public void CorrectClassTypeConvertedToModelCollection()
        {
            // Arrange             

            // Act
            var actualCategoryModels = converter.ConvertTo(categoryDtos);

            // Assert            
            Assert.IsInstanceOfType(actualCategoryModels, typeof(IEnumerable<CategoryModel>));
        }

        [TestMethod]
        public void CorrectAllItemsTypesConvertedToModelCollection()
        {
            // Arrange             

            // Act
            var actualCategoryModels = converter.ConvertTo(categoryDtos);

            // Assert            
            CollectionAssert.AllItemsAreInstancesOfType(actualCategoryModels.ToList(), typeof(CategoryModel));
        }

        [TestMethod]
        public void ConvertToModelCollectionIsNotNull()
        {
            // Arrange             

            // Act
            var actualCategoryModels = converter.ConvertTo(categoryDtos);

            // Assert            
            Assert.IsNotNull(actualCategoryModels);
        }

        [TestMethod]
        public void ConvertToModelsCollectionAllItemsAreNotNull()
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
        public void ConvertToModelIdPropertyValueInCollectionIsSameId(int expectedId)
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
        public void ConvertToModelNamePropertyValueInCollectionIsSameName(string expectedName)
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
        public void ConvertToModelDescriptionPropertyValueInCollectionIsSameDescription(string expectedDescription)
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
