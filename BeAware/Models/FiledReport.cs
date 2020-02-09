using System;
using System.Text.Json.Serialization;

namespace BeAware.Models
{
    public class FiledReport
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("crime")]
        public string Crime { get; set; }
        [JsonPropertyName("occurred")]
        public bool Occured { get; set; }
        [JsonPropertyName("crime_details")]
        public string CrimeDetails { get; set; }
        [JsonPropertyName("location")]
        public string Location { get; set; }
    }
}