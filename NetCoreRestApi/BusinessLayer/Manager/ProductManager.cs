using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Manager
{
    public class ProductManager : IProductManager
    {     
        public IQueryable<ProductModel> GetAll()
        {
            var productModels = new List<ProductModel>
            {
                new ProductModel()
                {
                    Id = 1,
                    Name = "HP 410",
                    Description = "All-in-One Wireless Ink Tank Color Printer",                    
                    Price = 90,
                    AvailableCount = 9,
                },
                new ProductModel()
                {
                    Id = 2,
                    Name = "Epson L3152",
                    Description = "WiFi All in One Ink Tank Printer",
                    Price = 60,
                    AvailableCount = 19,
                },
                new ProductModel()
                {
                    Id = 3,
                    Name = "Dell Inspiron 3583",
                    Description = "15.6-inch FHD Laptop",
                    Price = 50,
                    AvailableCount = 5,
                }
            };
            return productModels.AsQueryable();
        }        
    }
}