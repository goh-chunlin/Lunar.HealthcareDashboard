using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace healthcare_dashboard.Models.ObservationSearch
{
    public class ObservationComponent
    {
        [JsonPropertyName("code")]
        public Code Code { get; set; }

        [JsonPropertyName("valueQuantity")]
        public ValueQuantity Measurement { get; set; }
    }
}
