using System;
using System.Collections.Generic;

namespace healthcare_dashboard.Models.ViewModels
{
    public class PatientInfoViewModel : BaseViewModel
    {
        public PatientViewModel Patient { get; set; }

        public List<ConditionViewModel> Conditions { get; set; }

        public List<EncounterViewModel> Encounters { get; set; }

        public List<ObservationViewModel> Observations { get; set; }
    }
}
