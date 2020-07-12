using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace healthcare_dashboard.Models.EncounterSearch
{
    public class EncounterSearchResult
    {
        [JsonPropertyName("link")]
        public List<SearchLink> Link { get; set; }

        [JsonPropertyName("entry")]
        public List<SearchEntry<EncounterSearchEntryResource>> Entries { get; set; }
    }
}
