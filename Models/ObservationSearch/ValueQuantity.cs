using System;
using System.Text.Json.Serialization;

namespace healthcare_dashboard.Models.ObservationSearch
{
    public class ValueQuantity
    {
        [JsonPropertyName("value")]
        public double Value { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }
    }
}
