using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using VetPMS.Constants;

public class ApiAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
    private readonly ILocalStorageService _localStorage;
   

    public ApiAuthenticationStateProvider(JwtSecurityTokenHandler jwtSecurityTokenHandler, ILocalStorageService localStorage)
    {
        _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
        _localStorage = localStorage;
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var user = new ClaimsPrincipal(new ClaimsIdentity());
        var savedToken = await _localStorage.GetItemAsync<string>(Token.JwtToken);
        if (string.IsNullOrEmpty(savedToken))
            return new AuthenticationState(user);

        var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(savedToken);
        if (tokenContent.ValidTo < DateTime.UtcNow)
            return new AuthenticationState(user);
        var claims = tokenContent.Claims.ToList();
        user = new ClaimsPrincipal(new ClaimsIdentity(claims,Token.JWT));
        return new AuthenticationState(user);
    }

    public async Task LoggedIn(string token, string userId)
    {
        var claims = _jwtSecurityTokenHandler.ReadJwtToken(token).Claims.ToList();
        var clinicIdClaim = claims.Find(c => c.Type == "clinicId");
        var clinicNameClaim = claims.Find(c => c.Type == "clinicName");

        string? clinicId = clinicIdClaim?.Value;
        string? clinicName = clinicNameClaim?.Value;
        var user = new ClaimsPrincipal(new ClaimsIdentity(claims,Token.JWT));
        var authState = Task.FromResult(new AuthenticationState(user));
        NotifyAuthenticationStateChanged(authState);

        await _localStorage.SetItemAsync(Token.JwtToken, token);
        await _localStorage.SetItemAsync("userId", userId);
        if (!string.IsNullOrEmpty(clinicId))
        {
            await _localStorage.SetItemAsync("clinicId", clinicId);
        }
        if (!string.IsNullOrEmpty(clinicName))
        {
            await _localStorage.SetItemAsync("clinicName", clinicName);
        }

    }

    public async Task LoggedOut()
    {
        await _localStorage.RemoveItemAsync(Token.JwtToken);
        await _localStorage.RemoveItemAsync("clinicId");
        await _localStorage.RemoveItemAsync("clinicName");
        var nobody = new ClaimsPrincipal(new ClaimsIdentity());
        var authState = Task.FromResult(new AuthenticationState(nobody));
        NotifyAuthenticationStateChanged(authState);
    }
}
