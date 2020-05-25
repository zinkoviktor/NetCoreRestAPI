using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Manager
{
    public class CategoryManager : ICategoryManager
    {
        public IQueryable<CategoryModel> GetAll()
        {
            var categories = new List<CategoryModel>();
            categories.Add(new StubCategoryModel("Category1", "Description 1"));
            categories.Add(new StubCategoryModel("Category2", "Description 2"));
            categories.Add(new StubCategoryModel("Category3", "Description 3"));
            return categories.AsQueryable();
        }
    }
}
