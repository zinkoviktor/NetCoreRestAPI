using Common.Converter;
using DataLayer.EF.Entities;
using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.EF.Repositories
{
    public class BaseRepository<TModel, TEntity, TId> : IRepository<TModel, TId> 
        where TModel : BaseModel<TId>
        where TEntity : BaseEntity<TId>
    {
        protected IConverter<TEntity, TModel> Сonverter { get; private set; }
        private DbSet<TEntity> _dbSet;

        public BaseRepository(IDbContext dbContext, IConverter<TEntity, TModel> converter)
        {
            Сonverter = converter;
            _dbSet = dbContext.GetDbSet<TEntity>();
        }

        public virtual TModel GetById(TId id)
        {
            var entity = _dbSet.FirstOrDefault(entity => entity.Id.Equals(id));
            return Сonverter.ConvertTo(entity);
        }

        public virtual IQueryable<TModel> GetAll()
        {
            var entities = _dbSet.ToList();
            return Сonverter.ConvertTo(entities).AsQueryable();
        }

        public virtual IQueryable<TModel> Create(IEnumerable<TModel> models)
        {
            _dbSet.AddRange(Сonverter.ConvertFrom(models));            
            return models.AsQueryable();            
        }

        public virtual IQueryable<TModel> Update(IEnumerable<TModel> models)
        {
            _dbSet.UpdateRange(Сonverter.ConvertFrom(models));           
            return models.AsQueryable();
        }

        public virtual IQueryable<TModel> Delete(IEnumerable<TModel> models)
        {
            _dbSet.RemoveRange(Сonverter.ConvertFrom(models));
            return models.AsQueryable();
        }
    }
}
