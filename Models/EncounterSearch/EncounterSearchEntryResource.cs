using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace healthcare_dashboard.Models.EncounterSearch
{
    public class EncounterSearchEntryResource : BaseSearchEntryResource
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("type")]
        public List<Code> Codes { get; set; }

        [JsonPropertyName("period")]
        public Period Period { get; set; }

        [JsonPropertyName("serviceProvider")]
        public ServiceProvider ServiceProvider { get; set; }
    }
}
