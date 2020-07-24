using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DataLayer.EF
{
    public class DbSetMock<TEntity> : DbSet<TEntity>
        where TEntity : class
    {
        public override LocalView<TEntity> Local => base.Local;

        public override EntityEntry<TEntity> Add(TEntity entity)
        {
            return base.Add(entity);
        }

        public override ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return base.AddAsync(entity, cancellationToken);
        }

        public override void AddRange(params TEntity[] entities)
        {
            base.AddRange(entities);
        }

        public override void AddRange(IEnumerable<TEntity> entities)
        {
            base.AddRange(entities);
        }

        public override Task AddRangeAsync(params TEntity[] entities)
        {
            return base.AddRangeAsync(entities);
        }

        public override Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return base.AddRangeAsync(entities, cancellationToken);
        }

        public override IAsyncEnumerable<TEntity> AsAsyncEnumerable()
        {
            return base.AsAsyncEnumerable();
        }

        public override IQueryable<TEntity> AsQueryable()
        {
            return base.AsQueryable();
        }

        public override EntityEntry<TEntity> Attach(TEntity entity)
        {
            return base.Attach(entity);
        }

        public override void AttachRange(params TEntity[] entities)
        {
            base.AttachRange(entities);
        }

        public override void AttachRange(IEnumerable<TEntity> entities)
        {
            base.AttachRange(entities);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override TEntity Find(params object[] keyValues)
        {
            return base.Find(keyValues);
        }

        public override ValueTask<TEntity> FindAsync(params object[] keyValues)
        {
            return base.FindAsync(keyValues);
        }

        public override ValueTask<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken)
        {
            return base.FindAsync(keyValues, cancellationToken);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override EntityEntry<TEntity> Remove(TEntity entity)
        {
            return base.Remove(entity);
        }

        public override void RemoveRange(params TEntity[] entities)
        {
            base.RemoveRange(entities);
        }

        public override void RemoveRange(IEnumerable<TEntity> entities)
        {
            base.RemoveRange(entities);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override EntityEntry<TEntity> Update(TEntity entity)
        {
            return base.Update(entity);
        }

        public override void UpdateRange(params TEntity[] entities)
        {
            base.UpdateRange(entities);
        }

        public override void UpdateRange(IEnumerable<TEntity> entities)
        {
            base.UpdateRange(entities);
        }
    }
}
