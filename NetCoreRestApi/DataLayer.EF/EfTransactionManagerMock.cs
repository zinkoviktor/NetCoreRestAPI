using DataLayer.interfaces;

namespace DataLayer.EF
{
    public class EfTransactionManagerMock : ITransactionManager
    {
        private readonly IDbContext _dbContext;

        public EfTransactionManagerMock(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void BeginTransaction()
        {
        }

        public void Commit()
        {
            _dbContext.Save();
        }

        public void Dispose()
        {
        }

        public void Rollback()
        {   
        }
    }
}