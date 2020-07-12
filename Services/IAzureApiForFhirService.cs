using System.Threading.Tasks;
using healthcare_dashboard.Models.ViewModels;

namespace healthcare_dashboard.Services
{
    public interface IAzureApiForFhirService
    {
        Task<PatientsViewModel> GetAllPatientsAsync();

        Task<PatientViewModel> GetPatientInfoAsync(string patientId);

        Task<ConditionsViewModel> GetPatientConditionsAsync(string patientId);

        Task<EncountersViewModel> GetPatientEncountersAsync(string patientId);

        Task<ObservationsViewModel> GetPatientObservationsAsync(string patientId);
    }
}
