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
    [Route("KurulKararDosya/")]
    public class Isg_Kurul_Karar_DosyaController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IISg_Kurul_Karar_DosyaService _isg_kurul_karar_DosyaService;
        private readonly IISg_Kurul_KararService _isgKurulKararService;
        private readonly IIsverenService _isverenService;

        public Isg_Kurul_Karar_DosyaController(IISg_Kurul_Karar_DosyaService isg_kurul_karar_DosyaService, IISg_Kurul_KararService isg_kurul_kararService, IIsverenService isverenService)
        {
            _isg_kurul_karar_DosyaService = isg_kurul_karar_DosyaService;
            _isgKurulKararService = isg_kurul_kararService;
            _isverenService = isverenService;
        }


        // GET: Isg_Kurul_Karar_DosyaController
        [Route("Liste")]
        public async Task<IActionResult> Index()
        {
            var result = await _isg_kurul_karar_DosyaService.GetAllAsync();
            ViewBag.KurulKararDosya = (await _isg_kurul_karar_DosyaService.GetAllAsync()).Data.Count;


            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _isg_kurul_karar_DosyaService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");
                var result2 = await _isverenService.GetAllAsync();
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
                return View(result.Data);
            }
            return View();
        }

        // GET: Isg_Kurul_Karar_DosyaController/Create
        [Route("Olustur")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Isg_Kurul_Karar_DosyaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        public async Task<IActionResult> Create(Isg_Kurul_Karar_DosyaDTO isg_kurul_karar_Dosya)
        {
            if (ModelState.IsValid)
            {
                var result = await _isg_kurul_karar_DosyaService.AddAsync(isg_kurul_karar_Dosya, 1);
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

        // GET: Isg_Kurul_Karar_DosyaController/Edit/5
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _isg_kurul_karar_DosyaService.GetAsync(id);

            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _isg_kurul_karar_DosyaService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");
                var result2 = await _isverenService.GetAllAsync();
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
                return View(result.Data);
            }
            return View();
        }

        // POST: Isg_Kurul_Karar_DosyaController/Edit/5
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

        // GET: Isg_Kurul_Karar_DosyaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Isg_Kurul_Karar_DosyaController/Delete/5
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
