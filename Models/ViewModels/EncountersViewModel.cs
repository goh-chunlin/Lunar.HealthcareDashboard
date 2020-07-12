using System;
using System.Collections.Generic;

namespace healthcare_dashboard.Models.ViewModels
{
    public class EncountersViewModel : BaseViewModel
    {
        public List<EncounterViewModel> Encounters { get; set; } = new List<EncounterViewModel>();
    }
}
