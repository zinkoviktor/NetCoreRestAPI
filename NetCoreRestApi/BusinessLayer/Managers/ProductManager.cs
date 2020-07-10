using DataLayer.Models;
using DataLayer.Repositories;
using System.Linq;

namespace BusinessLayer.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _repository;

        public ProductManager(IProductRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<ProductModel> GetAll()
        {
            return _repository.GetAll();
        }        
    }
}