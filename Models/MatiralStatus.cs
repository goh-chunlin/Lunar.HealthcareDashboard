using System;
using System.Text.Json.Serialization;

namespace healthcare_dashboard.Models
{
    public class MaritalStatus
    {
        [JsonPropertyName("text")]
        public string Value { get; set; }
    }
}
