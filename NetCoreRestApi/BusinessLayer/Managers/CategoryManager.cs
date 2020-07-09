using DataLayer.Models;
using DataLayer.Repositories;
using System.Linq;

namespace BusinessLayer.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository _repository;

        public CategoryManager(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<CategoryModel> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
