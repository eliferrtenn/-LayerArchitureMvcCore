using InformsISG.Core.Utilities.Results;
using InformsISG.Entities.Concrete;
using InformsISG.Entities.Dtos;
using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformsISG.WebApp.Controllers
{
    public class Tehlike_TanimController : Controller
    {

        private readonly ITehlike_TanimService _tehlike_TanimService;

        public Tehlike_TanimController(ITehlike_TanimService tehlike_TanimService)
        {
            _tehlike_TanimService = tehlike_TanimService;
        }
        // GET: Tehlike_TanimController
        public async Task<IActionResult> Index()
        {
            var result = await _tehlike_TanimService.GetAllAsync();

            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }


        // GET: Tehlike_TanimController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tehlike_TanimController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tehlike_TanimDTO tehlike_tanim)
        {
            if (ModelState.IsValid)
            {
                var result = await _tehlike_TanimService.AddAsync(tehlike_tanim, 1);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = result.Message;
                    return View();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Tehlike_TanimController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _tehlike_TanimService.GetAsync(id);

            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // POST: Tehlike_TanimController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tehlike_TanimController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tehlike_TanimController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
