using System.Net.Http.Json;
using System.Text.Json;
using VetPMS.Constants;
using VetPMS.Models;

namespace VetPMS.Services
{
    public class ClinicService(IHttpClientFactory clientFactory)
    {
        private readonly HttpClient _httpClient = clientFactory.CreateClient(_HttpClient.Client);

        public async Task<List<ClinicDto>> GetAllClinics()
        {
            var response = await _httpClient.GetFromJsonAsync<ClinicResponse>(ApiRoutes.Clinic.GetAll); 
            return response?.ClinicDto ?? new List<ClinicDto>();
        }

        public async Task<ClinicDto> GetClinicById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{ApiRoutes.Clinic.GetById}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var getClinicResponse = await response.Content.ReadFromJsonAsync<GetClinicResponse>();
                    return getClinicResponse?.ClinicDto ?? throw new KeyNotFoundException("Clinic not found");
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"Failed to retrieve clinic: {response.ReasonPhrase}, Content: {content}");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error fetching clinic details: {ex.Message}");
            }
        }

        public async Task AddClinic(ClinicDto newClinic)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(ApiRoutes.Clinic.Create, newClinic);

                if (!response.IsSuccessStatusCode)
                {
                    var statusCode = response.StatusCode;
                    var responseContent = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"Error {statusCode}: {responseContent}");
                }
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException($"A network error occurred: {httpEx.Message}. Please check your connection and try again.", httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"An unexpected error occurred: {ex.Message}. Please try again later.", ex);
            }
        }

        public async Task UpdateClinic(ClinicDto clinic)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{ApiRoutes.Clinic.Update}/{clinic.ClinicId}", clinic);

                if (!response.IsSuccessStatusCode)
                {
                    var statusCode = response.StatusCode;
                    var responseContent = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"Error {statusCode}: {responseContent}");
                }
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException($"A network error occurred: {httpEx.Message}. Please check your connection and try again.", httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"An unexpected error occurred: {ex.Message}. Please try again later.", ex);
            }
        }

        public async Task DeleteClinic(int clinicId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiRoutes.Clinic.Delete}/{clinicId}"); 

                if (!response.IsSuccessStatusCode)
                {
                    var statusCode = response.StatusCode;
                    var responseContent = await response.Content.ReadAsStringAsync();
                    throw new ArgumentException($"Error {statusCode}: {responseContent}");
                }
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException($"A network error occurred: {httpEx.Message}. Please check your connection and try again.", httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"An unexpected error occurred: {ex.Message}. Please try again later.", ex);
            }
        }



        public async Task<bool> CheckEmailExistsAsync(string email)
        {
            var response = await _httpClient.GetAsync($"api/clinics/check-email?email={email}");
            return await response.Content.ReadFromJsonAsync<bool>();
        }

       
        public async Task<bool> CheckPhoneNumberExistsAsync(string phoneNumber)
        {
            var response = await _httpClient.GetAsync($"api/clinics/check-phone?phoneNumber={phoneNumber}");
            return await response.Content.ReadFromJsonAsync<bool>();
        }
    }
}
