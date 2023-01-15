using InformsISG.Core.Utilities.Results;
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
using System.Security.Claims;
using System.Threading.Tasks;

namespace InformsISG.WebApp.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,IsgUzman,IsYeriHekim", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class Risk_KutuphaneController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly ITali_BirimService _tali_BirimService;
        private readonly IRisk_KategoriService _risk_KategoriService;
        private readonly IRisk_Ust_GrupService _risk_ust_GrupService;
        private readonly IRisk_KonuGrupService _risk_Konu_GrupService;
        private readonly IRisk_KonuService _risk_KonuService;

        private readonly IAcil_Durum_Ekip_PersonelService _acil_durum_ekip_PersonelService;
        private readonly IPersonel_BilgiService _personel_BilgiService;
        private readonly IBirimService _BirimService;
        private readonly IAcil_Durum_EkipleriService _acil_durum_EkipleriService;
        private readonly IIsg_Kurul_Karar2Service _isgKurulKarar2Service;
        private readonly IISg_Kurul_Karar_GundemService _isgKurulKararGundemService;




        public Risk_KutuphaneController(ITali_BirimService taliBirimService, IRisk_KategoriService riskKategoriService, IRisk_Ust_GrupService riskUstGrupService, IRisk_KonuGrupService riskKonuGrupService, IRisk_KonuService riskKonuService, IAcil_Durum_Ekip_PersonelService acilDurumEkipPersonelService, IPersonel_BilgiService personelBilgiService, IBirimService birimService, IAcil_Durum_EkipleriService acilDurumEkipleriService, IIsg_Kurul_Karar2Service isg_Kurul_Karar2Service, IISg_Kurul_Karar_GundemService isgKurulKararGundemService)
        {
            _tali_BirimService = taliBirimService;
            _risk_KategoriService = riskKategoriService;
            _risk_ust_GrupService = riskUstGrupService;
            _risk_Konu_GrupService = riskKonuGrupService;
            _risk_KonuService = riskKonuService;

            _acil_durum_ekip_PersonelService = acilDurumEkipPersonelService;
            _personel_BilgiService = personelBilgiService;
            _BirimService = birimService;
            _acil_durum_EkipleriService = acilDurumEkipleriService;
            _isgKurulKarar2Service = isg_Kurul_Karar2Service;
            _isgKurulKararGundemService = isgKurulKararGundemService;
        }


        // GET: RiskKutuphaneController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RiskKutuphaneController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RiskKutuphaneController/Create
        public async Task<IActionResult> Create()
        {
            var result1 = await _risk_KategoriService.GetAllAsync();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Risk_Kategori_Id = new SelectList(result1.Data, "Id", "Risk_Kategori_Ad");
            var result2 = await _risk_ust_GrupService.GetAllAsync();
            if (result2.ResultStatus == ResultStatus.Success)
                ViewBag.Risk_Ust_Grup_Id = new SelectList(result2.Data, "Id", "Risk_Ust_Grup_Adi");
            return View();
        }

        // POST: RiskKutuphaneController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: RiskKutuphaneController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RiskKutuphaneController/Edit/5
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

        // GET: RiskKutuphaneController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RiskKutuphaneController/Delete/5
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
        public async Task<JsonResult> GetTaliBirim(int id)
        {
            var result = await _tali_BirimService.GetAllTaliBirim(id);
            return Json(new SelectList(result.Data.ToList(), "Id", "Tali_Birim_Ad"));
        }

        [HttpPost]
        public async Task<JsonResult> Hesap(int id)
        {
            var yenideger = id;

            var frekans1 = id % 10;
            yenideger = id / 10;
            var siddet1 = yenideger % 10;
            yenideger = yenideger / 10;
            var olasilik1 = yenideger % 10;

            float olasilik = 1f;
            float siddet = 1;
            float frekans = 1;

            if (olasilik1 == 1)
            {
                olasilik = 0.2f;
            }
            else if (olasilik1 == 2)
            {
                olasilik = 0.5f;
            }
            else if (olasilik1 == 3)
            {
                olasilik = 1f;
            }
            else if (olasilik1 == 4)
            {
                olasilik = 3f;
            }
            else if (olasilik1 == 5)
            {
                olasilik = 6f;
            }
            else if (olasilik1 == 6)
            {
                olasilik = 10f;
            }

            if (frekans1 == 1)
            {
                frekans = 0.5f;
            }
            else if (frekans1 == 1)
            {
                frekans = 1f;
            }
            else if (frekans1 == 3)
            {
                frekans = 2f;
            }
            else if (frekans1 == 4)
            {
                frekans = 3f;
            }
            else if (frekans1 == 5)
            {
                frekans = 6f;
            }
            else if (frekans1 == 6)
            {
                frekans = 10f;
            }


            if (siddet1 == 1)
            {
                siddet = 1f;
            }
            else if (siddet1 == 2)
            {
                siddet = 3f;
            }
            else if (siddet1 == 3)
            {
                siddet = 7f;
            }
            else if (siddet1 == 4)
            {
                siddet = 15f;
            }
            else if (siddet1 == 5)
            {
                siddet = 40f;
            }
            else if (siddet1 == 6)
            {
                siddet = 100f;
            }

            var result = olasilik * siddet * frekans;

            return Json(result);
        }

        [HttpPost]
        public async Task<JsonResult> Hesap2(int id)
        {
            var yenideger = id;
            var olasilik1 = yenideger % 10;
            yenideger = yenideger / 10;
            var siddet1 = yenideger % 10;

            float olasilik = 1f;
            float siddet = 1;
            float frekans = 1;

            if (olasilik1 == 1)
            {
                olasilik = 1f;
            }
            else if (olasilik1 == 2)
            {
                olasilik = 2f;
            }
            else if (olasilik1 == 3)
            {
                olasilik = 3f;
            }
            else if (olasilik1 == 4)
            {
                olasilik = 4f;
            }
            else if (olasilik1 == 5)
            {
                olasilik = 5f;
            }

            if (siddet1 == 1)
            {
                siddet = 1f;
            }
            else if (siddet1 == 2)
            {
                siddet = 2f;
            }
            else if (siddet1 == 3)
            {
                siddet = 3f;
            }
            else if (siddet1 == 4)
            {
                siddet = 4f;
            }
            else if (siddet1 == 5)
            {
                siddet = 5f;
            }

            var result = olasilik * siddet;

            return Json(result);
        }


        [HttpPost]
        public async Task<JsonResult> GetUstGrup(int id)
        {
            var result = await _risk_ust_GrupService.GetAllUstGrup(id);
            return Json(new SelectList(result.Data.ToList(), "Id", "Risk_Ust_Grup_Adi"));
        }

        [HttpPost]
        public async Task<JsonResult> GetKonuGrup(int id)
        {
            var result = await _risk_Konu_GrupService.GetAllKonuGrupAsync(id);
            return Json(new SelectList(result.Data.ToList(), "Id", "Risk_Konu_Grup_Adi"));
        }

        [HttpPost]
        public async Task<JsonResult> GetKonu(int id)
        {
            var result = await _risk_KonuService.GetAllKonuAsync(id);
            var deneme = result.Data.ToList();
            return Json(new SelectList(result.Data.ToList(), "Id", "Risk_Konu_Adi"));
            // return Json(deneme);
        }


        //[HttpPost]
        //public async Task<IActionResult> GetKonu(int id)
        //{
        //    ViewBag.DENEME = (await _risk_KonuService.GetAllKonuAsync(id)).Data;
        //    var result = await _risk_KonuService.GetAllKonuAsync(id);
        //    var deneme = result.Data.ToList();
        //    return Json(new SelectList(result.Data.ToList(), "Id", "Risk_Konu_Adi"));
        //    // return Json(deneme);
        //}


        [HttpPost]
        public async Task<JsonResult> Deneme(int id)
        {
            TempData["deneme"] = id;
            return Json(id);
        }



        [HttpPost]
        public async Task<JsonResult> EndeksHesaplama(int id)
        {
            var yenideger = id;
            var boy = id % 1000;
            double boy2 = (double)boy / 100;
            var kutle = id / 1000;

            var result = kutle / (boy2 * boy2);
            result = Math.Round(result, 2);
            return Json(result);
        }


        [HttpPost]
        public async Task<IActionResult> KurulKararOnay(Isg_Kurul_Karar2DTO isg_kurul_karar, int id)
        {
            var result = await _isgKurulKarar2Service.GetAsync(id);
            result.Data.TamamlandiMi = true;
            isg_kurul_karar.Id = result.Data.Id;
            isg_kurul_karar.Isg_Kurul_Karar_Id = result.Data.Isg_Kurul_Karar_Id;
            isg_kurul_karar.Karar_No = result.Data.Karar_No;
            isg_kurul_karar.Alinan_Kararlar = result.Data.Alinan_Kararlar;
            isg_kurul_karar.Personel_Id = result.Data.Personel_Id;
            isg_kurul_karar.Baslangic_Tarih = result.Data.Baslangic_Tarih;
            isg_kurul_karar.Bitis_Tarih = result.Data.Bitis_Tarih;
            isg_kurul_karar.TamamlandiMi = true;
            var resultObj = await _isgKurulKarar2Service.UpdateAsync(isg_kurul_karar, 2);


            ViewBag.IsgKurulKararId_ = isg_kurul_karar.Isg_Kurul_Karar_Id;
            TempData["IsgKurulKararId"] = isg_kurul_karar.Isg_Kurul_Karar_Id;
            ViewBag.KurulKararListe = (await _isgKurulKarar2Service.GetAllAsync()).Data;
            ViewBag.PersonelListe = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;

            var result1 = await _personel_BilgiService.GetAllAsync(currentKurul);
            ViewBag.Personel_Id = new SelectList(result1.Data, "Id", "Ad_Soyad");


            return RedirectToAction("KurulKarar","Index");
        }



        [HttpPost]
        public async Task<JsonResult> KurulKararCikar(int id)
        {
            var result = await _isgKurulKarar2Service.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }


        [HttpPost]
        public async Task<JsonResult> GundemMaddesiCikar(int id)
        {
            var result = await _isgKurulKararGundemService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }



    }
}
