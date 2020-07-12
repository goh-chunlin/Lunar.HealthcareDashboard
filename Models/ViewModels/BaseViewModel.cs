using System;

namespace healthcare_dashboard.Models.ViewModels
{
    public abstract class BaseViewModel
    {
        public bool IsSuccessful { get; set; } = true;
        
        public string Message { get; set; }
    }
}
