using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace healthcare_dashboard.Models
{
    public class Address
    {
        [JsonPropertyName("extension")]
        public List<AddressExtension> Extensions { get; set; }

        [JsonPropertyName("line")]
        public string[] Lines { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }
    }
}
