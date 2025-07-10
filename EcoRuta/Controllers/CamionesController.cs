using Application.Intefaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcoRuta.Controllers
{
    public class CamionesController : Controller
    {
        private readonly ICamionesService _camionesService;

        public CamionesController(ICamionesService camionesService)
        {
            _camionesService = camionesService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _camionesService.GetAll();
            
            return View(model);
        }
    }
}
