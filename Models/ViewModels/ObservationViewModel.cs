using System;

namespace healthcare_dashboard.Models.ViewModels
{
    public class ObservationViewModel : BaseViewModel
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public string Measurement { get; set; }

        public string Status { get; set; }

        public DateTimeOffset EffectiveDateTime { get; set; }
    }
}
