using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace healthcare_dashboard.Models
{
    public class AddressExtension
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("extension")]
        public List<DecimalValueExtension> DecimalValueExtensions { get; set; }
    }
}
