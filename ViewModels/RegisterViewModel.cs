using System.Windows.Input;
using WebAppCap7.Service;

namespace WebAppCap7.ViewModels
{

    public class RegisterViewModel
    {
        private readonly IAuthenticationService _authService;

        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "user";
        public ICommand RegisterCommand { get; }

        public RegisterViewModel(IAuthenticationService authService)
        {
            _authService = authService;
            RegisterCommand = new Helpers.RelayCommand(async _ => await RegisterAsync());
        }

        private async Task RegisterAsync()
        {
            var response = await _authService.RegisterAsync(Email, Password, Role);
            // Manejar la respuesta
        }
    }

}
