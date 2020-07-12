using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace healthcare_dashboard.Models.ObservationSearch
{
    public class ObservationSearchEntryResource : BaseSearchEntryResource
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("code")]
        public Code Code { get; set; }

        [JsonPropertyName("valueQuantity")]
        public ValueQuantity Measurement { get; set; }

        [JsonPropertyName("valueCodeableConcept")]
        public Code CodeableMeasurement { get; set; }

        [JsonPropertyName("component")]
        public List<ObservationComponent> Components { get; set; }

        [JsonPropertyName("effectiveDateTime")]
        public DateTimeOffset EffectiveDateTime { get; set; }
    }
}
