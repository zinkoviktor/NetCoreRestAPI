using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repositories
{
    public class CategoryRepository<TId> : ICategoryRepository<TId>
    {
        public CategoryModel<TId> GetById(TId id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<CategoryModel<TId>> GetAll()
        {
            var categories = new List<CategoryModel<TId>>
            {
                new CategoryModel<TId>()
                {                    
                    Name = "Laptops",
                    Description = "Shop Laptops and find popular brands. Save money."
                },
                new CategoryModel<TId>()
                {                    
                    Name = "Printers",
                    Description = "The Best Printers for 2020."
                },
                new CategoryModel<TId>()
                {                    
                    Name = "Sale",
                    Description = "Shop all sale items"
                }
            };

            return categories.AsQueryable();
        }

        public IQueryable<CategoryModel<TId>> Create(ICollection<CategoryModel<TId>> categoryModels)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ICollection<CategoryModel<TId>> categoryModels)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(ICollection<CategoryModel<TId>> categoryModels)
        {
            throw new System.NotImplementedException();
        }
    }
}
