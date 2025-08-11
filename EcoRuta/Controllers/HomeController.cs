using System.Diagnostics;
using EcoRuta.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Intefaces.Services;
using Application.ViewModels.Admin;

namespace EcoRuta.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioService _usuarioService;
        public HomeController(ILogger<HomeController> logger, IUsuarioService usuarioService)
            {
                _logger = logger;
                _usuarioService = usuarioService;
            }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult PageNotFound()
        {
            return View("404");
        }

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Dashboard()
        {
            var stats = await _usuarioService.ObtenerEstadisticasDashboardAsync();
            return View(stats);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
