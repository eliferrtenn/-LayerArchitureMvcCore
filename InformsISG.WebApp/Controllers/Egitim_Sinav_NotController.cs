using InformsISG.Core.Utilities.Results;
using InformsISG.Entities.Concrete;
using InformsISG.Entities.Dtos;
using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InformsISG.WebApp.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,IsgUzman,IsYeriHekim,BirimSorumlusu", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("EgitimSinavNot/")]
    public class Egitim_Sinav_NotController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IEgitim_Sinav_NotService _egitim_sinav_NotService;

        public Egitim_Sinav_NotController(IEgitim_Sinav_NotService egitim_sinav_NotService)
        {
            _egitim_sinav_NotService = egitim_sinav_NotService;
        }

        // GET: Egitim_Sinav_NotController
        [Route("Liste")]
        public async Task<IActionResult> Index()
        {
            var result = await _egitim_sinav_NotService.GetAllAsync();

            ViewBag.SinavNot = (await _egitim_sinav_NotService.GetAllAsync()).Data.Count;


            if (result.ResultStatus == ResultStatus.Success)
            {
                //ViewBag.EgitimSinav = id;
                return View(result.Data);
            }
            return View();
        }

        [Route("Olustur")]
        // GET: Egitim_Sinav_NotController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Egitim_Sinav_NotController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        public async Task<IActionResult> Create(Egitim_Sinav_NotDTO egitim_sinav_not)
        {
            if (ModelState.IsValid)
            {
                var result = await _egitim_sinav_NotService.AddAsync(egitim_sinav_not, 1);
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

        // GET: Egitim_Sinav_NotController/Edit/5
        [Route("Duzenle")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Egitim_Sinav_NotController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Duzenle")]
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

        // GET: Egitim_Sinav_NotController/Delete/5
        [Route("Sil")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _egitim_sinav_NotService.DeleteAsync(id, 1);
            if (result.ResultStatus == ResultStatus.Success)
            {
                TempData["MessageIcon"] = "success";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("Index");
        }


    }
}
