using WebAppCap7.Models;

namespace WebAppCap7.Service
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> RegisterAsync(string email, string password, string role);
        Task<AuthenticationResponse> LoginAsync(string email, string password);
    }
}
