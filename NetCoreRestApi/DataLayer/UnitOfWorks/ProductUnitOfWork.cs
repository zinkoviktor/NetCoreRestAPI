using DataLayer.Entities;
using DataLayer.Repositories;
using DataLayer.UnitOfWorks.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.UnitOfWorks
{
    public class ProductUnitOfWork<TId> : IProductUnitOfWork<TId>
    {
        private IProductRepository<TId> _productRepository;

        public ProductUnitOfWork(IProductRepository<TId> productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductEntity<TId> GetById(TId id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ProductEntity<TId>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ProductEntity<TId>> Create(ICollection<ProductEntity<TId>> entities)
        {
            throw new System.NotImplementedException();
        }        

        public IQueryable<ProductEntity<TId>> Update(ICollection<ProductEntity<TId>> entity)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ProductEntity<TId>> Delete(ICollection<ProductEntity<TId>> id)
        {
            throw new System.NotImplementedException();
        }

        public int Save()
        {
            throw new System.NotImplementedException();
        }
    }
}
