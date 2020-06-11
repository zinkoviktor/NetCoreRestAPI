using DataLayer.Models;
using DataLayer.Repositories;
using System.Linq;

namespace BusinessLayer.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly IRepository<ProductModel> Repository;

        public ProductManager(IRepository<ProductModel> repository)
        {
            Repository = repository;
        }

        public IQueryable<ProductModel> GetAll()
        {
            return Repository.GetAll();
        }        
    }
}