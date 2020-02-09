using System;
using System.Text.Json.Serialization;

namespace BeAware.Models
{
    public class ValidationRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("platform_name")]
        public string PlatformName { get; set; }
        [JsonPropertyName("platform_category")]
        public string PlatformCategory { get; set; }
        [JsonPropertyName("platform_details")]
        public string PlatformDetails { get; set; }
        [JsonPropertyName("completed")]
        public bool Completed { get; set; }
    }
}