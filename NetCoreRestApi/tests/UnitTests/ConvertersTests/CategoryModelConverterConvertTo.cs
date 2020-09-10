using DataLayer.EF.Converters;
using DataLayer.EF.Entities;
using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.ConvertersTests
{
    [TestClass]    
    public class CategoryModelConverterConvertTo
    {
        CategoryModelConverter converter;
        CategoryEntity categoryEntity;
        List<CategoryEntity> categoryEntities;

        [TestInitialize]
        public void TestInitialize()
        {
            converter = new CategoryModelConverter();

            categoryEntity = new CategoryEntity()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description",
            };

            categoryEntities = new List<CategoryEntity>()
            {
                categoryEntity,
                new CategoryEntity()
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
            var actualCategoryModel = converter.ConvertTo(categoryEntity);

            // Assert            
            Assert.IsInstanceOfType(actualCategoryModel, typeof(CategoryModel));           
        }

        [TestMethod]        
        public void ConvertToCategoryModelIsNotNull()
        {
            // Arrange 

            // Act
            var actualCategoryModel = converter.ConvertTo(categoryEntity);

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
            categoryEntity.Id = expectedId;

            // Act
            var actualCategoryModel = converter.ConvertTo(categoryEntity);

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
            categoryEntity.Name = expectedName;

            // Act
            var actualCategoryModel = converter.ConvertTo(categoryEntity);

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
            categoryEntity.Description = expectedDescription;

            // Act
            var actualCategoryModel = converter.ConvertTo(categoryEntity);

            // Assert            
            Assert.AreEqual(expectedDescription, actualCategoryModel.Description);
        }

        [TestMethod]
        public void CorrectClassTypeConvertedToCategoryModelCollection()
        {
            // Arrange             

            // Act
            var actualCategoryModels = converter.ConvertTo(categoryEntities);

            // Assert            
            Assert.IsInstanceOfType(actualCategoryModels, typeof(IEnumerable<CategoryModel>));
        }

        [TestMethod]
        public void CorrectAllItemsTypesConvertedToCategoryModelCollection()
        {
            // Arrange             

            // Act
            var actualCategoryModels = converter.ConvertTo(categoryEntities);

            // Assert            
            CollectionAssert.AllItemsAreInstancesOfType(actualCategoryModels.ToList(), typeof(CategoryModel));
        }

        [TestMethod]
        public void ConvertToCategoryModelCollectionIsNotNull()
        {
            // Arrange             

            // Act
            var actualCategoryModels = converter.ConvertTo(categoryEntities);

            // Assert            
            Assert.IsNotNull(actualCategoryModels);
        }

        [TestMethod]
        public void ConvertToCategoryModelsCollectionAllItemsAreNotNull()
        {
            // Arrange             

            // Act
            var actualCategoryModels = converter.ConvertTo(categoryEntities);

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
            categoryEntities.Last().Id = expectedId;

            // Act
            var actualCategoryModels = converter.ConvertTo(categoryEntities);

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
            categoryEntities.First().Name = expectedName;

            // Act
            var actualCategoryModels = converter.ConvertTo(categoryEntities);

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
            categoryEntities.Last().Description = expectedDescription;

            // Act
            var actualCategoryModels = converter.ConvertTo(categoryEntities);

            // Assert            
            Assert.AreEqual(expectedDescription, actualCategoryModels.Last().Description);
        }
    }
}
