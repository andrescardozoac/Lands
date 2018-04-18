

namespace Lands.Models
{

    using Newtonsoft.Json;

    public class RegionalBloc
    {
        [JsonProperty(PropertyName = "acronym")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public string Acronym { get; set; }

        [JsonProperty(PropertyName = "name")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public string Name { get; set; }
    }
}
