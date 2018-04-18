namespace Lands.Models
{
    using Newtonsoft.Json;

    public class Currency
    {

        [JsonProperty(PropertyName = "code")] //Par cambiar el nombre que recibe de JSON
        public string Code { get; set; }

        [JsonProperty(PropertyName = "name")] //Par cambiar el nombre que recibe de JSON
        public string Name { get; set; }

        [JsonProperty(PropertyName = "symbol")] //Par cambiar el nombre que recibe de JSON
        public string Symbol { get; set; }
    }
}
