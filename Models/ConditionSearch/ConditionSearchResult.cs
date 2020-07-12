using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace healthcare_dashboard.Models.ConditionSearch
{
    public class ConditionSearchResult
    {
        [JsonPropertyName("link")]
        public List<SearchLink> Link { get; set; }

        [JsonPropertyName("entry")]
        public List<SearchEntry<ConditionSearchEntryResource>> Entries { get; set; }
    }
}
