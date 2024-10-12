using Blazored.LocalStorage;
using System.Net.Http.Headers;
using VetPMS.Constants;

namespace VetPMS.AuthConfiguration
{
    public class AuthorizationMessageHandler : DelegatingHandler
    {
        private readonly ILocalStorageService _localStorage;

        public AuthorizationMessageHandler(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _localStorage.GetItemAsync<string>(Token.JwtToken);

            // Add the Authorization header if a token is present
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue(Token.Header, token);
            }

            var clinicId = await _localStorage.GetItemAsync<string>("clinicId");
            if (!string.IsNullOrEmpty(clinicId))
            {
                request.Headers.Add("ClinicId", clinicId); 
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
