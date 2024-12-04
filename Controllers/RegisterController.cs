using Microsoft.AspNetCore.Mvc;
using WebAppCap7.ViewModels;

namespace WebAppCap7.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // Devuelve la vista con el formulario de registro
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Aquí puedes agregar la lógica para registrar al usuario, por ejemplo:
                if (model.Email == "francisco@gmail.com" && model.Password == "1234")
                {
                    TempData["Message"] = "Usuario registrado exitosamente.";
                }
                else
                {
                    TempData["Message"] = "Registro fallido. Intente nuevamente.";
                }

                return RedirectToAction("Index");
            }

            // Si el modelo no es válido, se vuelve a cargar la vista con los errores
            return View("Index", model);
        }
    }
}
