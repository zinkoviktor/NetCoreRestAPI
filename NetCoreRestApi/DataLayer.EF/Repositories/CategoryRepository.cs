﻿using Common.Converter;
using DataLayer.EF.Entities;
using DataLayer.Models;
using DataLayer.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.EF.Repositories
{
    public class CategoryRepository : BaseRepository<CategoryModel, CategoryEntity, int>, ICategoryRepository
    {
        public CategoryRepository(IRepositoryDbContext<CategoryEntity> dbContext,
            IConverter<CategoryEntity, CategoryModel> converter)
                : base(dbContext, converter)
        {                        
        }

        public override IQueryable<CategoryModel> GetAll()
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