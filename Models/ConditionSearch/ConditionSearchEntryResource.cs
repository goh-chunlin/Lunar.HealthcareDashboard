using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace healthcare_dashboard.Models.ConditionSearch
{
    public class ConditionSearchEntryResource : BaseSearchEntryResource
    {
        [JsonPropertyName("clinicalStatus")]
        public ClinicalStatus ClinicalStatus { get; set; }

        [JsonPropertyName("code")]
        public Code Code { get; set; }

        [JsonPropertyName("recordedDate")]
        public DateTimeOffset RecordedDateTime { get; set; }
    }
}
