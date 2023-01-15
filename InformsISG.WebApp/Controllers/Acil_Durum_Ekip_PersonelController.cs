using InformsISG.Core.Utilities.Results;
using InformsISG.Entities.Concrete;
using InformsISG.Entities.Dtos;
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
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InformsISG.WebApp.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,IsgUzman,IsYeriHekim,BirimSorumlusu", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("AcilDurumEkip/")]
    public class Acil_Durum_Ekip_PersonelController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IAcil_Durum_Ekip_PersonelService _acil_durum_ekip_PersonelService;
        private readonly IBirimService _BirimService;
        private readonly IPersonel_BilgiService _personel_BilgiService;
        private readonly IAcil_Durum_EkipleriService _acil_durum_EkipleriService;


        public Acil_Durum_Ekip_PersonelController(IAcil_Durum_Ekip_PersonelService acil_durum_ekip_PersonelService,IBirimService birimService,IPersonel_BilgiService personelBilgiService,IAcil_Durum_EkipleriService acilDurumEkipleriService)
        {
            _acil_durum_ekip_PersonelService = acil_durum_ekip_PersonelService;
            _BirimService = birimService;
            _personel_BilgiService = personelBilgiService;
            _acil_durum_EkipleriService = acilDurumEkipleriService;
        }
     
        
        [Route("Liste")]
        public async Task<IActionResult> Index()
        {
            var result = await _acil_durum_ekip_PersonelService.GetAllAsync(currentKurul);

            ViewBag.Ekip = (await _acil_durum_ekip_PersonelService.GetAllAsync(currentKurul)).Data.Count;
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _BirimService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");
                var result2 = await _personel_BilgiService.GetAllAsync(currentKurul);
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Personel_Id = new SelectList(result2.Data, "Id", "Ad_Soyad");
                var result3 = await _acil_durum_EkipleriService.GetAllAsync();
                if (result3.ResultStatus == ResultStatus.Success)
                    ViewBag.Ekip_Id = new SelectList(result3.Data, "Id", "Ekip_Ad");
                return View(result.Data);
            }
            return View();
        }

        [Route("Olustur")]
        // GET: Acil_Durum_Ekip_PersonelController/Create
        public async Task<IActionResult> Create(int id)
        {
            ViewBag.EkipId = id;

            TempData["EkipId"] = id;
            var idd = TempData["c"];
            //TempData["deneme"] = 3;
            ViewBag.EkipList = (await _acil_durum_ekip_PersonelService.GetEkip(id)).Data;
            ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
            var result1 = await _BirimService.GetAllAsync();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");
            var result2 = await _personel_BilgiService.GetAllAsync(currentKurul);
            if (result2.ResultStatus == ResultStatus.Success)
                ViewBag.Personel_Id = new SelectList(result2.Data, "Id", "Ad_Soyad");
            var result3 = await _acil_durum_EkipleriService.GetAllAsync();
            if (result3.ResultStatus == ResultStatus.Success)
                ViewBag.Ekip_Id = new SelectList(result3.Data, "Id", "Ekip_Ad");
            return View();
        }

        public async Task<IActionResult> Deneme(int id)
        {
            TempData["EkipId"] = TempData["c"];
            TempData["deneme"] = id;
            ViewBag.EkipId = TempData["c"];
            ViewBag.EkipList = (await _acil_durum_ekip_PersonelService.GetEkip((long)TempData["c"])).Data;
            ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
            var result1 = await _BirimService.GetAllAsync();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");
            var result2 = await _personel_BilgiService.GetAllAsync(currentKurul);
            if (result2.ResultStatus == ResultStatus.Success)
                ViewBag.Personel_Id = new SelectList(result2.Data, "Id", "Ad_Soyad");
            var result3 = await _acil_durum_EkipleriService.GetAllAsync();
            if (result3.ResultStatus == ResultStatus.Success)
                ViewBag.Ekip_Id = new SelectList(result3.Data, "Id", "Ekip_Ad");
            return View();
        }

        // POST: Acil_Durum_Ekip_PersonelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        public async Task<IActionResult> Create(Acil_Durum_Ekip_PersonelDTO acilDurumEkipPersonel,int id)
        {
            acilDurumEkipPersonel.Ekip_Id = Convert.ToInt64(id);
            acilDurumEkipPersonel.Id = 0;
            TempData["EkipId"] =id;
            ViewBag.EkipId = id;
            
                var result = await _acil_durum_ekip_PersonelService.AddAsync(acilDurumEkipPersonel, 1);
                ViewBag.EkipList = (await _acil_durum_ekip_PersonelService.GetEkip(id)).Data;
                ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var result1 = await _BirimService.GetAllAsync();
                    if (result1.ResultStatus == ResultStatus.Success)
                        ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");
                    var result2 = await _personel_BilgiService.GetAllAsync(currentKurul);
                    if (result2.ResultStatus == ResultStatus.Success)
                        ViewBag.Personel_Id = new SelectList(result2.Data, "Id", "Ad_Soyad");
                    var result3 = await _acil_durum_EkipleriService.GetAllAsync();
                    if (result3.ResultStatus == ResultStatus.Success)
                        ViewBag.Ekip_Id = new SelectList(result3.Data, "Id", "Ekip_Ad");
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = result.Message;
                    var result1 = await _BirimService.GetAllAsync();
                    if (result1.ResultStatus == ResultStatus.Success)
                        ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");
                    var result2 = await _personel_BilgiService.GetAllAsync(currentKurul);
                    if (result2.ResultStatus == ResultStatus.Success)
                        ViewBag.Personel_Id = new SelectList(result2.Data, "Id", "Ad_Soyad");
                    var result3 = await _acil_durum_EkipleriService.GetAllAsync();
                    if (result3.ResultStatus == ResultStatus.Success)
                        ViewBag.Ekip_Id = new SelectList(result3.Data, "Id", "Ekip_Ad");
                    return View();
                }
            
            return View();
        }

        [Route("Duzenle")]
        // GET: Acil_Durum_Ekip_PersonelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Acil_Durum_Ekip_PersonelController/Edit/5
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
   
        
        // POST: Acil_Durum_Ekip_PersonelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Sil")]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _acil_durum_ekip_PersonelService.HardDeleteAsync(id);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }
    }
}
