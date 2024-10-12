using System.Net.Http.Json;
using VetPMS.Constants;
using VetPMS.Models;

namespace VetPMS.Services
{
    public class ResetPasswordService(IHttpClientFactory httpClient)
    {

        private readonly HttpClient _httpClient = httpClient.CreateClient(_HttpClient.Client);

        public async Task<bool> GenerateResetPasswordTokenAsync(ResetPasswordDTO forgetPassword)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(ApiRoutes.Authentication.Reset, forgetPassword);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
