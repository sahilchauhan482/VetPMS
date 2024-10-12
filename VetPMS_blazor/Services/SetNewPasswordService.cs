using System.Net.Http.Json;
using VetPMS.Constants;
using VetPMS.Models;

namespace VetPMS.Services
{
    public class SetNewPasswordService(IHttpClientFactory httpClient)
    {
        private readonly HttpClient _httpClient = httpClient.CreateClient(_HttpClient.Client);

        public async Task<bool> NewPassword(SetNewPasswordModel model)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(ApiRoutes.Authentication.NewPassword, model);

                if (response.IsSuccessStatusCode)
                {
                    return true; 
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Failed to set new password: {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while setting new password", ex);
            }
        }
    }
}
