using System;

namespace healthcare_dashboard.Models.ViewModels
{
    public class EncounterViewModel : BaseViewModel
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public DateTimeOffset StartingDateTime { get; set; }

        public DateTimeOffset EndingDateTime { get; set; }

        public string ServiceProvider { get; set; }
    }
}
