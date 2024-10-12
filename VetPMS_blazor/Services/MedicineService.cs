using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using VetPMS.Constants;
using VetPMS.Models;

namespace VetPMS.Services
{
    public class MedicineService(IHttpClientFactory clientFactory)
    {
        private readonly HttpClient _httpClient = clientFactory.CreateClient(_HttpClient.Client);


        public async Task<List<MedicineDTO>> GetAllMedicines()
        {
            var response = await _httpClient.GetFromJsonAsync<MedicineResponse>(ApiRoutes.Medicines.GetAll);
            return response?.MedicineDTO ?? new List<MedicineDTO>();
        }

       
        public async Task AddMedicine(MedicineDTO newMedicine)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(ApiRoutes.Medicines.Create, newMedicine);

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

        public async Task UpdateMedicine(MedicineDTO medicine)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{ApiRoutes.Medicines.Update}/{medicine.MedicineId}", medicine);
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

        public async Task DeleteMedicine(int medicineId)
        {
            try
            {

                var response = await _httpClient.DeleteAsync($"{ApiRoutes.Medicines.Delete}/{medicineId}");

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


        public async Task<MedicineDTO> GetMedicineById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{ApiRoutes.Medicines.GetById}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var getMedicineResponse = await response.Content.ReadFromJsonAsync<GetMedicineResponse>();
                    return getMedicineResponse?.MedicineDTO ?? throw new Exception("Medicine not found");
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Failed to retrieve owner: {response.ReasonPhrase}, Content: {content}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching owner details: {ex.Message}");
            }
        }


        public async Task<List<MedicineDTO>> ImportMedicine(IBrowserFile file)
        {
            try
            {
               
                if (file == null || file.Size == 0)
                {
                    throw new ArgumentException("File is empty or null");
                }

                var content = new MultipartFormDataContent();
                var fileContent = new StreamContent(file.OpenReadStream(maxAllowedSize: 10485760)); 
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                content.Add(fileContent, "file", file.Name);
                
                var response = await _httpClient.PostAsync(ApiRoutes.Medicines.ImportExcel, content);

                
                if (!response.IsSuccessStatusCode)
                {
                    var statusCode = response.StatusCode;
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var dynamicMessage = $"Error {statusCode}: {responseContent}";
                    throw new ApplicationException(dynamicMessage);
                }
                var result = await response.Content.ReadFromJsonAsync<List<MedicineDTO>>();
                return result ?? new List<MedicineDTO>();
            }
           
            catch (Exception ex)
            {
                var errorMessage = $"An unexpected error occurred: {ex.Message}. Please try again later.";
                throw new ApplicationException(errorMessage, ex);
            }
        }


    }
}
