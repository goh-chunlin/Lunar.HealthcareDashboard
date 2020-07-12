using System;
using System.Text.Json.Serialization;

namespace healthcare_dashboard.Models
{
    public class SearchLink
    {
        [JsonPropertyName("relation")]
        public string Relation { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
