using DataLayer.EF.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataLayer.EF
{
    public class ProductMockDbContext : ProductsDbContext
    {
        private List<ProductEntity> _productEntities;
        private List<CategoryEntity> _categoryEntities;
        private List<ProductCategoryEntity> _productCategoryEntities;

        public ProductMockDbContext(DbContextOptions<ProductMockDbContext> options) : base(options)
        {            
            SetupCategories();
            SetupProducts();
            SetupProductCategory();

            AddRange(_productEntities);
            AddRange(_categoryEntities);
            AddRange(_productCategoryEntities);

            SaveChanges();
        }

        private void SetupProducts()
        {
            _productEntities = new List<ProductEntity>
            {
                new ProductEntity()
                {
                    Name = "HP 410",
                    Description = "All-in-One Wireless Ink Tank Color Printer",
                    Price = 90,
                    AvailableCount = 9
                },
                new ProductEntity()
                {
                    Name = "Epson L3152",
                    Description = "WiFi All in One Ink Tank Printer",
                    Price = 60,
                    AvailableCount = 19
                },
                new ProductEntity()
                {
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
                    Name = "Laptops",
                    Description = "Shop Laptops and find popular brands. Save money."
                },
                new CategoryEntity()
                {
                    Name = "Printers",
                    Description = "The Best Printers for 2020."
                },
                new CategoryEntity()
                {
                    Name = "Sale",
                    Description = "Shop all sale items"
                }
            };
        }

        private void SetupProductCategory()
        {
            _productCategoryEntities = new List<ProductCategoryEntity>()
            {
                new ProductCategoryEntity()
                {
                    Product = _productEntities[0],
                    Category = _categoryEntities[0]
                },
                new ProductCategoryEntity()
                {
                    Product = _productEntities[0],
                    Category = _categoryEntities[2]
                },
                new ProductCategoryEntity()
                {
                    Product = _productEntities[1],
                    Category = _categoryEntities[1]
                },
                new ProductCategoryEntity()
                {
                    Product = _productEntities[2],
                    Category = _categoryEntities[0]
                },
                new ProductCategoryEntity()
                {
                    Product = _productEntities[2],
                    Category = _categoryEntities[1]
                },
                new ProductCategoryEntity()
                {
                    Product = _productEntities[2],
                    Category = _categoryEntities[2]
                }
            };
        }
    }
}
