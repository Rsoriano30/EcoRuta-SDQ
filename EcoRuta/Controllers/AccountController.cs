using System.Security.Claims;
using Application.Intefaces.Services;
using Application.ViewModels.Usuarios;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace EcoRuta.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public AccountController(IUsuarioService usuarioService) 
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpGet]
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

            if (user == null)
            {
                ModelState.AddModelError("", "Credenciales inválidas.");
                return View(model);
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Nombre),
                new Claim(ClaimTypes.Email, user.Correo),
                new Claim(ClaimTypes.Role, user.TipoUsuario),
                new Claim("UserId", user.UsuarioId.ToString())
            };

            // Crear la identidad y principal
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true // Si se mantiene la sesión
            };

            await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            switch (user.TipoUsuario)
            {
                case "Usuario":
                    return RedirectToAction("Index", "Home");

                case "Administrador":
                    return RedirectToAction("Index", "Asignaciones");

                default:
                    ModelState.AddModelError("", "Rol desconocido");
                    return View(model);
            }
        }
    }
}
