using System;
using System.Text.Json.Serialization;

namespace healthcare_dashboard.Models.EncounterSearch
{
    public class Period
    {
        [JsonPropertyName("start")]
        public DateTimeOffset StartingDateTime { get; set; }

        [JsonPropertyName("end")]
        public DateTimeOffset EndingDateTime { get; set; }
    }
}
