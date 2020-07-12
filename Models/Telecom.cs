using System;
using System.Text.Json.Serialization;

namespace healthcare_dashboard.Models
{
    public class Telecom
    {
        [JsonPropertyName("use")]
        public string Use { get; set; }

        [JsonPropertyName("system")]
        public string System { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
