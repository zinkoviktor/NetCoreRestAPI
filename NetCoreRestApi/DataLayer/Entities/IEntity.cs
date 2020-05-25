using System;

namespace DataLayer.Entities
{
    public interface IEntity
    {
        int ID { get; set; }
        DateTime CreateAt { get; set; }
    }
}
