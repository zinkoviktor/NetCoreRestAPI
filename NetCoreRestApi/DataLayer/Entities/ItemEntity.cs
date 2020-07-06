namespace DataLayer.Entities
{
    public class ItemEntity<TId> : BaseEntity<TId>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
