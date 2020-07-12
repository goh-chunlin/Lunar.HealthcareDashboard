using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace healthcare_dashboard.Models
{
    public abstract class BaseSearchEntryResource
    {
        [JsonPropertyName("resourceType")]
        public string ResourceType { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
