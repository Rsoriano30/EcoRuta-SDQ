﻿using Application.Intefaces.Services;
using Application.ViewModels.Choferes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoRuta.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ChoferesController : Controller
    {
        private readonly IChoferesService _choferesService;

        public ChoferesController(IChoferesService choferesService)
        {
            _choferesService = choferesService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _choferesService.GetAll();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateChofer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateChoferPost(ChoferSaveViewModel model)
        {
            try
            {
                await _choferesService.Add(model);
            }
            catch
            {
                return View("CreateChofer", model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditChofer(int id)
        {
            var model = await _choferesService.GetById(id);

            if (model == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditChoferPost(ChoferViewModel model)
        {
            try
            {
                await _choferesService.Update(model, model.ChoferId);
            }
            catch
            {
                return RedirectToAction("PageNotFound", "Home");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteChofer(int id)
        {
            try
            {
                var model = await _choferesService.GetById(id);

                return View(model);
            }
            catch
            {
                return RedirectToAction("PageNotFound", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteChoferPost(int id)
        {
            try
            {
                await _choferesService.Delete(id);
            }
            catch
            {
                return RedirectToAction("DeleteChofer", id);
            }

            return RedirectToAction("Index");
        }
    }
}
