namespace ServiceLayer.DataTransferObjects
{
    public class ItemDto<TId> : BaseDto<TId>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
