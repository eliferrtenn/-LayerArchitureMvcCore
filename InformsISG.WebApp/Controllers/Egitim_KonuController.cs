using InformsISG.Core.Utilities.Results;
using InformsISG.Core.Utilities.Results.Concrete;
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
using System.Security.Claims;
using System.Threading.Tasks;

namespace InformsISG.WebApp.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,IsgUzman,IsYeriHekim,BirimSorumlusu", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("EgitimKonu/")]
    public class Egitim_KonuController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IEgitim_KonuService _egitimKonuService;
        private readonly IEgitim_Konu_Alt_BaslikService _egitim_konu_Alt_BaslikService;

        private readonly IEgitim_Tanim_KonuService _egitim_Tanim_KonuService;
        private readonly IEgitim_Personel_AtamaService _egitim_Personel_AtamaService;
        private readonly IPersonel_BilgiService _personel_BilgiService;
        private readonly IIsverenService _isverenService;
        private readonly IEgitim_TanimlaService _egitimTanimlaService;
        private readonly IBirimService _birimService;

        public Egitim_KonuController(IEgitim_KonuService egitimKonuService,IEgitim_Konu_Alt_BaslikService egitim_Konu_Alt_BaslikService,IEgitim_Tanim_KonuService egitimTanimKonuService,IEgitim_Personel_AtamaService egitimPersonelAtamaService,IPersonel_BilgiService personelBilgiService,IIsverenService isverenService,IEgitim_TanimlaService egitimTanimlaService,IBirimService birimService)
        {
            _egitimKonuService = egitimKonuService;
            _egitim_konu_Alt_BaslikService = egitim_Konu_Alt_BaslikService;

            _egitim_Tanim_KonuService = egitimTanimKonuService;
            _egitim_Personel_AtamaService = egitimPersonelAtamaService;
            _personel_BilgiService = personelBilgiService;
            _isverenService = isverenService;
            _egitimTanimlaService = egitimTanimlaService;
            _birimService = birimService;
        }

        // GET: Egitim_KonuController
        [Route("Liste")]
        public async Task<IActionResult> Index()
        {
            var result = await _egitimKonuService.GetAllAsync();

            ViewBag.Konu = (await _egitimKonuService.GetAllAsync()).Data.Count;


            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // GET: Egitim_KonuController/Create
        [Route("Olustur")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Egitim_KonuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        public async Task<IActionResult> Create(Egitim_KonuDTO egitim_Konu)
        {
            if (ModelState.IsValid)
            {
                var result = await _egitimKonuService.AddAsync(egitim_Konu, 1);
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

        // GET: Egitim_KonuController/Edit/5
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _egitimKonuService.GetAsync(id);

            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }

            return View();
        }

        // POST: Egitim_KonuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id, Egitim_KonuDTO egitim_Konu)
        {
            var result = await _egitimKonuService.GetAsync(id);
            if (result != null)
            {
                var egitimResult = await _egitimKonuService.UpdateAsync(egitim_Konu, 2);

                if (egitimResult.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = egitimResult.Message;
                    return RedirectToAction("Index");
                }
           
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return View();
        }

        // GET: Egitim_KonuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Sil")]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _egitimKonuService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }

       
        // GET: Egitim_KonuController/Edit/5
        [Route("OlusturEgitim")]
        [HttpGet]
        public async Task<IActionResult> CreateAltBaslik(int Id)
        {
            var result = await _egitimKonuService.GetAsync(Id);
            ViewBag.EgitimAdi = (await _egitim_konu_Alt_BaslikService.GetAllEgitimKonuAsync(Id)).Data;
            TempData["EgitimId"] = Id;

            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        [Route("OlusturEgitim")]
        [HttpPost]
        public async Task<IActionResult> CreateAltBaslik(string EgitimNo, string EgitimAd, string sure,Egitim_Konu_Alt_BaslikDTO egitim_Konu_Alt_BaslikDTO)
        {

            egitim_Konu_Alt_BaslikDTO.Alt_Baslik_No = EgitimNo;
            egitim_Konu_Alt_BaslikDTO.Alt_Baslik_Ad = EgitimAd;
            egitim_Konu_Alt_BaslikDTO.Sure = sure;
            egitim_Konu_Alt_BaslikDTO.Egitim_Konu_Id = Convert.ToInt64(TempData["EgitimId"]);

            ViewBag.EgitimAdi = (await _egitim_konu_Alt_BaslikService.GetAllEgitimKonuAsync(Convert.ToInt64(TempData["EgitimId"]))).Data;


            var result = await _egitim_konu_Alt_BaslikService.AddAsync(egitim_Konu_Alt_BaslikDTO,1);
            var resultObject = await _egitimKonuService.GetAsync(Convert.ToInt64(TempData["EgitimId"]));

            if (result.ResultStatus == ResultStatus.Success)
            {
                TempData["MessageIcon"] = "success";
                TempData["MessageText"] = result.Message;
                return View(resultObject.Data);
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return View();
        }


        // GET: Egitim_KonuController
        [Route("KalanEgitim")]
        public async Task<IActionResult> KalanEgitim()
        {
            var result = await _egitim_konu_Alt_BaslikService.GetAllAsync();

            ViewBag.Konu = (await _egitimKonuService.GetAllAsync()).Data.Count;


            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }   
      
        [Route("KalanEgitim2")]
        public async Task<IActionResult> KalanEgitim2(int id)
        {
            var result = await _egitim_Tanim_KonuService.GetKonuAltAsync(id);
            List<long> egitimTanim = new List<long>();

            foreach(var item in result.Data)
            {
                egitimTanim.Add(item.Egitim_Tanimla_Id);
            }

            List<long> egitimPersonelId = new List<long>();

            foreach (var item in egitimTanim)
            {
               var egitim= await _egitim_Personel_AtamaService.GetEgitimAsync(item);
               foreach(var item2 in egitim.Data)
                {
                    egitimPersonelId.Add(item2.Personel_Id);
                }
            }

            var personelListe = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
            List<long> personelListem = new List<long>();

            foreach (var item in personelListe)
            {
                personelListem.Add(item.Id);
            }

            ViewBag.liste = personelListem.Except(egitimPersonelId).ToList();


            ViewBag.Count = result.Data.Count;
            ViewBag.Konu = (await _egitimKonuService.GetAllAsync()).Data.Count;

            ViewBag.EgitimGirenPersonel = (await _egitim_Personel_AtamaService.GetAllAsync()).Data;
            ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
            TempData["EgitimKonuId"] = id;

            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }


        [HttpGet]
        [Route("KalanEgitimOlustur")]
        public async Task<IActionResult> CreateKalanEgitim()
        {
            var result3 = await _isverenService.GetAllAsync();
            ViewBag.Isveren_Id = new SelectList(result3.Data, "Id", "Isveren_Ad");
            var deneme2= TempData["EgitimKonuId"];
            return View();
        }

        [HttpPost]
        [Route("KalanEgitimOlustur")]
        public async Task<IActionResult> CreateKalanEgitim(Egitim_TanimlaDTO egitimTanimlaDTO,Egitim_Tanim_KonuDTO egitim_Tanim_KonuDTO,Egitim_Personel_AtamaDTO egitim_Personel_AtamaDTO)
        {
         
            var id= Convert.ToInt64(TempData["EgitimKonuId"]);
            var result = await _egitim_Tanim_KonuService.GetKonuAltAsync(id);
            var resultObject3 = (await _birimService.GetAsync(currentKurul)).Data.Isg_Kurul_Id;
            egitimTanimlaDTO.Isg_Kurul_Id = resultObject3;
            var resultObject = await _egitimTanimlaService.AddAndGetAsync(egitimTanimlaDTO, 1);
            egitim_Tanim_KonuDTO.Egitim_Tanimla_Id = resultObject.Data.Id;
            egitim_Tanim_KonuDTO.Egitim_Konu_Alt_Baslik_Id = id;
            var resultObject2 = await _egitim_Tanim_KonuService.AddAsync(egitim_Tanim_KonuDTO, 1);

            List<long> egitimTanim = new List<long>();

            foreach (var item in result.Data)
            {
                egitimTanim.Add(item.Egitim_Tanimla_Id);
            }

            List<long> egitimPersonelId = new List<long>();

            foreach (var item in egitimTanim)
            {
                var egitim = await _egitim_Personel_AtamaService.GetEgitimAsync(item);
                foreach (var item2 in egitim.Data)
                {
                    egitimPersonelId.Add(item2.Personel_Id);
                }
            }
            var personelListe = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
            List<long> personelListem = new List<long>();

            foreach (var item in personelListe)
            {
                personelListem.Add(item.Id);
            }

            var listePersonel= personelListem.Except(egitimPersonelId).ToList();
            egitim_Personel_AtamaDTO.Egitim_Tanimla_Id = resultObject.Data.Id;
            egitim_Personel_AtamaDTO.Id = 0;
            egitim_Personel_AtamaDTO.Sertifika_Basildi = true;
            egitim_Personel_AtamaDTO.Egitime_Katilim = 1;

            foreach (var item in listePersonel)
            {
                egitim_Personel_AtamaDTO.Personel_Id = item;
                await _egitim_Personel_AtamaService.AddAsync(egitim_Personel_AtamaDTO, 1);
            }
            return View();
        }


    }
}
