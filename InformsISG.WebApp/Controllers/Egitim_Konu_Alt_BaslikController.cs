
using InformsISG.Core.Utilities.Results;
using InformsISG.Entities.Concrete;
using InformsISG.Entities.Dtos;
using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InformsISG.WebApp.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,IsgUzman,IsYeriHekim,BirimSorumlusu", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("AltEgitimKonu/")]
    public class Egitim_Konu_Alt_BaslikController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IEgitim_Konu_Alt_BaslikService _egitim_konu_AltBaslikService;
        private readonly IEgitim_KonuService _egitim_KonuService;

        public Egitim_Konu_Alt_BaslikController(IEgitim_Konu_Alt_BaslikService egitim_konu_AltbaslikService,IEgitim_KonuService egitim_KonuService)
        {
            _egitim_konu_AltBaslikService = egitim_konu_AltbaslikService;
            _egitim_KonuService = egitim_KonuService;
        }

        // GET: Egitim_Konu_AltBaslikController
        [Route("Liste")]
        public async Task<IActionResult> Index()
        {
            var result = await  _egitim_konu_AltBaslikService.GetAllAsync();

            if (result.ResultStatus == ResultStatus.Success)
            {

                var result1 = await _egitim_KonuService.GetAllAsync();
                ViewBag.Egitim_Konu_Id= new SelectList(result1.Data, "Id", "Egitim_Ad");
                return View(result.Data);
            }

            return View();
        }



        // GET: Egitim_Konu_AltBaslikController/Create
        [Route("Olustur")]
        public async Task<IActionResult> Create()
        {
            var result1 = await _egitim_KonuService.GetAllAsync();
            ViewBag.Egitim_Konu_Id = new SelectList(result1.Data, "Id", "Egitim_Ad");
            return View();
        }

        // POST: Egitim_Konu_AltBaslikController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        public async Task<IActionResult> Create(Egitim_Konu_Alt_BaslikDTO egitim_Konu_AltBaslik)
        {
            if (ModelState.IsValid)
            {
                var result = await _egitim_konu_AltBaslikService.AddAsync(egitim_Konu_AltBaslik, 1);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = result.Message;
                    var result1 = await _egitim_KonuService.GetAllAsync();
                    ViewBag.Egitim_Konu_Id = new SelectList(result1.Data, "Id", "Egitim_Ad");
                    return View();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Egitim_Konu_AltBaslikController/Edit/5
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _egitim_konu_AltBaslikService.GetAsync(id);

            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _egitim_KonuService.GetAllAsync();
                ViewBag.Egitim_Konu_Id = new SelectList(result1.Data, "Id", "Egitim_Ad");
                return View(result.Data);
            }

            return View();
        }

        // POST: Egitim_Konu_AltBaslikController/Edit/5
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

        // GET: Egitim_Konu_AltBaslikController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Egitim_Konu_AltBaslikController/Delete/5
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


        [HttpPost]
        public async Task<JsonResult> EditComponent(Egitim_Konu_Alt_BaslikDTO egitim_Konu)
        {
            if (ModelState.IsValid)
            {
                var result = await _egitim_konu_AltBaslikService.AddAsync(egitim_Konu, 1);
                if (result.ResultStatus == ResultStatus.Success)
                {

                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = result.Message;
                }
            }
            //return Json(Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(egitim_Konu));
            return Json(new { success = true, message = "Baaşaarıyla Eklendi", data = _egitim_konu_AltBaslikService.GetAllAsync()});
        }


        public async Task<IActionResult> DENEME()
        {

            var result = await _egitim_konu_AltBaslikService.GetAllAsync();

            if (result.ResultStatus == ResultStatus.Success)
            {

                var result1 = await _egitim_KonuService.GetAllAsync();
                ViewBag.Egitim_Konu_Id = new SelectList(result1.Data, "Id", "Egitim_Ad");
                return PartialView("EgitimKonuAltBaslikPartialView",result.Data);
            }
            return PartialView();
        }
    }
}
