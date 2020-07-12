using System;
using System.Text.Json.Serialization;

namespace healthcare_dashboard.Models
{
    public class Name
    {
        [JsonPropertyName("use")]
        public string Use { get; set; }

        [JsonPropertyName("family")]
        public string FamilyName { get; set; }

        [JsonPropertyName("given")]
        public string[] GivenNames { get; set; }
    }
}
