﻿using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Manager
{
    public class CategoryManager : ICategoryManager
    {
        public IQueryable<CategoryModel> GetAll()
        {
            var categories = new List<CategoryModel>
            {
                new CategoryModel()
                {
                    Id = 1,
                    Name = "Laptops",
                    Description = "Shop Laptops and find popular brands. Save money."
                },
                new CategoryModel()
                {
                    Id = 2,
                    Name = "Printers",
                    Description = "The Best Printers for 2020."
                },
                new CategoryModel()
                {
                    Id = 3,
                    Name = "Sale",
                    Description = "Shop all sale items"
                }
            };
            return categories.AsQueryable();
        }
    }
}
