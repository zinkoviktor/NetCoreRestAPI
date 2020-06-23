using DataLayer.Models;
using DataLayer.Repositories;
using System.Linq;

namespace BusinessLayer.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly IRepository<ProductModel> _repository;

        public ProductManager(IRepository<ProductModel> repository)
        {
            _repository = repository;
        }

        public IQueryable<ProductModel> GetAll()
        {
            return _repository.GetAll();
        }        
    }
}