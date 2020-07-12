using System;
using System.Collections.Generic;

namespace healthcare_dashboard.Models.ViewModels
{
    public class PatientsViewModel : BaseViewModel
    {
        public List<PatientViewModel> Patients { get; set; } = new List<PatientViewModel>();
    }
}
