using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace healthcare_dashboard.Models.PatientSearch
{
    public class PatientSearchResult
    {
        [JsonPropertyName("link")]
        public List<SearchLink> Link { get; set; }

        [JsonPropertyName("entry")]
        public List<SearchEntry<PatientSearchEntryResource>> Entries { get; set; }
    }
}
