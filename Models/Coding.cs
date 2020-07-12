using System;
using System.Text.Json.Serialization;

namespace healthcare_dashboard.Models
{
    public class Coding
    {
        [JsonPropertyName("system")]
        public string System { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }
    }
}
