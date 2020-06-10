using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLayer.Managers
{
    public class ProductManager : IProductManager
    {        
        private IQueryable<CategoryModel> categoryModels;
        private readonly Expression<Func<CategoryModel, bool>> IsLaptopsCategory = (x) => x.Name.Equals("Laptops");
        private readonly Expression<Func<CategoryModel, bool>> IsPritersCategory = (x) => x.Name.Equals("Printers");
        private readonly Expression<Func<CategoryModel, bool>> IsSaleCategory = (x) => x.Name.Equals("Sale");

        public ProductManager(ICategoryManager categoryManager)
        {
            categoryModels = categoryManager.GetAll();
        }

        public IQueryable<ProductModel> GetAll()
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
                        categoryModels
                            .Where(IsPritersCategory)
                            .FirstOrDefault(),
                        categoryModels
                            .Where(IsSaleCategory)
                            .FirstOrDefault()
                    },
                    Price = 90,
                    AvailableCount = 9,
                },
                new ProductModel()
                {
                    Id = 2,
                    Name = "Epson L3152",
                    Description = "WiFi All in One Ink Tank Printer",
                    CategoryList = new List<CategoryModel>()
                    {
                        categoryModels
                            .Where(IsPritersCategory)
                            .FirstOrDefault()
                    },
                    Price = 60,
                    AvailableCount = 19,
                },
                new ProductModel()
                {
                    Id = 3,
                    Name = "Dell Inspiron 3583",
                    Description = "15.6-inch FHD Laptop",
                    CategoryList = new List<CategoryModel>()
                    {
                        categoryModels
                            .Where(IsLaptopsCategory)
                            .FirstOrDefault(),
                        categoryModels
                            .Where(IsSaleCategory)
                            .FirstOrDefault()
                    },
                    Price = 50,
                    AvailableCount = 5,
                }
            };

            return productModels.AsQueryable();
        }        
    }
}