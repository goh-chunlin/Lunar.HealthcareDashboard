using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace healthcare_dashboard.Models.PatientSearch
{
    public class PatientSearchEntryResource : BaseSearchEntryResource
    {
        [JsonPropertyName("name")]
        public List<Name> Name { get; set; }

        [JsonPropertyName("telecom")]
        public List<Telecom> Telecom { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("birthDate")]
        public DateTime BirthDate { get; set; }

        [JsonPropertyName("address")]
        public List<Address> Address { get; set; }

        [JsonPropertyName("maritalStatus")]
        public MaritalStatus MaritalStatus { get; set; }
    }
}
