using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Manager
{
    public class CategoryManager : ICategoryManager
    {
        public IQueryable<CategoryModel> GetAll()
        {
            var ID = 1;
            var categories = new List<CategoryModel>
            {
                new StubCategoryModel(ID, "Category1", "Description 1"),
                new StubCategoryModel(++ID, "Category2", "Description 2"),
                new StubCategoryModel(++ID, "Category3", "Description 3")
            };
            return categories.AsQueryable();
        }
    }
}
