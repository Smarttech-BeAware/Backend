using System;
using System.Text.Json.Serialization;

namespace BeAware.Models
{
    public class Location
    {
        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }
        [JsonPropertyName("timestamp")]
        public string Time { get; set; }
    }
}