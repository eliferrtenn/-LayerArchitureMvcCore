using InformsISG.Core.Utilities.Results;
using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Route("EgitimPersonelAta")]
    public class Egitim_Personel_Atama : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IEgitim_Personel_AtamaService _egitim_personel_atamaService;
        private readonly IEgitim_Konu_Alt_BaslikService _egitim_konu_alt_BaslikService;
        private readonly IISg_KurulService _isg_KurulService;
        private readonly IIsverenService _isverenService;

        public Egitim_Personel_Atama(IEgitim_Personel_AtamaService egitimPersonelAtamaService,IEgitim_Konu_Alt_BaslikService egitimKonuAltBaslikService,IISg_KurulService isgKurulService,IIsverenService isverenService)
        {
            _egitim_personel_atamaService = egitimPersonelAtamaService;
            _egitim_konu_alt_BaslikService = egitimKonuAltBaslikService;
            _isg_KurulService = isgKurulService;
            _isverenService = isverenService;
        }
      
        // GET: Egitim_Personel_Atama
        [Route("Liste")]
        public async Task<IActionResult> Index()
        {
            var result = await _egitim_personel_atamaService.GetAllAsync();
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _egitim_konu_alt_BaslikService.GetAllAsync();
                ViewBag.Egitim_Konu_Id = new SelectList(result1.Data, "Id", "Alt_Baslik_Ad");
                var result2 = await _isg_KurulService.GetAllAsync();
                ViewBag.Egitim_Konu_Id = new SelectList(result1.Data, "Id", "Kurul,Ad");
                var result3 = await _isverenService.GetAllAsync();
                ViewBag.Egitim_Konu_Id = new SelectList(result1.Data, "Id", "Isveren_Ad");
                return View(result.Data);
            }
            return View();
        }

        // GET: Egitim_Personel_Atama/Create
        [Route("Olustur")]
        public async Task<IActionResult> Create()
        {
            var result1 = await _egitim_konu_alt_BaslikService.GetAllAsync();
            ViewBag.Egitim_Konu_Id = new SelectList(result1.Data, "Id", "Alt_Baslik_Ad");
            var result2 = await _isg_KurulService.GetAllAsync();
            ViewBag.Egitim_Konu_Id = new SelectList(result1.Data, "Id", "Kurul,Ad");
            var result3 = await _isverenService.GetAllAsync();
            ViewBag.Egitim_Konu_Id = new SelectList(result1.Data, "Id", "Isveren_Ad");
            return View();
        }

        // POST: Egitim_Personel_Atama/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        public ActionResult Create(IFormCollection collection)
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

        // GET: Egitim_Personel_Atama/Edit/5
        [Route("Duzenle")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Egitim_Personel_Atama/Edit/5
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

        // GET: Egitim_Personel_Atama/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Sil")]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _egitim_personel_atamaService.HardDeleteAsync(id);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }
    }
}
