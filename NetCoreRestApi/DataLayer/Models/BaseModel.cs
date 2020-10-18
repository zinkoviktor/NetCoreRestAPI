using Newtonsoft.Json;

namespace DataLayer.Models
{
    public class BaseModel<TId>
    {
        [JsonProperty(Order = 0)]
        public TId Id { get; set; }
    }
}
