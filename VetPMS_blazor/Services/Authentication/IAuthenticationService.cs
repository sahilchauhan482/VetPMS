using VetPMS.Models;

namespace VetPMS.Services.Authentication
{
    public interface IAuthenticationService
    {
            Task<AuthResponse>AuthenticateAsync(AuthLogin authLogin);
            public Task Logout();
       
    }
}
