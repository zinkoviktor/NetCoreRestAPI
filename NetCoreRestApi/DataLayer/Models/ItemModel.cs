namespace DataLayer.Models
{
    public class ItemModel<TId> : BaseModel<TId>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
