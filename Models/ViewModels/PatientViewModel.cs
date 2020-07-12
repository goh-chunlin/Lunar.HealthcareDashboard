using System;
using System.Collections.Generic;

namespace healthcare_dashboard.Models.ViewModels
{
    public class PatientViewModel : BaseViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Contact { get; set; }

        public string[] Lines { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public DateTime BirthDate { get; set; }

        public string MaritalStatus { get; set; }
    }
}
