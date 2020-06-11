using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repositories
{
    public class CategoryRepository : IRepository<CategoryModel>
    {
        public CategoryModel GetById(int id)
        {
            throw new System.NotImplementedException();
        }

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

        public IQueryable<CategoryModel> Create(CategoryModel entity)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<CategoryModel> Update(CategoryModel entity)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<CategoryModel> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
