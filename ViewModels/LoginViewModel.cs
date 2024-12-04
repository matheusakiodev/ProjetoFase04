using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using WebAppCap7.Service;

namespace WebAppCap7.ViewModels
{
    public class LoginViewModel
    {
        private readonly IAuthenticationService _authService;

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Password { get; set; } = string.Empty;
        public string LoginMessage { get; private set; } = string.Empty;
        public ICommand LoginCommand { get; }

        public LoginViewModel(IAuthenticationService authService)
        {
            _authService = authService;
            LoginCommand = new Helpers.RelayCommand(async _ => await LoginAsync());
        }

        private async Task LoginAsync()
        {
            // Simulación de autenticación
            if (Email == "francisco@gmail.com" && Password == "1234")
            {
                LoginMessage = "Login exitoso. ¡Bienvenido!";
            }
            else
            {
                LoginMessage = "Credenciales incorrectas. Por favor, inténtelo de nuevo.";
            }

            // Aquí puedes agregar lógica para notificar cambios a la vista si usas algún mecanismo como INotifyPropertyChanged.
        }
    }
}
