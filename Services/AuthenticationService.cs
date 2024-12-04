using WebAppCap7.Helpers;
using WebAppCap7.Models;

namespace WebAppCap7.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly List<User> _users = new List<User>();

        public Task<AuthenticationResponse> RegisterAsync(string email, string password, string role)
        {
            if (_users.Any(u => u.Email == email))
                return Task.FromResult(new AuthenticationResponse { Success = false, Message = "Email already exists" });

            var hashedPassword = EncryptionHelper.HashPassword(password);
            _users.Add(new User { Email = email, PasswordHash = hashedPassword, Role = role });

            return Task.FromResult(new AuthenticationResponse { Success = true, Message = "User registered successfully" });
        }

        public Task<AuthenticationResponse> LoginAsync(string email, string password)
        {
            var user = _users.FirstOrDefault(u => u.Email == email);
            if (user == null || !EncryptionHelper.VerifyPassword(password, user.PasswordHash))
                return Task.FromResult(new AuthenticationResponse { Success = false, Message = "Invalid credentials" });

            return Task.FromResult(new AuthenticationResponse { Success = true, Role = user.Role });
        }
    }

}
