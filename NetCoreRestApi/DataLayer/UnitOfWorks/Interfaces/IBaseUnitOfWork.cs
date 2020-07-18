using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.UnitOfWorks.Interfaces
{
    public interface IBaseUnitOfWork
    {
        int Save();
    }
}
