using Blazored.LocalStorage;
using System.Net.Http.Json;
using VetPMS.Constants;
using VetPMS.Models;

namespace VetPMS.Services.Authentication
{
    public class AuthenticationService(IHttpClientFactory httpClient, ILocalStorageService localStorage, ApiAuthenticationStateProvider authenticationStateProvider) : IAuthenticationService
    {
        private readonly HttpClient _httpClient = httpClient.CreateClient(_HttpClient.Client);
        private readonly ILocalStorageService _localStorageService = localStorage;
        private readonly ApiAuthenticationStateProvider _authenticationStateProvider = authenticationStateProvider;

        public async Task<AuthResponse>AuthenticateAsync(AuthLogin authLogin)
        {
           
            var response = await _httpClient.PostAsJsonAsync(ApiRoutes.Authentication.Login, authLogin);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadFromJsonAsync<AuthResponse>();

                if (responseData != null && !string.IsNullOrEmpty(responseData.LoginDTO.Token) && !string.IsNullOrEmpty(responseData.LoginDTO.UserId))
                {
                    await _authenticationStateProvider.LoggedIn(responseData.LoginDTO.Token, responseData.LoginDTO.UserId);
                    return responseData;
                }
            }
            return null!;
        }


        public async Task Logout()
        {
            await _authenticationStateProvider.LoggedOut();
        }

    }
}
