using System;
using System.Text.Json.Serialization;

namespace healthcare_dashboard.Models
{
    public class Code
    {
        [JsonPropertyName("text")]
        public string Value { get; set; }
    }
}
