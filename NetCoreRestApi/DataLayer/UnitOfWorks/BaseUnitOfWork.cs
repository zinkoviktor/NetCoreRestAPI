using System.Collections.Generic;
using System.Linq;

namespace DataLayer.UnitOfWorks
{
    public abstract class BaseUnitOfWork<Model, TId> : IUnitOfWork<Model, TId>
    {
        private IDbContext _dbContext;

        public BaseUnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Model> Create(ICollection<Model> models)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Model> Delete(ICollection<Model> models)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Model> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Model GetById(TId id)
        {
            throw new System.NotImplementedException();
        }

        public int Save()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Model> Update(ICollection<Model> models)
        {
            throw new System.NotImplementedException();
        }
    }
}
