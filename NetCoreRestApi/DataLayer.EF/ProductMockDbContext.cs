using DataLayer.EF.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataLayer.EF
{
    public class ProductMockDbContext : ProductsDbContext
    {
        private List<ProductEntity> _productEntities;
        private List<CategoryEntity> _categoryEntities;
        private List<ProductCategoriesEntity> _productCategoryEntities;

        public ProductMockDbContext(DbContextOptions<ProductMockDbContext> options) : base(options)
        {
            SetupCategories();
            SetupProducts();
            SetupProductCategory();

            AddRange(_productCategoryEntities);
            
            SaveChanges();
        }

        private void SetupProducts()
        {
            _productEntities = new List<ProductEntity>
            {
                new ProductEntity()
                {
                    Id = 1,
                    Name = "HP 410",
                    Description = "All-in-One Wireless Ink Tank Color Printer",
                    Price = 90,                    
                    AvailableCount = 9
                },
                new ProductEntity()
                {
                    Id = 2,
                    Name = "Epson L3152",
                    Description = "WiFi All in One Ink Tank Printer",                    
                    Price = 60,                    
                    AvailableCount = 19
                },
                new ProductEntity()
                {
                    Id = 3,
                    Name = "Dell Inspiron 3583",
                    Description = "15.6-inch FHD Laptop",
                    Price = 50,                    
                    AvailableCount = 5
                }
            };
        }

        private void SetupCategories()
        {
            _categoryEntities = new List<CategoryEntity>()
            {
                new CategoryEntity()
                {
                    Id = 1,
                    Name = "Laptops",
                    Description = "Shop Laptops and find popular brands. Save money."
                },
                new CategoryEntity()
                {
                    Id = 2,
                    Name = "Printers",
                    Description = "The Best Printers for 2020."
                },
                new CategoryEntity()
                {
                    Id = 3,
                    Name = "Sale",
                    Description = "Shop all sale items"
                }
            };
        }

        private void SetupProductCategory()
        {
            _productCategoryEntities = new List<ProductCategoriesEntity>()
            {
                new ProductCategoriesEntity()
                {
                    Product = _productEntities[0],
                    Category = _categoryEntities[0]
                },
                new ProductCategoriesEntity()
                {
                    Product = _productEntities[0],
                    Category = _categoryEntities[2]
                },
                new ProductCategoriesEntity()
                {
                    Product = _productEntities[1],
                    Category = _categoryEntities[1]
                },
                new ProductCategoriesEntity()
                {
                    Product = _productEntities[2],
                    Category = _categoryEntities[0]
                },
                new ProductCategoriesEntity()
                {
                    Product = _productEntities[2],
                    Category = _categoryEntities[1]
                },
                new ProductCategoriesEntity()
                {
                    Product = _productEntities[2],
                    Category = _categoryEntities[2]
                }
            };
        }
    }
}
