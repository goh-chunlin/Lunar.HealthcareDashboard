using System;
using System.Collections.Generic;

namespace healthcare_dashboard.Models.ViewModels
{
    public class ObservationsViewModel : BaseViewModel
    {
        public List<ObservationViewModel> Observations { get; set; } = new List<ObservationViewModel>();
    }
}
