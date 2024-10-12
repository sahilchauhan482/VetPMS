using System.Net.Http.Json;
using VetPMS.Constants;
using VetPMS.Models;

namespace VetPMS.Services
{
    public class BreedService(IHttpClientFactory httpClient)
    {
        private readonly HttpClient _httpClient = httpClient.CreateClient(_HttpClient.Client);

        public async Task<List<BreedDTO>> GetAllBreeds()
        {
            var response = await _httpClient.GetFromJsonAsync<BreedResponse>(ApiRoutes.Breeds.GetAll);
            return response?.breedDTO ?? new List<BreedDTO>();
        }

        public async Task AddBreed(BreedDTO newBreed)
        {
            try
            {

                var apiUrl = "api/Breed/CreateBreed";
                var response = await _httpClient.PostAsJsonAsync(apiUrl, newBreed);

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
    }
}
