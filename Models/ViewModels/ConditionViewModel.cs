using System;
using System.Collections.Generic;

namespace healthcare_dashboard.Models.ViewModels
{
    public class ConditionViewModel : BaseViewModel
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public DateTimeOffset RecordedDateTime { get; set; }
    }
}
