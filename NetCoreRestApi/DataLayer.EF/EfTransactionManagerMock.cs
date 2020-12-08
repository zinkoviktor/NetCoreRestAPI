using DataLayer.interfaces;

namespace DataLayer.EF
{
    public class EfTransactionManagerMock : ITransactionManager
    {
        public void BeginTransaction()
        {
        }

        public void Commit()
        {
        }

        public void Dispose()
        {
        }

        public void Rollback()
        {   
        }
    }
}