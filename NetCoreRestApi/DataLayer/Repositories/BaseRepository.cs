namespace DataLayer.Repositories
{
    public class BaseRepository<TModel, TId>
    {
        public TModel GetById(TId id)
        {
            throw new System.NotImplementedException();
        }
    }
}
