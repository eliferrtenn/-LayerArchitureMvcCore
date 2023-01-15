using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InformsISG.Core.Utilities.Results;
using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using InformsISG.Entities.Concrete;
using InformsISG.Entities.Dtos;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace InformsISG.WebApp.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,IsgUzman,IsYeriHekim,BirimSorumlusu", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("Personel/")]
    public class Personel_BilgiController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IPersonel_BilgiService _personel_BilgiService;
        private readonly ISgk_MeslekService _sgk_MeslekService;
        private readonly IBirimService _BirimService;
        private readonly ITali_BirimService _tali_BirimService;
        private readonly IIsverenService _IsverenService;
        private readonly IKullaniciService _kullaniciService;
        private readonly IMuayeneService _muayeneService;
        private readonly IEgitim_Personel_AtamaService _egitim_Personel_AtamaService;
        private readonly IEgitim_TanimlaService _egitim_TanimlaService;
        private readonly IEgitim_Konu_Alt_BaslikService _egitim_Konu_Alt_BaslikService;
        private readonly IEgitim_Veren_PersonelService _egitim_Veren_PersonelService;
        private readonly IEgitim_Tanim_KonuService _egitim_Tanim_KonuService;
        private readonly IKkdService _kkdService;
        private readonly IKkd_Personel_AtamaService _kkd_Personel_AtamaService;

        private readonly IKazaService _kazaService;
        private readonly IKaza_AyrintiService _kaza_AyrintiService;

        private readonly IWebHostEnvironment webHostEnvironment;

        public Personel_BilgiController(IPersonel_BilgiService personel_BilgiService, ISgk_MeslekService sgk_MeslekService,IBirimService birimService,ITali_BirimService tali_BirimService,IIsverenService isverenService, IKullaniciService kullaniciService,IMuayeneService muayeneService,IEgitim_Personel_AtamaService egitimPersonelAtamaService,IEgitim_TanimlaService egitimTanimlaService,IEgitim_Konu_Alt_BaslikService egitimKonuAltBaslikService,IEgitim_Veren_PersonelService egitimVerenPersonelService,IEgitim_Tanim_KonuService egitimTanimKonuService,IKazaService kazaService,IKaza_AyrintiService kazaAyrintiService,IWebHostEnvironment webHostEnvironment,IKkdService kkdService,IKkd_Personel_AtamaService kkdPersonelAtamaService)
        {
            _personel_BilgiService = personel_BilgiService;//dependecny injection
            _sgk_MeslekService = sgk_MeslekService;
            _BirimService = birimService;
            _tali_BirimService = tali_BirimService;
            _IsverenService = isverenService;
            _kullaniciService = kullaniciService;
            _muayeneService = muayeneService;
            _egitim_Personel_AtamaService = egitimPersonelAtamaService;
            _egitim_TanimlaService = egitimTanimlaService;
            _egitim_Konu_Alt_BaslikService = egitimKonuAltBaslikService;
            _egitim_Veren_PersonelService = egitimVerenPersonelService;
            _egitim_Tanim_KonuService = egitimTanimKonuService;
            _kazaService = kazaService;
            _kaza_AyrintiService = kazaAyrintiService;
            _kkdService = kkdService;
            _kkd_Personel_AtamaService = kkdPersonelAtamaService;

            this.webHostEnvironment = webHostEnvironment;

             //name = this.HttpContext.Request.Cookies["Name"];

            //currentKurul = this.User.FindFirst(ClaimTypes.GivenName).Value;
        }

        // GET: Personel_BilgiController
        [Route("Liste")]
        [Authorize(Roles = "SuperAdmin,Admin,IsgUzman,IsYeriHekim,BirimSorumlusu", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Index()
        {
            var result = await _personel_BilgiService.GetAllAsync(currentKurul);
            ViewBag.PersonelCount = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data.Count;             
            if (result.ResultStatus==ResultStatus.Success)
            {

                return View(result.Data);
            }
            return View();
        }


        [Route("Olustur")]
        [Authorize(Roles = "SuperAdmin", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Create()
        {
            var sgkMeslekResult = await _sgk_MeslekService.GetAllAsync();
            if (sgkMeslekResult.ResultStatus == ResultStatus.Success)
            {
                ViewBag.Sgk_Meslek_Id = new SelectList(sgkMeslekResult.Data.ToList(),"Id","Meslek_Ad");
            }
            var talibirimResult = await _tali_BirimService.GetAllAsync(currentKurul);
            if (talibirimResult.ResultStatus == ResultStatus.Success)
            {
                ViewBag.Tali_Birim_Id = new SelectList(talibirimResult.Data.ToList(), "Id", "Tali_Birim_Ad");
            }  
            return View();
        }

        // POST: Personel_BilgiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        [Authorize(Roles = "SuperAdmin", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Create(IFormFile Fotograf,Personel_BilgiDTO personelBilgi)
        {

            Guid guid = Guid.NewGuid();
            var filePaths = new List<string>();

            if (Fotograf != null)
            {
                if (Fotograf.Length > 0)
                {
                   
                    personelBilgi.Fotograf = Fotograf.FileName;
                    var path = Path.GetExtension(personelBilgi.Fotograf);
                    var type = guid.ToString() + path;
                    var filePath = "wwwroot/Dosya/Personel/" + type;

                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                      await Fotograf.CopyToAsync(stream);
                    }
                                     
                    personelBilgi.Fotograf = "Dosya/Personel/" + type;
                    personelBilgi.Id = 0;
                   
                    personelBilgi.Birim_Id = currentKurul;
                    var result = await _personel_BilgiService.AddAndGetAsync(personelBilgi, 1);
                    if (result.ResultStatus == ResultStatus.Success)
                    {
                        TempData["MessageIcon"] = "success";
                        TempData["MessageText"] = result.Message;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["MessageIcon"] = "error";
                        TempData["MessageText"] = result.Message;
                        var sgkMeslekResult = await _sgk_MeslekService.GetAllAsync();
                        if (sgkMeslekResult.ResultStatus == ResultStatus.Success)
                        {
                            ViewBag.Sgk_Meslek_Id = new SelectList(sgkMeslekResult.Data.ToList(), "Id", "Meslek_Ad");
                        }
                        var birimResult = await _BirimService.GetAllAsync();
                        if (birimResult.ResultStatus == ResultStatus.Success)
                        {
                            ViewBag.Birim_Id = new SelectList(birimResult.Data.ToList(), "Id", "Birim_Ad");
                        }
                        var talibirimResult = await _tali_BirimService.GetAllAsync(currentKurul);
                        if (talibirimResult.ResultStatus == ResultStatus.Success)
                        {
                            ViewBag.Tali_Birim_Id = new SelectList(talibirimResult.Data.ToList(), "Id", "Tali_Birim_Ad");
                        }
                        var isverenResult = await _IsverenService.GetAllAsync();
                        if (isverenResult.ResultStatus == ResultStatus.Success)
                        {
                            ViewBag.Isveren_Id = new SelectList(isverenResult.Data.ToList(), "Id", "Isveren_Ad");
                        }
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }

                        return View();
                    }
          
                
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = "Fotoğraf boyutunu kontrol edeip tekrar deneyiniz";
                    return RedirectToAction("Index");
                }         
            }
            else
            {
                personelBilgi.Birim_Id = currentKurul;
                var result = await _personel_BilgiService.AddAsync(personelBilgi, 1);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = "Personel Başarıyla eklenmiştir";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = result.Message;
                    var sgkMeslekResult = await _sgk_MeslekService.GetAllAsync();
                    if (sgkMeslekResult.ResultStatus == ResultStatus.Success)
                    {
                        ViewBag.Sgk_Meslek_Id = new SelectList(sgkMeslekResult.Data.ToList(), "Id", "Meslek_Ad");
                    }
                    var talibirimResult = await _tali_BirimService.GetAllAsync(currentKurul);
                    if (talibirimResult.ResultStatus == ResultStatus.Success)
                    {
                        ViewBag.Tali_Birim_Id = new SelectList(talibirimResult.Data.ToList(), "Id", "Tali_Birim_Ad");
                    }
                }

                    return View();
                }
        }

        // GET: Personel_BilgiController/Edit/5
        [Route("Duzenle")]
        [Authorize(Roles = "SuperAdmin", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _personel_BilgiService.GetAsync(id);
              if (result.ResultStatus == ResultStatus.Success)
                {
                var result1 = await _sgk_MeslekService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                  ViewBag.Sgk_Meslek_Id = new SelectList(result1.Data.ToList(), "Id", "Meslek_Ad");
                var result2 = await _tali_BirimService.GetAllAsync(currentKurul);
                if (result2.ResultStatus == ResultStatus.Success)
                 ViewBag.Tali_Birim_Id = new SelectList(result2.Data.ToList(), "Id", "Tali_Birim_Ad");
                return View(result.Data);
                }      
            return RedirectToAction("Index");
        }

        // POST: Personel_BilgiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Duzenle")]
        [Authorize(Roles = "SuperAdmin", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Edit(int id,IFormFile Fotograf, Personel_BilgiDTO personelBilgi)
        {
            Guid guid = Guid.NewGuid();
            var filePaths = new List<string>();
            var result = await _personel_BilgiService.GetAsync(id);
            personelBilgi.Birim_Id = currentKurul;

            if (Fotograf == null)
            {
                if(result.Data.Fotograf != null)
                {
                    personelBilgi.Fotograf = result.Data.Fotograf;
                }
            }
            else
            {
                var filePath = "wwwroot/"+result.Data.Fotograf;
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                personelBilgi.Fotograf = Fotograf.FileName;
                var path = Path.GetExtension(personelBilgi.Fotograf);
                var type = guid.ToString() + path;
                filePath = "wwwroot/Dosya/Personel/" + type;
                filePaths.Add(filePath);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Fotograf.CopyToAsync(stream);
                }
                personelBilgi.Fotograf = "Dosya/Personel/" + type;
            }
       
            if (result != null)
            {
                var birimResult = await _personel_BilgiService.UpdateAsync(personelBilgi, 2);
                if (birimResult.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = birimResult.Message;
                    return RedirectToAction("Index");
                };
            }
            else
            {
                var sgkMeslekResult = await _sgk_MeslekService.GetAllAsync();
                if (sgkMeslekResult.ResultStatus == ResultStatus.Success)
                {
                    ViewBag.Sgk_Meslek_Id = new SelectList(sgkMeslekResult.Data.ToList(), "Id", "Meslek_Ad");
                }
                var birimResult = await _BirimService.GetAllAsync();
                if (birimResult.ResultStatus == ResultStatus.Success)
                {
                    ViewBag.Birim_Id = new SelectList(birimResult.Data.ToList(), "Id", "Birim_Ad");
                }
                var talibirimResult = await _tali_BirimService.GetAllAsync(currentKurul);
                if (talibirimResult.ResultStatus == ResultStatus.Success)
                {
                    ViewBag.Tali_Birim_Id = new SelectList(talibirimResult.Data.ToList(), "Id", "Tali_Birim_Ad");
                }
                var isverenResult = await _IsverenService.GetAllAsync();
                if (isverenResult.ResultStatus == ResultStatus.Success)
                {
                    ViewBag.Isveren_Id = new SelectList(isverenResult.Data.ToList(), "Id", "Isveren_Ad");
                }
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return View();
        }


        // GET: Personel_BilgiController/Edit/5
        [Route("Detaylar")]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _personel_BilgiService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _sgk_MeslekService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Sgk_Meslek_Id = new SelectList(result1.Data.ToList(), "Id", "Meslek_Ad");
                var result2 = await _tali_BirimService.GetAllAsync(currentKurul);
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Tali_Birim_Id = new SelectList(result2.Data.ToList(), "Id", "Tali_Birim_Ad");
                return View(result.Data);
            }
            return RedirectToAction("Index");
        }

        // GET: Personel_BilgiController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Sil")]
        [Authorize(Roles = "SuperAdmin", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _personel_BilgiService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }

        // GET: Personel_BilgiController/Edit/5
        [Route("MuayeneDetaylar")]
        public async Task<IActionResult> DetailMuayene(int id)
        {
            ViewBag.Saglik = (await _muayeneService.GetAllChoosePersonelAsync(id)).Data;
            var result = await _personel_BilgiService.GetAsync(id);
            TempData["muayeneId"] = id;
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _sgk_MeslekService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Sgk_Meslek_Id = new SelectList(result1.Data.ToList(), "Id", "Meslek_Ad");
                var result2 = await _tali_BirimService.GetAllAsync(currentKurul);
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Tali_Birim_Id = new SelectList(result2.Data.ToList(), "Id", "Tali_Birim_Ad");
                return View(result.Data);
            }
            return RedirectToAction("Index");
        }

        // GET: Personel_BilgiController/Edit/5
        [Route("MuayeneDetaylar2")]
        public async Task<IActionResult> DetailMuayene2(int id)
        {
            ViewBag.MuayeneDetay = (await _muayeneService.GetAsync(id)).Data;
            var result = await _personel_BilgiService.GetAsync(Convert.ToInt64(TempData["muayeneId"]));


            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }


            return View();
        }

        // GET: Personel_BilgiController/Edit/5
        [Route("EgitimDetaylar")]
        public async Task<IActionResult> DetailEgitim(int id)
        {
            ViewBag.EgitimPersonelAtamaList = (await _egitim_Personel_AtamaService.GetPersonelAsync(id)).Data;
            ViewBag.EgitimTanimList = (await _egitim_TanimlaService.GetAllAsync()).Data;
            var result = await _personel_BilgiService.GetAsync(id);
            TempData["egitimTanimId"] = id;
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _sgk_MeslekService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Sgk_Meslek_Id = new SelectList(result1.Data.ToList(), "Id", "Meslek_Ad");
                var result2 = await _tali_BirimService.GetAllAsync(currentKurul);
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Tali_Birim_Id = new SelectList(result2.Data.ToList(), "Id", "Tali_Birim_Ad");
                return View(result.Data);
            }
            return RedirectToAction("Index");
        }
            
        // GET: Personel_BilgiController/Edit/5
        [Route("EgitimDetaylar2")]
        public async Task<IActionResult> DetailEgitim2(int id)
        {
            ViewBag.EgitimKonuAltBaslik = (await _egitim_Konu_Alt_BaslikService.GetAllAsync()).Data;
            //var result = await _egitim_TanimlaService.GetAsync(id);

            ViewBag.EgitimVerenList = (await _egitim_Veren_PersonelService.GetAllEgitimVeren(id)).Data;
            ViewBag.EgitimeGirecekListe = (await _egitim_Personel_AtamaService.GetPersonel(id)).Data;
            ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;

            ViewBag.Egitim = (await _egitim_TanimlaService.GetAsync(id)).Data;
            ViewBag.EgitimTanimKonu = (await _egitim_Tanim_KonuService.GetEgitimAsync(id)).Data;

            var result = await _personel_BilgiService.GetAsync(Convert.ToInt64(TempData["egitimTanimId"]));


            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }


            return View();
        }

        // GET: Personel_BilgiController/Edit/5
        [Route("KazaDetaylar")]
        public async Task<IActionResult> DetailKaza(int id)
        {
            var resultObject = await _kazaService.GetAsync(id);
            ViewBag.KazaList = (await _kazaService.GetAllKazaAsync(id)).Data;

            var result = await _personel_BilgiService.GetAsync(id);
            TempData["kazaId"] = id;
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _sgk_MeslekService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Sgk_Meslek_Id = new SelectList(result1.Data.ToList(), "Id", "Meslek_Ad");
                var result2 = await _tali_BirimService.GetAllAsync(currentKurul);
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Tali_Birim_Id = new SelectList(result2.Data.ToList(), "Id", "Tali_Birim_Ad");
                return View(result.Data);
            }
            return RedirectToAction("Index");
        }

        [Route("DetaylarKaza2")]
        public async Task<IActionResult> DetailKaza2(int id)
        {

            ViewBag.Kaza = (await _kazaService.GetAsync(id)).Data;
            ViewBag.KazaAyrinti = (await _kaza_AyrintiService.GetKazaAsync(id)).Data;
            var result = await _personel_BilgiService.GetAsync(Convert.ToInt64(TempData["kazaId"]));


            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }


            return View();
        }

        // GET: Personel_BilgiController/Edit/5
        [Route("DetaylarKkd")]
        public async Task<IActionResult> DetailKkd(int id)
        {
            ViewBag.KkdPersonelAtamaList = (await _kkd_Personel_AtamaService.GetAllPersonelAsync(id)).Data;
            ViewBag.KkdList = (await _kkdService.GetAllAsync()).Data;
            var result = await _personel_BilgiService.GetAsync(id);
            TempData["kkdId"] = id;
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _sgk_MeslekService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Sgk_Meslek_Id = new SelectList(result1.Data.ToList(), "Id", "Meslek_Ad");
                var result2 = await _tali_BirimService.GetAllAsync(currentKurul);
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Tali_Birim_Id = new SelectList(result2.Data.ToList(), "Id", "Tali_Birim_Ad");
                return View(result.Data);
            }
            return RedirectToAction("Index");
        }
        // GET: Personel_BilgiController/Edit/5
        [Route("DetaylarKkd2")]
        public async Task<IActionResult> DetailKkd2(int id)
        {

            ViewBag.Kkd = (await _kkdService.GetAsync(id)).Data;
            var result = await _personel_BilgiService.GetAsync(Convert.ToInt64(TempData["kkdId"]));


            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }


            return View();
        }

    }
}
