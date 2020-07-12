using System;
using System.Collections.Generic;

namespace healthcare_dashboard.Models.ViewModels
{
    public class ConditionsViewModel : BaseViewModel
    {
        public List<ConditionViewModel> Conditions { get; set; } = new List<ConditionViewModel>();
    }
}
