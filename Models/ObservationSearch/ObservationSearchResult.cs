using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace healthcare_dashboard.Models.ObservationSearch
{
    public class ObservationSearchResult
    {
        [JsonPropertyName("link")]
        public List<SearchLink> Link { get; set; }

        [JsonPropertyName("entry")]
        public List<SearchEntry<ObservationSearchEntryResource>> Entries { get; set; }
    }
}
