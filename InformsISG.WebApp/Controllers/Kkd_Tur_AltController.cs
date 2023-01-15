using InformsISG.Core.Utilities.Results;
using InformsISG.Entities.Dtos;
using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InformsISG.WebApp.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,IsgUzman,IsYeriHekim,BirimSorumlusu", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("KkdTurAlt/")]
    public class Kkd_Tur_AltController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IKkd_Tur_AltService _kkd_Tur_AltService;
        private readonly IKkd_TurService _kkd_TurService;

        public Kkd_Tur_AltController(IKkd_Tur_AltService kkdTurAltService,IKkd_TurService kkdTurService)
        {
            _kkd_Tur_AltService = kkdTurAltService;
            _kkd_TurService = kkdTurService;
        }

        [Route("Liste")]
        public async Task<IActionResult> Index()
        {
            ViewBag.KkdTurList = (await _kkd_TurService.GetAllAsync()).Data;
            var result = await _kkd_Tur_AltService.GetAllAsync();
            ViewBag.KkdTurAlt = (await _kkd_Tur_AltService.GetAllAsync()).Data.Count;

            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // GET: Kkd_TurController/Create
        [Route("Olustur")]
        public async Task<IActionResult> Create()
        {
            var result1 = await _kkd_TurService.GetAllAsync();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Kkd_Tur_Id = new SelectList(result1.Data, "Id", "Kkd_Tur_Ad");
            return View();
        }
   
        // POST: Kkd_TurController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        public async Task<IActionResult> Create(Kkd_Tur_AltDTO kkdTurAlt)
        {

            if (ModelState.IsValid)
            {
                var result = await _kkd_Tur_AltService.AddAsync(kkdTurAlt, 1);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                }
                else
                {
                    var result1 = await _kkd_TurService.GetAllAsync();
                    if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Kkd_Tur_Id = new SelectList(result1.Data, "Id", "Kkd_Tur_Ad");
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = result.Message;
                    return View();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Kkd_TurController/Edit/5
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _kkd_Tur_AltService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _kkd_TurService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Kkd_Tur_Id = new SelectList(result1.Data, "Id", "Kkd_Tur_Ad");
                return View(result.Data);
            }
            else
            {
                var result1 = await _kkd_TurService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Kkd_Tur_Id = new SelectList(result1.Data, "Id", "Kkd_Tur_Ad");
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("Index");
        }

        // POST: Kkd_TurController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id, Kkd_Tur_AltDTO kkdTurAlt)
        {
            var result = await _kkd_Tur_AltService.GetAsync(id);
            if (result != null)
            {
                var birimResult = await _kkd_Tur_AltService.UpdateAsync(kkdTurAlt, 2);
                if (birimResult.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = birimResult.Message;
                    return RedirectToAction("Index");
                }
            }
            else
            {
                var result1 = await _kkd_TurService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Kkd_Tur_Id = new SelectList(result1.Data, "Id", "Kkd_Tur_Ad");
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return View();
        }

        // GET: Kkd_TurController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Sil")]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _kkd_Tur_AltService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }


    }
}
