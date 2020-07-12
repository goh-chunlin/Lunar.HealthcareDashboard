using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using healthcare_dashboard.Services;
using healthcare_dashboard.Models.Configurations;
using Microsoft.Extensions.Options;
using healthcare_dashboard.Models.ViewModels;

namespace healthcare_dashboard.Controllers
{
    public class PatientController : Controller
    {
        private readonly IAzureApiForFhirService _azureApiForFhirService;  
        private readonly GoogleApiSetting _googleApiSetting;  

        public PatientController(IAzureApiForFhirService azureApiForFhirService,
            IOptions<GoogleApiSetting> googleApiSettingAccessor)
        {
            _azureApiForFhirService = azureApiForFhirService;
            _googleApiSetting = googleApiSettingAccessor.Value;
        }

        public async Task<IActionResult> Index(string id)
        {
            string patientId = id;

            ViewData["GoogleMapsApiKey"] = _googleApiSetting.MapsJavaScriptApiKey;

            var patient = await _azureApiForFhirService.GetPatientInfoAsync(patientId);
            var conditions = await _azureApiForFhirService.GetPatientConditionsAsync(patientId);
            var encounters = await _azureApiForFhirService.GetPatientEncountersAsync(patientId);
            var observations = await _azureApiForFhirService.GetPatientObservationsAsync(patientId);

            var patientInfoViewModel = new PatientInfoViewModel
            {
                IsSuccessful = patient.IsSuccessful && conditions.IsSuccessful && encounters.IsSuccessful && observations.IsSuccessful,
                Message = (patient.Message + " " + conditions.Message + " " + encounters.Message + " " + observations.Message).Trim(),
                Patient = patient,
                Conditions = conditions.Conditions,
                Encounters = encounters.Encounters,
                Observations = observations.Observations
            };

            return View(patientInfoViewModel);
        }
    }
}