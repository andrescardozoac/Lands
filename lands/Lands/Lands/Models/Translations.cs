
namespace Lands.Models{

    using Newtonsoft.Json;

    public class Translations
    {
        [JsonProperty(PropertyName = "de")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public string Germany { get; set; }

        [JsonProperty(PropertyName = "es")]
        public string Spanish { get; set; }

        [JsonProperty(PropertyName = "fr")]
        public string French { get; set; }

        [JsonProperty(PropertyName = "ja")]
        public string Japanese { get; set; }

        [JsonProperty(PropertyName = "it")]
        public string Italian { get; set; }

        [JsonProperty(PropertyName = "br")]
        public string Barzilian { get; set; }

        [JsonProperty(PropertyName = "pt")]
        public string Portugues { get; set; }

        [JsonProperty(PropertyName = "nl")]
        public string Dutch { get; set; }

        [JsonProperty(PropertyName = "hr")]
        public string Croatian { get; set; }

        [JsonProperty(PropertyName = "fa")]
        public string Danish { get; set; }

    }
}
