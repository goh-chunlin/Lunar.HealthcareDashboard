using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace healthcare_dashboard.Models.ConditionSearch
{
    public class ClinicalStatus
    {
        [JsonPropertyName("coding")]
        public List<Coding> Coding { get; set; }
    }
}
