using DataLayer.UnitOfWorks.Interfaces;

namespace DataLayer.UnitOfWorks
{
    public abstract class BaseUnitOfWork: IBaseUnitOfWork
    {
        private IDbContext _dbContext;

        public BaseUnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual int Save()
        {
            return _dbContext.Save();
        }
    }
}
