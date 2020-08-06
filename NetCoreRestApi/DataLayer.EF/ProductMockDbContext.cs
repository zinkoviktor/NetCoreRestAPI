using DataLayer.EF.Converters;
using DataLayer.EF.Entities;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataLayer.EF
{
    public class ProductMockDbContext : ProductsDbContext
    {
        public ProductMockDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {
            AddRange(GetProductsMock());
            Save();
        }

        private IEnumerable<ProductEntity> GetProductsMock()
        {
            var productModels = new List<ProductModel>
            {
                new ProductModel()
                {
                    Id = 1,
                    Name = "HP 410",
                    Description = "All-in-One Wireless Ink Tank Color Printer",
                    CategoryList = new List<CategoryModel>()
                    {
                       new CategoryModel()
                            {
                                Id = 1,
                                Name = "Laptops",
                                Description = "Shop Laptops and find popular brands. Save money."
                            }                       
                    },
                    Price = 90,
                    AvailableCount = 9
                },
                new ProductModel()
                {
                    Id = 2,
                    Name = "Epson L3152",
                    Description = "WiFi All in One Ink Tank Printer",
                    CategoryList = new List<CategoryModel>()
                    {
                        new CategoryModel()
                            {
                                Id = 2,
                                Name = "Printers",
                                Description = "The Best Printers for 2020."
                            }
                    },
                    Price = 60,
                    AvailableCount = 19
                },
                new ProductModel()
                {
                    Id = 3,
                    Name = "Dell Inspiron 3583",
                    Description = "15.6-inch FHD Laptop",
                    CategoryList = new List<CategoryModel>()
                    {
                        new CategoryModel()
                            {
                                Id = 3,
                                Name = "Sale",
                                Description = "Shop all sale items"
                            }
                    },
                    Price = 50,
                    AvailableCount = 5
                }
            };

            var converter = new ProductModelConverter(new CategoryModelConverter());
            return converter.ConvertFrom(productModels);
        }
    }
}
