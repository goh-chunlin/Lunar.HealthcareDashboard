using System;
using System.Text.Json.Serialization;

namespace healthcare_dashboard.Models.EncounterSearch
{
    public class ServiceProvider
    {
        [JsonPropertyName("display")]
        public string Display { get; set; }
    }
}
