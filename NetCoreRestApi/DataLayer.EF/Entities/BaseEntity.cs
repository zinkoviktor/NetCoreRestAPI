namespace DataLayer.EF.Entities
{
    public class BaseEntity<TId>
    {
        public TId Id { get; set; }
    }
}
