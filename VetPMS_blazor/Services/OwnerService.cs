using System.Net.Http.Json;
using System.Text.Json;
using VetPMS.Constants;
using VetPMS.Models;

namespace VetPMS.Services
{
    public class OwnerService(IHttpClientFactory clientFactory)
    {
        private readonly HttpClient _httpClient = clientFactory.CreateClient(_HttpClient.Client);

        public async Task<List<OwnerDTO>> GetAllOwners()
        {
            var response = await _httpClient.GetFromJsonAsync<OwnerResponse>(ApiRoutes.Owners.GetAll);
            return response?.OwnerDTO ?? new List<OwnerDTO>();
        }


        public async Task AddOwner(OwnerDTO newOwner)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(ApiRoutes.Owners.Create, newOwner);

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


        public async Task<bool> CheckEmailExistsAsync(string email)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{ApiRoutes.Owners.EmailExist}={email}");

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonSerializer.Deserialize<CheckEmailExistResponse>(responseString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return responseObject?.CheckEmailExist ?? false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> CheckPhoneNumberExistsAsync(string phoneNumber)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{ApiRoutes.Owners.PhoneExist}={phoneNumber}");

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonSerializer.Deserialize<CheckPhoneNumberExistResponse>(responseString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return responseObject?.CheckPhoneExist ?? false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task UpdateOwner(OwnerDTO owner)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{ApiRoutes.Owners.Update}/{owner.Id}", owner);

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

        public async Task DeleteOwner(int ownerId)
        {
            try
            {
                
                var response = await _httpClient.DeleteAsync($"{ApiRoutes.Owners.Delete}/{ownerId}");

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


        public async Task<OwnerDTO> GetOwnerById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{ApiRoutes.Owners.GetById}/{id}");

                if (response.IsSuccessStatusCode)
                {                    
                    var getOwnerResponse = await response.Content.ReadFromJsonAsync<GetOwnerResponse>();
                    return getOwnerResponse?.OwnerDTO ?? throw new Exception("Owner not found");
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

    }
}
