using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Manager
{
    public class CategoryManager : ICategoryManager
    {
        public IQueryable<CategoryModel> GetAll()
        {
            var id = 1;
            var categories = new List<CategoryModel>
            {
                new StubCategoryModel(id, "Category1", "Description 1"),
                new StubCategoryModel(++id, "Category2", "Description 2"),
                new StubCategoryModel(++id, "Category3", "Description 3")
            };
            return categories.AsQueryable();
        }
    }
}
