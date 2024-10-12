using System.Net.Http.Json;
using VetPMS.Constants;
using VetPMS.Models;

namespace VetPMS.Services
{
    public class PatientService(IHttpClientFactory httpClient)
    {
        private readonly HttpClient _httpClient = httpClient.CreateClient(_HttpClient.Client);

        public async Task<List<PatientsDTO>> GetAllPatient()
        {
            var apiUrl = ApiRoutes.Patients.GetAll;
            var response = await _httpClient.GetFromJsonAsync<PatientResponse>(apiUrl);

            var patients = response?.PatientDTO ?? new List<PatientsDTO>();          

            var updatedPatientsList = patients.Select(patient => new PatientsDTO
            {
                Id = patient.Id,
                Name = patient.Name,
                BreedId = patient.BreedId,
                DOB = patient.DOB,
                Colour = patient.Colour,
                OwnerId = patient.OwnerId,
                OwnerName = patient.Owner!.Name,  
                BreedName = patient.Breed!.Name  
            }).ToList();

            return updatedPatientsList;
        }



        public async Task AddPatient(PatientsDTO newPatient)
        {
            try
            {
                var apiUrl = ApiRoutes.Patients.Create;
                var response = await _httpClient.PostAsJsonAsync(apiUrl, newPatient);

                if (!response.IsSuccessStatusCode)
                {
                    var statusCode = response.StatusCode;
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var dynamicMessage = $"Error {statusCode}: {responseContent}";
                    throw new ApplicationException(dynamicMessage);
                }
            }
            catch (HttpRequestException httpEx)
            {

                var errorMessage = $"A network error occurred: {httpEx.Message}. Please check your connection and try again.";
                throw new ApplicationException(errorMessage, httpEx);
            }
            catch (Exception ex)
            {

                var errorMessage = $"An unexpected error occurred: {ex.Message}. Please try again later.";
                throw new ApplicationException(errorMessage, ex);
            }
        }

        public async Task<PatientsDTO> GetPatientById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{ApiRoutes.Patients.GetById}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var getpatientResponse = await response.Content.ReadFromJsonAsync<GetPatientResponse>();
                    return getpatientResponse?.PatientDTO ?? throw new Exception("Patient not found");
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Failed to retrieve patient: {response.ReasonPhrase}, Content: {content}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching patient details: {ex.Message}");
            }
        }

        public async Task UpdatePatient(PatientsDTO patient)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{ApiRoutes.Patients.Update}/{patient.Id}", patient);
                if (!response.IsSuccessStatusCode)
                {
                    var statusCode = response.StatusCode;
                    var responseContent = await response.Content.ReadAsStringAsync();


                    var dynamicMessage = $"Error {statusCode}: {responseContent}";

                    throw new ApplicationException(dynamicMessage);
                }
            }
            catch (HttpRequestException httpEx)
            {

                var errorMessage = $"A network error occurred: {httpEx.Message}. Please check your connection and try again.";
                throw new ApplicationException(errorMessage, httpEx);
            }
            catch (Exception ex)
            {

                var errorMessage = $"An unexpected error occurred: {ex.Message}. Please try again later.";
                throw new ApplicationException(errorMessage, ex);
            }

        }

        public async Task DeletePatient(int patientId)
        {
            try
            {

                var response = await _httpClient.DeleteAsync($"{ApiRoutes.Patients.Delete}/{patientId}");

                if (!response.IsSuccessStatusCode)
                {
                    var statusCode = response.StatusCode;
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var errorMessage = $"Error {statusCode}: {responseContent}";
                    throw new ApplicationException(errorMessage);
                }
            }
            catch (HttpRequestException httpEx)
            {
                var errorMessage = $"A network error occurred: {httpEx.Message}. Please check your connection and try again.";
                throw new ApplicationException(errorMessage, httpEx);
            }
            catch (Exception ex)
            {
                var errorMessage = $"An unexpected error occurred: {ex.Message}. Please try again later.";
                throw new ApplicationException(errorMessage, ex);
            }
        }
    }
}
