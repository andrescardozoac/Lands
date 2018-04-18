namespace Lands.Models
{
    using Newtonsoft.Json;

    public class Language
    {
        [JsonProperty(PropertyName = "iso639_1")] //Par cambiar el nombre que recibe de JSON
        public string Iso639_1 { get; set; }

        [JsonProperty(PropertyName = "iso639_2")] //Par cambiar el nombre que recibe de JSON
        public string Iso639_2 { get; set; }

        [JsonProperty(PropertyName = "name")] //Par cambiar el nombre que recibe de JSON
        public string Name { get; set; }

        [JsonProperty(PropertyName = "nativeName")] //Par cambiar el nombre que recibe de JSON
        public string NativeName { get; set; }



    }
}
