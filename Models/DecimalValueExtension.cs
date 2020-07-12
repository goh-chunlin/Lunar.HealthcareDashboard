using System;
using System.Text.Json.Serialization;

namespace healthcare_dashboard.Models
{
    public class DecimalValueExtension
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("valueDecimal")]
        public decimal Value { get; set; }
    }
}
