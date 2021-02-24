using Newtonsoft.Json;

namespace RoofStockAssesment.Common.Models
{
    public class StockPropertiesModel
    {
        [JsonProperty("properties")]
        public PropertiesObject[] Properties { get; set; }
    }
    public class PropertiesObject {

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("physical")]
        public Physical Physical { get; set; }
        [JsonProperty("financial")]
        public Financial Financial { get; set; }
        [JsonProperty("address")]
        public Address Address { get; set; }
        [JsonProperty("mainImageUrl")]
        public string MainImageUrl { get; set; }
        [JsonProperty("resources")]
        public Resources Resources { get; set; }
    }
    public class Physical {
        [JsonProperty("yearBuilt")]
        public string YearBuilt { get; set; }
        [JsonProperty("bathRooms")]
        public string Bathrooms { get; set; }
        [JsonProperty("bedRooms")]
        public string BedRooms { get; set; }

        [JsonProperty("squareFeet")]
        public string squareFeet { get; set; }

    }
    public class Financial
    {
        [JsonProperty("listPrice")]
        public string ListPrice { get; set; }
        [JsonProperty("monthlyRent")]
        public string MonthlyRent { get; set; }
    }
    public class Address {
        [JsonProperty("address1")]
        public string Address1 { get; set; }
        [JsonProperty("address2")]
        public string Address2 { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("county")]
        public string County { get; set; }
        [JsonProperty("district")]
        public string District { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("zip")]
        public string ZipCode { get; set; }
        [JsonProperty("zipPlus4")]
        public string ZipPlusFour { get; set; }

    }
    public class Resources { 
        [JsonProperty("photos")]
        public Photos[] Photos { get; set; }
    }
    public class Photos {
        [JsonProperty("urlMedium")]
        public string UrlImage { get; set; }
    }
}
