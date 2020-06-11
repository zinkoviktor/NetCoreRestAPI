using DataLayer.Models;
using DataLayer.Repositories;
using System.Linq;

namespace BusinessLayer.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IRepository<CategoryModel> _repository;

        public CategoryManager(IRepository<CategoryModel> repository)
        {
            _repository = repository;
        }

        public IQueryable<CategoryModel> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
