using Application.Intefaces.Services;
using Application.ViewModels.Choferes;
using Microsoft.AspNetCore.Mvc;

namespace EcoRuta.Controllers
{
    public class ChoferesController : Controller
    {
        private readonly IChoferesService _choferesService;

        public ChoferesController(IChoferesService choferesService)
        {
            _choferesService = choferesService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _choferesService.GetAll();

            return View(model);
        }
    }
}
