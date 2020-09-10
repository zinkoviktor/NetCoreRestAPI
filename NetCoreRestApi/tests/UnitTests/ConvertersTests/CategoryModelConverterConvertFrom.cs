using DataLayer.EF.Converters;
using DataLayer.EF.Entities;
using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.ConvertersTests
{
    [TestClass]    
    public class CategoryModelConverterConvertFrom
    {
        CategoryModelConverter converter;
        CategoryModel categoryModel;
        List<CategoryModel> categoryModels;

        [TestInitialize]
        public void TestInitialize()
        {
            converter = new CategoryModelConverter();

            categoryModel = new CategoryModel()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description",
            };

            categoryModels = new List<CategoryModel>()
            {
                categoryModel,
                new CategoryModel()
                {
                     Id = 0,
                     Name = "",
                     Description = null,
                }
            };
        }
        
        [TestMethod]         
        public void CorrectClassTypeConvertedToCategoryEntity()
        {
            // Arrange
            // Act
            var actualCategoryEntity = converter.ConvertFrom(categoryModel);

            // Assert            
            Assert.IsInstanceOfType(actualCategoryEntity, typeof(CategoryEntity));           
        }

        [TestMethod]        
        public void ConvertToCategoryEntityIsNotNull()
        {
            // Arrange 
            // Act
            var actualCategoryEntity = converter.ConvertFrom(categoryModel);

            // Assert            
            Assert.IsNotNull(actualCategoryEntity);
        }

        [TestMethod]
        [Description("Is Id property value converted correct")]
        [DataRow(1)]
        [DataRow(0)]
        [DataRow(-5)]
        public void ConvertToCategoryEntityIdPropertyValueIsSameId(int expectedId)
        {
            // Arrange 
            categoryModel.Id = expectedId;

            // Act
            var actualCategoryEntity = converter.ConvertFrom(categoryModel);

            // Assert            
            Assert.AreEqual(expectedId, actualCategoryEntity.Id);
        }

        [TestMethod]
        [Description("Is name property value converted correct")]
        [DataRow("Name 1 !@~#$%^&*()_+=-\\||'\"?/.><,")]
        [DataRow(null)]
        [DataRow("")]
        public void ConvertToCategoryEntityNamePropertyValueIsSameName(string expectedName)
        {
            // Arrange 
            categoryModel.Name = expectedName;

            // Act
            var actualCategoryEntity = converter.ConvertFrom(categoryModel);

            // Assert            
            Assert.AreEqual(expectedName, actualCategoryEntity.Name);
        }

        [TestMethod]
        [Description("Is Description property value converted correct")]
        [DataRow("Description 1 !@~#$%^&*()_+=-\\||'\"?/.><,")]
        [DataRow(null)]
        [DataRow("")]
        public void ConvertToCategoryEntityDescriptionPropertyValueIsSameDescription(string expectedDescription)
        {
            // Arrange 
            categoryModel.Description = expectedDescription;

            // Act
            var actualCategoryEntity = converter.ConvertFrom(categoryModel);

            // Assert            
            Assert.AreEqual(expectedDescription, actualCategoryEntity.Description);
        }

        [TestMethod]
        public void CorrectClassTypeConvertedToCategoryEntityCollection()
        {
            // Arrange
            // Act
            var actualCategoryEntities = converter.ConvertFrom(categoryModels);

            // Assert            
            Assert.IsInstanceOfType(actualCategoryEntities, typeof(IEnumerable<CategoryEntity>));
        }

        [TestMethod]
        public void CorrectAllItemsTypesConvertedToCategoryEntityCollection()
        {
            // Arrange
            // Act
            var actualCategoryEntities = converter.ConvertFrom(categoryModels);

            // Assert            
            CollectionAssert.AllItemsAreInstancesOfType(actualCategoryEntities.ToList(), typeof(CategoryEntity));
        }

        [TestMethod]
        public void ConvertToCategoryEntityCollectionIsNotNull()
        {
            // Arrange             

            // Act
            var actualCategoryEntities = converter.ConvertFrom(categoryModels);

            // Assert            
            Assert.IsNotNull(actualCategoryEntities);
        }

        [TestMethod]
        public void ConvertToCategoryEntityCollectionAllItemsAreNotNull()
        {
            // Arrange             

            // Act
            var actualCategoryEntities = converter.ConvertFrom(categoryModels);

            // Assert            
            CollectionAssert.AllItemsAreNotNull(actualCategoryEntities.ToList());
        }

        [TestMethod]
        [Description("Is Id property value converted correct")]
        [DataRow(7)]
        [DataRow(0)]
        [DataRow(-5)]
        public void ConvertToCategoryEntityIdPropertyValueInCollectionIsSameId(int expectedId)
        {
            // Arrange 
            categoryModels.Last().Id = expectedId;

            // Act
            var actualCategoryEntities = converter.ConvertFrom(categoryModels);

            // Assert            
            Assert.AreEqual(expectedId, actualCategoryEntities.Last().Id);
        }

        [TestMethod]
        [Description("Is name property value converted correct")]
        [DataRow("Name 1 !@~#$%^&*()_+=-\\||'\"?/.><,")]
        [DataRow(null)]
        [DataRow("")]
        public void ConvertToCategoryEntityNamePropertyValueInCollectionIsSameName(string expectedName)
        {
            // Arrange 
            categoryModels.First().Name = expectedName;

            // Act
            var actualCategoryEntities = converter.ConvertFrom(categoryModels);

            // Assert            
            Assert.AreEqual(expectedName, actualCategoryEntities.First().Name);
        }

        [TestMethod]
        [Description("Is Description property value converted correct")]
        [DataRow("Description 1 !@~#$%^&*()_+=-\\||'\"?/.><,")]
        [DataRow(null)]
        [DataRow("")]
        public void ConvertToCategoryEntityDescriptionPropertyValueInCollectionIsSameDescription(string expectedDescription)
        {
            // Arrange 
            categoryModels.Last().Description = expectedDescription;

            // Act
            var actualCategoryEntities = converter.ConvertFrom(categoryModels);

            // Assert            
            Assert.AreEqual(expectedDescription, actualCategoryEntities.Last().Description);
        }
    }
}
