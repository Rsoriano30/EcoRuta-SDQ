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
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _usuarioService.GetByEmailAsync(model.Correo);

            if (user == null)
            {
                ModelState.AddModelError("", "Credenciales inválidas.");
                return View(model);
            }

            var hasher = new PasswordHasher<object>();
            var result = hasher.VerifyHashedPassword(null, user.Contraseña, model.Contraseña);

            if (result == PasswordVerificationResult.Success)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Nombre),
                    new Claim(ClaimTypes.NameIdentifier, user.UsuarioId.ToString()),
                    new Claim(ClaimTypes.Role, user.TipoUsuario)
                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", principal);

                if (user.TipoUsuario == "Administrador")
                {
                    return RedirectToAction("Dashboard", "Home");
                }

                else if (user.TipoUsuario == "Usuario")
                {
                    return RedirectToAction("Index", "Reportes");
                }
            }

            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                var hasher = new PasswordHasher<object>();
                model.Contraseña = hasher.HashPassword(null, model.Contraseña);

                await _usuarioService.Add(model);

                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
