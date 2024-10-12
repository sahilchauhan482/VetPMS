using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace VetPMS.Services
{
    public class BaseHttpService(HttpClient httpClient, ILocalStorageService localStorage)
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly ILocalStorageService _localStorage = localStorage;

        protected async Task GetBearerToken()
        {
            var token = await _localStorage.GetItemAsync<string>("accessToken");
            if (token != null)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            }
        }
    }
}
