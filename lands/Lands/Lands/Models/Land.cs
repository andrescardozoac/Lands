
namespace Lands.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Land
    {
        [JsonProperty(PropertyName = "name")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public string Name { get; set; }

        [JsonProperty(PropertyName = "topLevelDomain")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public List<string> TopLevelDomain { get; set; }

        [JsonProperty(PropertyName = "alpha2Code")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public string Alpha2Code { get; set; }

        [JsonProperty(PropertyName = "alpha3Code")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public string Alpha3Code { get; set; }

        [JsonProperty(PropertyName = "callingCodes")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public List<string> CallingCodes { get; set; }

        [JsonProperty(PropertyName = "capital")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public string Capital { get; set; }

        [JsonProperty(PropertyName = "altSpellings")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public List<string> AltSpellings { get; set; }

        [JsonProperty(PropertyName = "region")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public string Region { get; set; }

        [JsonProperty(PropertyName = "subregion")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public string Subregion { get; set; }

        [JsonProperty(PropertyName = "population")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public int Population { get; set; }

        [JsonProperty(PropertyName = "latlng")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public List<double> Latlng { get; set; }

        [JsonProperty(PropertyName = "demonym")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public string Demonym { get; set; }

        [JsonProperty(PropertyName = "area")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public double? Area { get; set; }

        [JsonProperty(PropertyName = "gini")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public double? Gini { get; set; }

        [JsonProperty(PropertyName = "timezones")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public List<string> Timezones { get; set; }

        [JsonProperty(PropertyName = "borders")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public List<string> Borders { get; set; }

        [JsonProperty(PropertyName = "nativeName")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public string NativeName { get; set; }

        [JsonProperty(PropertyName = "numericCode")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public string NumericCode { get; set; }

        [JsonProperty(PropertyName = "currencies")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public List<Currency> Currencies { get; set; }

        [JsonProperty(PropertyName = "languages")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public List<Language> Languages { get; set; }

        [JsonProperty(PropertyName = "translations")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public Translations Translations { get; set; }

        [JsonProperty(PropertyName = "flag")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public string Flag { get; set; }

        [JsonProperty(PropertyName = "regionalBlocs")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public List<RegionalBloc> RegionalBlocs { get; set; }

        [JsonProperty(PropertyName = "cioc")] //Es para colocarle un alias en C# a la propiedad que viene por JSON
        public string Cioc { get; set; }


    }
}
