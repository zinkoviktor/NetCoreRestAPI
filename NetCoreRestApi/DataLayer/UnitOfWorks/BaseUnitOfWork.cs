using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.Repositories.Intefaces;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.UnitOfWorks
{
    public abstract class BaseUnitOfWork<TModel, TId> : IUnitOfWork<TModel, TId>
        where TModel : BaseModel<TId>
    {
        protected readonly IRepository<TModel, TId> _repository;
        protected readonly IDbContext _dbContext;

        public BaseUnitOfWork(IDbContext dbContext, IRepository<TModel, TId> repository)
        {
            _dbContext = dbContext;
            _repository = repository;
        }

        public TModel GetById(TId id)
        {
            return _repository.GetById(id);
        }

        public IQueryable<TModel> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<TModel> Create(IEnumerable<TModel> models)
        {
            return _repository.Create(models);
        }

        public IQueryable<TModel> Delete(IEnumerable<TModel> models)
        {
            return _repository.Delete(models);
        }

        public IQueryable<TModel> Update(IEnumerable<TModel> models)
        {
            return _repository.Update(models);
        }

        public int Save()
        {
            return _dbContext.Save();
        }
    }
}
