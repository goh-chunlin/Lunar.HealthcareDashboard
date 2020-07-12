using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using healthcare_dashboard.Models.ViewModels;
using healthcare_dashboard.Models.ConditionSearch;
using healthcare_dashboard.Models.Configurations;
using healthcare_dashboard.Models.PatientSearch;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using healthcare_dashboard.Models.EncounterSearch;
using healthcare_dashboard.Models.ObservationSearch;

namespace healthcare_dashboard.Services
{
    public class AzureApiForFhirService : IAzureApiForFhirService
    {
        private readonly AzureApiForFhirSetting _azureApiForFhirSetting;  
        
        public AzureApiForFhirService(IOptions<AzureApiForFhirSetting> azureApiForFhirSettingAccessor)
        {
            _azureApiForFhirSetting = azureApiForFhirSettingAccessor.Value;
        }

        public async Task<PatientsViewModel> GetAllPatientsAsync()
        {
            try
            {
                var authResult = GetAuthenticationResult();

                using (var client = new HttpClient()) {
                    string resourceUrl = "https://lunar-healthcare.azurehealthcareapis.com/Patient";

                    var patientViewModels = new List<PatientViewModel>();
                    
                    do
                    {
                        var request = new HttpRequestMessage(HttpMethod.Get, resourceUrl);
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
                        HttpResponseMessage response = await client.SendAsync(request);

                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var patients = JsonSerializer.Deserialize<PatientSearchResult>(jsonResponse);

                        foreach(var patientEntry in patients.Entries)
                        {
                            patientViewModels.Add(TranslateFromPatientEntryResourceToViewModel(patientEntry.Resource));
                        }

                        resourceUrl = patients.Link.FirstOrDefault(l => l.Relation == "next")?.Url;
                    } while (resourceUrl != null);

                    return new PatientsViewModel
                    { 
                        Patients = patientViewModels
                    };
                }
                

            }
            catch (Exception ex)
            {
                return new PatientsViewModel{ IsSuccessful = false, Message = ex.Message };
            }
        }

        public async Task<PatientViewModel> GetPatientInfoAsync(string patientId)
        {
            try
            {
                var authResult = GetAuthenticationResult();

                using (var client = new HttpClient()) {
                    string resourceUrl = $"https://lunar-healthcare.azurehealthcareapis.com/Patient/{patientId}";

                    var request = new HttpRequestMessage(HttpMethod.Get, resourceUrl);
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
                    HttpResponseMessage response = await client.SendAsync(request);

                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var patient = JsonSerializer.Deserialize<PatientSearchEntryResource>(jsonResponse);
                    
                    return TranslateFromPatientEntryResourceToViewModel(patient);
                }
                

            }
            catch (Exception ex)
            {
                return new PatientViewModel{ IsSuccessful = false, Message = ex.Message };
            }
        }

        public async Task<ConditionsViewModel> GetPatientConditionsAsync(string patientId)
        {
            try
            {
                var authResult = GetAuthenticationResult();

                using (var client = new HttpClient()) {
                    string resourceUrl = $"https://lunar-healthcare.azurehealthcareapis.com/Condition?patient={patientId}";

                    var conditionViewModels = new List<ConditionViewModel>();
                    
                    do
                    {
                        var request = new HttpRequestMessage(HttpMethod.Get, resourceUrl);
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
                        HttpResponseMessage response = await client.SendAsync(request);

                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var conditions = JsonSerializer.Deserialize<ConditionSearchResult>(jsonResponse);

                        foreach(var conditionEntry in conditions.Entries)
                        {
                            conditionViewModels.Add(TranslateFromConditionEntryResourceToViewModel(conditionEntry.Resource));
                        }

                        resourceUrl = conditions.Link.FirstOrDefault(l => l.Relation == "next")?.Url;
                    } while (resourceUrl != null);

                    return new ConditionsViewModel
                    { 
                        Conditions = conditionViewModels
                    };
                }
                

            }
            catch (Exception ex)
            {
                return new ConditionsViewModel{ IsSuccessful = false, Message = ex.Message };
            }
        }

        public async Task<EncountersViewModel> GetPatientEncountersAsync(string patientId)
        {
            try
            {
                var authResult = GetAuthenticationResult();

                using (var client = new HttpClient()) {
                    string resourceUrl = $"https://lunar-healthcare.azurehealthcareapis.com/Encounter?patient={patientId}";

                    var encounterViewModels = new List<EncounterViewModel>();
                    
                    do
                    {
                        var request = new HttpRequestMessage(HttpMethod.Get, resourceUrl);
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
                        HttpResponseMessage response = await client.SendAsync(request);

                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var encounters = JsonSerializer.Deserialize<EncounterSearchResult>(jsonResponse);

                        foreach(var encounterEntry in encounters.Entries)
                        {
                            encounterViewModels.Add(TranslateFromEncounterEntryResourceToViewModel(encounterEntry.Resource));
                        }

                        resourceUrl = encounters.Link.FirstOrDefault(l => l.Relation == "next")?.Url;
                    } while (resourceUrl != null);

                    return new EncountersViewModel
                    { 
                        Encounters = encounterViewModels
                    };
                }
                

            }
            catch (Exception ex)
            {
                return new EncountersViewModel{ IsSuccessful = false, Message = ex.Message };
            }
        }

        public async Task<ObservationsViewModel> GetPatientObservationsAsync(string patientId)
        {
            try
            {
                var authResult = GetAuthenticationResult();

                using (var client = new HttpClient()) {
                    string resourceUrl = $"https://lunar-healthcare.azurehealthcareapis.com/Observation?patient={patientId}";

                    var observationViewModels = new List<ObservationViewModel>();
                    
                    do
                    {
                        var request = new HttpRequestMessage(HttpMethod.Get, resourceUrl);
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
                        HttpResponseMessage response = await client.SendAsync(request);

                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var observations = JsonSerializer.Deserialize<ObservationSearchResult>(jsonResponse);

                        foreach(var observationEntry in observations.Entries)
                        {
                            observationViewModels.AddRange(TranslateFromObservationEntryResourceToViewModel(observationEntry.Resource));
                        }

                        resourceUrl = observations.Link.FirstOrDefault(l => l.Relation == "next")?.Url;
                    } while (resourceUrl != null);

                    return new ObservationsViewModel
                    { 
                        Observations = observationViewModels
                    };
                }
                

            }
            catch (Exception ex)
            {
                return new ObservationsViewModel{ IsSuccessful = false, Message = ex.Message };
            }
        }


        private AuthenticationResult GetAuthenticationResult()
        {
            string authority = _azureApiForFhirSetting.Authority;
            string audience = _azureApiForFhirSetting.Audience;
            string clientId = _azureApiForFhirSetting.ClientId;
            string clientSecret = _azureApiForFhirSetting.ClientSecret;

            AuthenticationContext authContext;
            ClientCredential clientCredential;
            
            authContext = new AuthenticationContext(authority);
            clientCredential = new ClientCredential(clientId, clientSecret);
            return authContext.AcquireTokenAsync(audience, clientCredential).Result;
        }

        private PatientViewModel TranslateFromPatientEntryResourceToViewModel(PatientSearchEntryResource patient)
        {
            var patientMainAddress = patient.Address.FirstOrDefault();
            var patientMainAddressGeolocation = patientMainAddress?.Extensions.FirstOrDefault(ext => ext.Url == "http://hl7.org/fhir/StructureDefinition/geolocation").DecimalValueExtensions;

            return new PatientViewModel
            {
                Id = patient.Id,
                FirstName = patient.Name.FirstOrDefault()?.GivenNames.First(),
                LastName = patient.Name.FirstOrDefault()?.FamilyName,
                Gender = patient.Gender,
                Contact = patient.Telecom.FirstOrDefault()?.Value,
                Lines = patientMainAddress?.Lines ?? new string[] { "-" },
                City = patientMainAddress?.City,
                State = patientMainAddress?.State,
                PostalCode = patientMainAddress?.PostalCode,
                Country = patientMainAddress?.Country,
                Latitude = (double?)patientMainAddressGeolocation?.FirstOrDefault(ext => ext.Url == "latitude")?.Value,
                Longitude = (double?)patientMainAddressGeolocation?.FirstOrDefault(ext => ext.Url == "longitude")?.Value,
                BirthDate = patient.BirthDate,
                MaritalStatus = patient.MaritalStatus.Value
            };
        }

        private ConditionViewModel TranslateFromConditionEntryResourceToViewModel(ConditionSearchEntryResource condition)
        {
            return new ConditionViewModel
            {
                Id = condition.Id,
                Description = condition.Code.Value,
                Status = condition.ClinicalStatus.Coding.FirstOrDefault()?.Code,
                RecordedDateTime = condition.RecordedDateTime
            };
        }

        private EncounterViewModel TranslateFromEncounterEntryResourceToViewModel(EncounterSearchEntryResource encounter)
        {
            return new EncounterViewModel
            {
                Id = encounter.Id,
                Description = encounter.Codes.FirstOrDefault()?.Value,
                Status = encounter.Status,
                StartingDateTime = encounter.Period.StartingDateTime,
                EndingDateTime = encounter.Period.EndingDateTime,
                ServiceProvider = encounter.ServiceProvider.Display
            };
        }

        private List<ObservationViewModel> TranslateFromObservationEntryResourceToViewModel(ObservationSearchEntryResource observation)
        {
            var output = new List<ObservationViewModel>();

            if (observation.Components != null && observation.Components.Count() > 0)
            {
                foreach(var component in observation.Components)
                {
                    output.Add(new ObservationViewModel
                    {
                        Id = observation.Id,
                        Description = component.Code.Value,
                        Status = observation.Status,
                        Measurement = component.Measurement.Value + " " + component.Measurement.Unit,
                        EffectiveDateTime = observation.EffectiveDateTime
                    });
                }
            } 
            else if (observation.CodeableMeasurement != null) 
            {
                output.Add(new ObservationViewModel
                {
                    Id = observation.Id,
                    Description = observation.Code.Value,
                    Status = observation.Status,
                    Measurement = observation.CodeableMeasurement.Value,
                    EffectiveDateTime = observation.EffectiveDateTime
                });
            }
            else 
            {
                output.Add(new ObservationViewModel
                {
                    Id = observation.Id,
                    Description = observation.Code.Value,
                    Status = observation.Status,
                    Measurement = observation.Measurement.Value + " " + observation.Measurement.Unit,
                    EffectiveDateTime = observation.EffectiveDateTime
                });
            }

            return output;
        }
    }
}