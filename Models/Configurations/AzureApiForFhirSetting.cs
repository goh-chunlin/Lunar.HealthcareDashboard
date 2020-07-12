using System;

namespace healthcare_dashboard.Models.Configurations
{
    public class AzureApiForFhirSetting
    {
        public string Authority { get; set; }

        public string Audience { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
    }
}
