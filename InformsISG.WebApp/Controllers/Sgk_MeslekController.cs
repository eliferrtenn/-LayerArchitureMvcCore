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
    public class Sgk_MeslekController : Controller
    {
        private readonly ISgk_MeslekService _sgk_MeslekService;

        public Sgk_MeslekController(ISgk_MeslekService sgk_MeslekService)
        {
            _sgk_MeslekService = sgk_MeslekService;
        }

        // GET: Sgk_MeslekController
        public async Task<IActionResult> Index()
        {
            var result = await _sgk_MeslekService.GetAllAsync();

            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }


        // GET: Sgk_MeslekController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sgk_MeslekController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sgk_MeslekDTO sgk_meslek)
        {
            if (ModelState.IsValid)
            {
                var result = await _sgk_MeslekService.AddAsync(sgk_meslek, 1);
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

        // GET: Sgk_MeslekController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sgk_MeslekController/Edit/5
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

        // GET: Sgk_MeslekController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sgk_MeslekController/Delete/5
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
