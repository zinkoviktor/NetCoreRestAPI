using System;

namespace DataLayer.Entities
{
    public class BaseEntity : IEntity
    {
        public int ID { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
