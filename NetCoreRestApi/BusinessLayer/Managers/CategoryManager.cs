using DataLayer.Models;
using DataLayer.Repositories;
using System.Linq;

namespace BusinessLayer.Managers
{
    public class CategoryManager<TId> : ICategoryManager<CategoryModel<TId>>
    {
        private readonly IRepository<CategoryModel<TId>, TId> _repository;

        public CategoryManager(IRepository<CategoryModel<TId>, TId> repository)
        {
            _repository = repository;
        }

        public IQueryable<CategoryModel<TId>> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
