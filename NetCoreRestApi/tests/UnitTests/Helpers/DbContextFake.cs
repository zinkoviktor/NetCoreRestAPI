using DataLayer.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Helpers
{
    public class DbContextFake : IDbContext
    {
        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }
    }
}
