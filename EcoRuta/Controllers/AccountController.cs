using Application.Intefaces.Services;
using Application.ViewModels.Usuarios;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcoRuta.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public AccountController(IUsuarioService usuarioService) 
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Login() => View();
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Contraseña.Length < 8)
                {
                    ModelState.AddModelError("", "La contraseña debe tener al menos 8 caracteres.");
                    return View(model);
                }

                //no implementado todavia el hashing
                //model.Contraseña = PassWordHash

                await _usuarioService.Add(model);
                return View("Login");

            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _usuarioService.GetByEmailAndPasswordAsync(model.Correo, model.Contraseña);

            if (user != false) { return RedirectToAction("Index", "Reportes"); }

            ModelState.AddModelError("", "Credenciales inválidas.");
            return View(model);
        }
    }
}
