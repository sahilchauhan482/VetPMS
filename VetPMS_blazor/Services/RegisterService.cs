using System.Net.Http.Json;
using System.Text.Json;
using VetPMS.Constants;
using VetPMS.Models;

namespace VetPMS.Services
{
    public class RegisterService(IHttpClientFactory httpClient)
    {
        private readonly HttpClient _httpClient = httpClient.CreateClient(_HttpClient.Client);

        public async Task CreateUser(RegisterDTO register)
        {
            var response = await _httpClient.PostAsJsonAsync(ApiRoutes.Registers.Create, register);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }
            
        }

        public async Task<bool> CheckEmailExistsAsync(string email)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{ApiRoutes.Registers.EmailExist}={email}");

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
                var response = await _httpClient.GetAsync($"{ApiRoutes.Registers.PhoneExist}={phoneNumber}");

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

    }
}
