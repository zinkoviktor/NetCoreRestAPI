using DataLayer.Entities;
using System;
using System.Linq;

namespace DataLayer.Repositories
{
    public class ProductRepository : IRepository<ProductEntity>
    {
        public void Create(ProductEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProductEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
