using Common.Converter;
using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.Converters;
using ServiceLayer.DataTransferObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.ServiceLayer.Converters
{
    [TestClass]
    public class CategoryServiceConverter_ConvertFrom_Tests
    {
        private IConverter<CategoryDto, CategoryModel> _converter;
        private IComparer _entityComparer;
        private Func<CategoryDto, CategoryDto, bool> _comparerPredicate;

        [TestInitialize]
        public void TestInitialize()
        {
            _converter = new CategoryServiceConverter();

            _comparerPredicate = delegate (CategoryDto dto1, CategoryDto dto2)
            {
                return dto1.Id.Equals(dto2.Id) &&
                    dto1.Name.Equals(dto2.Name) &&
                    dto1.Description.Equals(dto2.Description);
            };

            _entityComparer = new CollectionEqualsComparer<CategoryDto>(_comparerPredicate);
        }

        [TestMethod]
        public void Convert_FromCategoryModel_ItemsAreNotNull()
        {
            // Arrange           
            var categoryModels = new List<CategoryModel>()
            {
                new CategoryModel(),
                new CategoryModel()
                {
                     Id = 0,
                     Name = "",
                     Description = null
                }
            };

            var actual = _converter.ConvertFrom(categoryModels);

            // Assert            
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void Convert_ToCategoryDto_FromCategoryModels()
        {
            // Arrange            
            var categoryModels = new List<CategoryModel>
            {
                new CategoryModel()
                {
                    Id = 1,
                    Name = "Name 1",
                    Description = "Name 1"
                },
                new CategoryModel()
                {
                    Id = 0,
                    Name = "",
                    Description = ""
                }
            };

            var expected = new List<CategoryDto>()
            {
                new CategoryDto()
                {
                    Id = 1,
                    Name = "Name 1",
                    Description = "Name 1"
                },
                new CategoryDto()
                {
                    Id = 0,
                    Name = "",
                    Description = ""
                }
            };

            // Act
            var actual = _converter.ConvertFrom(categoryModels).ToList();

            // Assert            
            CollectionAssert.AreEqual(expected, actual, _entityComparer);
        }
    }
}
