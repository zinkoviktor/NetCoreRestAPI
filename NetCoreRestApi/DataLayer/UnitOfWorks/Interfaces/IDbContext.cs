using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.UnitOfWorks
{
    public interface IDbContext
    {
        int Save();
    }
}
