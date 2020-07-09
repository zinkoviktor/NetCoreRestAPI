using DataLayer.UnitOfWorks.Interfaces;

namespace DataLayer.UnitOfWorks
{
    public abstract class BaseUnitOfWork<TEntity, TId> : IBaseUnitOfWork
    {
        private IDbContext _dbContext;

        public BaseUnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity GetById(TId id)
        {
            throw new System.NotImplementedException();
        }

        public virtual int Save()
        {
            return _dbContext.Save();
        }
    }
}
