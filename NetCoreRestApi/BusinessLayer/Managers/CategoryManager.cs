using DataLayer.Models;
using DataLayer.Repositories;
using System.Linq;

namespace BusinessLayer.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IRepository<CategoryModel> Repository;

        public CategoryManager(IRepository<CategoryModel> repository)
        {
            Repository = repository;
        }

        public IQueryable<CategoryModel> GetAll()
        {
            return Repository.GetAll();
        }
    }
}
