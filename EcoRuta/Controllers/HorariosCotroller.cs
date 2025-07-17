using Application.Intefaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoRuta.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class HorariosCotroller : Controller
    {
        IHorariosService _horariosService;

        public HorariosCotroller(IHorariosService horariosService)
        {
            _horariosService = horariosService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _horariosService.GetAll();

            return View(model);
        }
    }
}
