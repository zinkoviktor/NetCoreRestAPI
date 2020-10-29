using DataLayer.EF;
using DataLayer.EF.Entities;
using DataLayer.Models;
using DataLayer.Repositories.Intefaces;
using DataLayer.UnitOfWorks.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using UnitTests.Helpers.CategoryHelpers;

namespace UnitTests.DataLayer.UnitOfWorks
{
    [TestClass]
    public class CategoryUnitOfWorkTests : BaseTest
    {
        private ICategoryUnitOfWork UnitOfWork { get; set; }
        private IDbContext DbContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            Services.AddSingleton<ProductsDbContext>()
                    .AddSingleton<IUnitOfWorkContext>(sp => sp.GetRequiredService<ProductsDbContext>())
                    .AddSingleton<IDbContext>(sp => sp.GetRequiredService<ProductsDbContext>())
                    .AddDbContext<ProductsDbContext>(opt => opt.UseInMemoryDatabase(
                        databaseName: Guid.NewGuid().ToString()), ServiceLifetime.Singleton, ServiceLifetime.Singleton);

            ConfigureServices();

            UnitOfWork = ServiceProvider.GetRequiredService<ICategoryUnitOfWork>();
            DbContext = ServiceProvider.GetRequiredService<IDbContext>();
        }

        [TestMethod]
        public void GetById_CategoryEntity()
        {
            // Arrange
            var categories = new List<CategoryEntity>()
            {
                new CategoryEntity()
                {
                    Id = 1,
                    Name = "HP 410",
                    Description = "All-in-One Wireless Ink Tank Color Printer"
                },
                new CategoryEntity()
                {
                    Id = 2,
                    Name = "Epson L3152",
                    Description = "WiFi All in One Ink Tank Printer"
                }
            };
            var expected = new CategoryModel()
            {
                Id = 1,
                Name = "HP 410",
                Description = "All-in-One Wireless Ink Tank Color Printer"
            };

            DbContext.GetDbSet<CategoryEntity>().AddRange(categories);
            DbContext.Save();

            // Act
            var actual = UnitOfWork.GetById(expected.Id);

            // Assert     
            Assert.IsTrue(CategoryModelComparer.Instance.AreEquals(expected, actual));
        }
    }
}
