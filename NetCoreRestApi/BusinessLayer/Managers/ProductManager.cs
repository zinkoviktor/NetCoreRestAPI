using DataLayer.Models;
using DataLayer.Repositories;
using System.Linq;

namespace BusinessLayer.Managers
{
    public class ProductManager<TId> : IProductManager<ProductModel<TId>>
    {
        private readonly IRepository<ProductModel<TId>, TId> _repository;

        public ProductManager(IRepository<ProductModel<TId>, TId> repository)
        {
            _repository = repository;
        }

        public IQueryable<ProductModel<TId>> GetAll()
        {
            return _repository.GetAll();
        }        
    }
}