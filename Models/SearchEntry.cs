using System;
using System.Text.Json.Serialization;

namespace healthcare_dashboard.Models
{
    public class SearchEntry<T> where T : BaseSearchEntryResource
    {
        [JsonPropertyName("fullUrl")]
        public string FullUrl { get; set; }

        [JsonPropertyName("resource")]
        public T Resource { get; set; }
    }
}
