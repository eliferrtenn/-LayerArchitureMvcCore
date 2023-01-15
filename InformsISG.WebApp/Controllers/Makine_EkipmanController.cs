using InformsISG.Core.Utilities.Results;
using InformsISG.Entities.Dtos;
using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InformsISG.WebApp.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,IsgUzman,IsYeriHekim,BirimSorumlusu", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class Makine_EkipmanController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IMakine_EkipmanService _makine_EkipmanService;
        private readonly IMakine_Ekipman_Bakim_PlanlariService _makine_ekipman_bakim_PlanlariService;
        private readonly IMakine_Ekipman_Bakim_FotografService _makine_Ekipman_Bakim_FotografService;
        private readonly IBirimService _birimService;
        private readonly ITali_BirimService _tali_BirimService;
        private readonly IMakine_Ekipman_KontrolService _makine_Ekipman_KontrolService;
        private readonly IMakineService _makineService;


        private readonly IMakine_Kontrol_Kriter_BaslikService _makine_Kontrol_Kriter_BaslikService;
        private readonly IMakine_Kontrol_KriterService _makine_Kontrol_KriterService;
        private readonly IMakine_Bilgi_BaslikService _makine_Bilgi_BaslikService;
        private readonly IMakine_BilgilerService _makine_BilgilerService;
        private readonly IMakine_Olcum_Aleti_BilgilerService _makine_Olcum_Aleti_BilgilerService;
        private readonly IMakine_Test_DegerleriService _makine_Test_DegerleriService;

        private readonly IMakine_Ekipman_Kontrol_Kriter_BaslikService _makine_Ekipman_Kontrol_Kriter_BaslikService;
        private readonly IMakine_Ekipman_Kontrol_KriterService _makine_Ekipman_Kontrol_KriterService;
        private readonly IMakine_Ekipman_Bilgi_BaslikService _makine_Ekipman_Bilgi_BaslikService;
        private readonly IMakine_Ekipman_BilgilerService _makine_Ekipman_BilgilerService;
        private readonly IMakine_Ekipman_Olcum_Aleti_BilgilerService _makine_Ekipman_Olcum_Aleti_BilgilerService;
        private readonly IMakine_Ekipman_Test_DegerleriService _makine_Ekipman_Test_DegerleriService;



        public Makine_EkipmanController(IMakine_EkipmanService makine_EkipmanService,IMakine_Ekipman_Bakim_PlanlariService makine_Ekipman_Bakim_PlanlariService, IBirimService birimService,ITali_BirimService tali_BirimService,IMakine_Ekipman_Bakim_FotografService makine_Ekipman_Bakim_FotografService,
            IMakine_Ekipman_KontrolService makine_Ekipman_KontrolService,IMakineService makineService,

         IMakine_Kontrol_Kriter_BaslikService makine_Kontrol_Kriter_BaslikService,
         IMakine_Kontrol_KriterService makine_Kontrol_KriterService,
        IMakine_Bilgi_BaslikService makine_Bilgi_BaslikService,
            IMakine_BilgilerService makine_BilgilerService,
            IMakine_Olcum_Aleti_BilgilerService makine_Olcum_Aleti_BilgilerService, IMakine_Test_DegerleriService makine_Test_DegerleriService, 
          IMakine_Ekipman_Kontrol_Kriter_BaslikService makine_Ekipman_Kontrol_Kriter_BaslikService,
          IMakine_Ekipman_Kontrol_KriterService makine_Ekipman_Kontrol_KriterService,
          IMakine_Ekipman_Bilgi_BaslikService makine_Ekipman_Bilgi_BaslikService,
          IMakine_Ekipman_BilgilerService makine_Ekipman_BilgilerService,
          IMakine_Ekipman_Olcum_Aleti_BilgilerService makine_Ekipman_Olcum_Aleti_BilgilerService,
          IMakine_Ekipman_Test_DegerleriService makine_Ekipman_Test_DegerleriService
          )
        {
            _makine_EkipmanService = makine_EkipmanService;
            _makine_ekipman_bakim_PlanlariService = makine_Ekipman_Bakim_PlanlariService;
            _makine_Ekipman_Bakim_FotografService = makine_Ekipman_Bakim_FotografService;
            _birimService = birimService;
            _tali_BirimService = tali_BirimService;
            _makine_Ekipman_KontrolService = makine_Ekipman_KontrolService;
            _makineService = makineService;

            _makine_Kontrol_Kriter_BaslikService = makine_Kontrol_Kriter_BaslikService;
            _makine_Kontrol_KriterService = makine_Kontrol_KriterService;
            _makine_Bilgi_BaslikService = makine_Bilgi_BaslikService;
            _makine_BilgilerService = makine_BilgilerService;
            _makine_Olcum_Aleti_BilgilerService = makine_Olcum_Aleti_BilgilerService;
            _makine_Test_DegerleriService = makine_Test_DegerleriService;
            _makine_Ekipman_Kontrol_Kriter_BaslikService = makine_Ekipman_Kontrol_Kriter_BaslikService;
            _makine_Ekipman_Kontrol_KriterService = makine_Ekipman_Kontrol_KriterService;
            _makine_Ekipman_Bilgi_BaslikService = makine_Ekipman_Bilgi_BaslikService;
            _makine_Ekipman_BilgilerService = makine_Ekipman_BilgilerService;
            _makine_Ekipman_Olcum_Aleti_BilgilerService = makine_Ekipman_Olcum_Aleti_BilgilerService;
            _makine_Ekipman_Test_DegerleriService = makine_Ekipman_Test_DegerleriService;
        }

        // GET: Makine_EkipmanController
        public async Task<IActionResult> Index()
        {
            var result = await _makine_EkipmanService.GetAllAsync(currentKurul);
            ViewBag.Ekipman = (await _makine_EkipmanService.GetAllAsync(currentKurul)).Data.Count;
            ViewBag.TaliBirimList = (await _tali_BirimService.GetAllAsync(currentKurul)).Data;


            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _tali_BirimService.GetAllAsync(currentKurul);
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Tali_Birim_Id = new SelectList(result1.Data, "Id", "Tali_Birim_Ad");
                return View(result.Data);
            }
            return View();
        }

        // GET: Makine_EkipmanController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _makine_EkipmanService.GetAsync(id);
            var result1 = await _birimService.GetAllAsync();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");
            var result2 = await _tali_BirimService.GetAllAsync(currentKurul);
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Tali_Birim_Id = new SelectList(result2.Data, "Id", "Tali_Birim_Ad");

            ViewBag.Makine_EkipmanList = (await _makine_ekipman_bakim_PlanlariService.GetEkipman(id)).Data;

            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("Index");
        }

        // GET: Makine_EkipmanController/Create
        public async Task<IActionResult> Create()
        {

            var result1 = await _birimService.GetAllAsync();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");
            var result2 = await _tali_BirimService.GetAllAsync(currentKurul);
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Tali_Birim_Id = new SelectList(result2.Data, "Id", "Tali_Birim_Ad");

            var result3= await _makineService.GetAllAsync();
            if (result3.ResultStatus == ResultStatus.Success)
                ViewBag.Makine_Id = new SelectList(result3.Data, "Id", "Makine_Ad");
            return View();
        }

        // POST: Makine_EkipmanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Makine_EkipmanDTO  makine_EkipmanDTO,Makine_Ekipman_Bilgi_BaslikDTO makine_Ekipman_Bilgi_BaslikDTO,
            Makine_Ekipman_BilgilerDTO makine_Ekipman_BilgilerDTO,Makine_Ekipman_Kontrol_Kriter_BaslikDTO makine_Ekipman_Kontrol_Kriter_BaslikDTO, Makine_Ekipman_Kontrol_KriterDTO makine_Ekipman_Kontrol_KriterDTO, Makine_Ekipman_Olcum_Aleti_BilgilerDTO makine_Ekipman_Olcum_Aleti_BilgilerDTO, Makine_Ekipman_Test_DegerleriDTO makine_Ekipman_Test_DegerleriDTO)
        {
            var result1 = await _birimService.GetAllAsync();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");
            var result2 = await _tali_BirimService.GetAllAsync(currentKurul);
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Tali_Birim_Id = new SelectList(result2.Data, "Id", "Tali_Birim_Ad");

            var result3 = await _makineService.GetAllAsync();
            if (result3.ResultStatus == ResultStatus.Success)
                ViewBag.Makine_Id = new SelectList(result3.Data, "Id", "Makine_Ad");

                DateTime dateTime = DateTime.Now;
                makine_EkipmanDTO.Birim_Id = currentKurul;
                makine_EkipmanDTO.Id = 0;
                var result = await _makine_EkipmanService.AddAndGetAsync(makine_EkipmanDTO, 1);

                //Makinelerin kontrolleri eklenecek:Baslangic
                var makineId = makine_EkipmanDTO.Makine_Id;
                var makineEkipmanId = result.Data.Id;
                var resultEkipmanBilgiBaslik = (await _makine_Bilgi_BaslikService.GetAllMakineAsync(makineId)).Data;
                
                foreach(var item in resultEkipmanBilgiBaslik)
                {
                    makine_Ekipman_Bilgi_BaslikDTO.Id = 0;
                    makine_Ekipman_Bilgi_BaslikDTO.Madde_Ad = item.Madde_Ad;
                    makine_Ekipman_Bilgi_BaslikDTO.Makine_Ekipman_Id = makineEkipmanId;
                    var ekipmanBilgiBaslik = await _makine_Ekipman_Bilgi_BaslikService.AddAndGetAsync(makine_Ekipman_Bilgi_BaslikDTO,1);

                    var resultEkipmanBilgi = (await _makine_BilgilerService.GetAllMakineAsync(item.Id)).Data;
                    foreach(var item2 in resultEkipmanBilgi)
                    {
                        makine_Ekipman_BilgilerDTO.Id = 0;
                        makine_Ekipman_BilgilerDTO.Madde_Ad = item2.Madde_Ad;
                        makine_Ekipman_BilgilerDTO.Makine_Ekipman_Bilgi_Baslik_Id = ekipmanBilgiBaslik.Data.Id;
                        await _makine_Ekipman_BilgilerService.AddAsync(makine_Ekipman_BilgilerDTO, 1);
                    }

                }

                var resultEkipmanKontrolBaslik = (await _makine_Kontrol_Kriter_BaslikService.GetAllMakineAsync(makineId)).Data;

                foreach (var item in resultEkipmanKontrolBaslik)
                {
                    makine_Ekipman_Kontrol_Kriter_BaslikDTO.Id = 0;
                    makine_Ekipman_Kontrol_Kriter_BaslikDTO.Madde_Ad = item.Baslik_Ad;
                    makine_Ekipman_Kontrol_Kriter_BaslikDTO.Makine_Ekipman_Id = makineEkipmanId;
                    var ekipmanKontrolBaslik = await _makine_Ekipman_Kontrol_Kriter_BaslikService.AddAndGetAsync(makine_Ekipman_Kontrol_Kriter_BaslikDTO, 1);

                    var resultEkipmanKontrol = (await _makine_Kontrol_KriterService.GetAllMakineAsync(item.Id)).Data;
                    foreach (var item2 in resultEkipmanKontrol)
                    {
                        makine_Ekipman_Kontrol_KriterDTO.Id = 0;
                        makine_Ekipman_Kontrol_KriterDTO.Madde_Ad = item2.Madde_Ad;
                        makine_Ekipman_Kontrol_KriterDTO.Makine_Ekipman_Kontrol_Kriter_Baslik_Id = ekipmanKontrolBaslik.Data.Id;



                        await _makine_Ekipman_Kontrol_KriterService.AddAsync(makine_Ekipman_Kontrol_KriterDTO,1);
                    }

                }


                var resultEkipmanOlcumBilgiler = (await _makine_Olcum_Aleti_BilgilerService.GetAllMakineAsync(makineId)).Data;

                foreach (var item in resultEkipmanOlcumBilgiler)
                {
                    makine_Ekipman_Olcum_Aleti_BilgilerDTO.Id = 0;
                    makine_Ekipman_Olcum_Aleti_BilgilerDTO.Madde_Ad = item.Madde_Ad;
                    makine_Ekipman_Olcum_Aleti_BilgilerDTO.Makine_Ekipman_Id = makineEkipmanId;
                    await _makine_Ekipman_Olcum_Aleti_BilgilerService.AddAsync(makine_Ekipman_Olcum_Aleti_BilgilerDTO, 1);

                }

                var resultEkipmanTestBilgileri = (await _makine_Test_DegerleriService.GetAllMakineAsync(makineId)).Data;

                foreach (var item in resultEkipmanTestBilgileri)
                {
                    makine_Ekipman_Test_DegerleriDTO.Id = 0;
                    makine_Ekipman_Test_DegerleriDTO.Madde_Ad = item.Madde_Ad;
                    makine_Ekipman_Test_DegerleriDTO.Makine_Ekipman_Id = makineEkipmanId;
                    await _makine_Ekipman_Test_DegerleriService.AddAsync(makine_Ekipman_Test_DegerleriDTO, 1);

                }




                if (result.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = "Makine ekipman başarılı bir şekilde eklenmiştir";
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = result.Message;

                    return View();
                }
            
            return RedirectToAction("Index");

        }

        // GET: Makine_EkipmanController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _makine_EkipmanService.GetAsync(id);
            var result1 = await _birimService.GetAllAsync();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");
            var result2 = await _tali_BirimService.GetAllAsync(currentKurul);
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Tali_Birim_Id = new SelectList(result2.Data, "Id", "Tali_Birim_Ad");

            var result3 = await _makineService.GetAllAsync();
            if (result3.ResultStatus == ResultStatus.Success)
                ViewBag.Makine_Id = new SelectList(result3.Data, "Id", "Makine_Ad");
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("Index");
        }

        // POST: Makine_EkipmanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Makine_EkipmanDTO makineEkipmanDTO)
        {
            var result = await _makine_EkipmanService.GetAsync(id);
            var result1 = await _birimService.GetAllAsync();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");
            var result2 = await _tali_BirimService.GetAllAsync(currentKurul);
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Tali_Birim_Id = new SelectList(result2.Data, "Id", "Tali_Birim_Ad");

            var result3 = await _makineService.GetAllAsync();
            if (result3.ResultStatus == ResultStatus.Success)
                ViewBag.Makine_Id = new SelectList(result3.Data, "Id", "Makine_Ad");

  
            if (result != null)
            {
                var birimResult = await _makine_EkipmanService.UpdateAsync(makineEkipmanDTO, 2);

                if (birimResult.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = birimResult.Message;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = birimResult.Message;
                    return View();
                }
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return View();
        }

        // POST: Makine_EkipmanController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _makine_EkipmanService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }

        [HttpGet]
        public async Task<IActionResult> CreateBakim(int id)
        {
            ViewBag.Makine_EkipmanList = (await _makine_ekipman_bakim_PlanlariService.GetEkipman(id)).Data;
            TempData["Makine_Ekipman_Id"]=id;
            ViewBag.Makine_Ekipman = id;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateBakim(Makine_Ekipman_Bakim_PlanlariDTO makine_Ekipman_Bakim_PlanlariDTO, IEnumerable<IFormFile> file,Makine_Ekipman_Bakim_FotografDTO makine_Ekipman_Bakim_FotografDTO)
        {
            var filePaths = new List<string>();

            makine_Ekipman_Bakim_PlanlariDTO.Makine_Ekipman_Id = (long)Convert.ToInt64(TempData["Makine_Ekipman_Idd"]);
            makine_Ekipman_Bakim_PlanlariDTO.Id = 0;
            makine_Ekipman_Bakim_PlanlariDTO.OnayBirimSorumlu = 0;
            makine_Ekipman_Bakim_PlanlariDTO.OnayIsgUzman = 0;

            TempData["Makine_Ekipman_Id"] = TempData["Makine_Ekipman_Idd"];

                var result = await _makine_ekipman_bakim_PlanlariService.AddAndGetAsync(makine_Ekipman_Bakim_PlanlariDTO, 1);
                var eklenenMakineplanId = result.Data.Id;
                foreach(var item in file)
                {
                    Guid guid = Guid.NewGuid();

                    makine_Ekipman_Bakim_FotografDTO.Dosya = item.FileName;

                    var path = Path.GetExtension(makine_Ekipman_Bakim_FotografDTO.Dosya);
                    var type = guid.ToString() + path;

                    // full path to file in temp location
                    var filePath = "wwwroot/Dosya/BakimFotograf/" + type;

                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }
                    makine_Ekipman_Bakim_FotografDTO.Dosya = "Dosya/BakimFotograf/" + type; ;
                    makine_Ekipman_Bakim_FotografDTO.Id = 0;
                    makine_Ekipman_Bakim_FotografDTO.Makine_Ekipman_Bakim_Planlari_Id = eklenenMakineplanId;

                    var resultObjeect = await _makine_Ekipman_Bakim_FotografService.AddAsync(makine_Ekipman_Bakim_FotografDTO,1);
                }
                if (result.ResultStatus == ResultStatus.Success)
                {
                    ViewBag.Makine_EkipmanList = (await _makine_ekipman_bakim_PlanlariService.GetEkipman((int)TempData["Makine_Ekipman_Id"])).Data;
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = "Bakım planı başarılı bir şekilde ekleenmiştir";
                    return View();

                }
                else
                {
                    ViewBag.Makine_EkipmanList = (await _makine_ekipman_bakim_PlanlariService.GetEkipman((int)TempData["Makine_Ekipman_Id"])).Data;
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = result.Message;
                    return View();
                }
            
        }

        public async Task<IActionResult> EditBakim(int id)
        {
            var result = await _makine_ekipman_bakim_PlanlariService.GetAsync(id);
            ViewBag.Makine_EkipmanList = (await _makine_ekipman_bakim_PlanlariService.GetEkipman(result.Data.Makine_Ekipman_Id)).Data;
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditBakim(int id, Makine_Ekipman_Bakim_PlanlariDTO makine_Ekipman_Bakim_PlanlariDTO, IEnumerable<IFormFile> file, Makine_Ekipman_Bakim_FotografDTO makine_Ekipman_Bakim_FotografDTO)
        {
            var filePaths = new List<string>();

            makine_Ekipman_Bakim_PlanlariDTO.OnayIsgUzman = 0;
            var resultObject = await _makine_ekipman_bakim_PlanlariService.GetAsync(id);
            makine_Ekipman_Bakim_PlanlariDTO.Makine_Ekipman_Id = resultObject.Data.Makine_Ekipman_Id;
                
            ViewBag.Makine_EkipmanList = (await _makine_ekipman_bakim_PlanlariService.GetEkipman(resultObject.Data.Makine_Ekipman_Id)).Data;
            if (resultObject!=null)
            {
                var result = await _makine_ekipman_bakim_PlanlariService.UpdateAsync(makine_Ekipman_Bakim_PlanlariDTO, 1);
                foreach (var item in file)
                {
                    Guid guid = Guid.NewGuid();

                    makine_Ekipman_Bakim_FotografDTO.Dosya = item.FileName;

                    var path = Path.GetExtension(makine_Ekipman_Bakim_FotografDTO.Dosya);
                    var type = guid.ToString() + path;

                    // full path to file in temp location
                    var filePath = "wwwroot/Dosya/BakimFotograf/" + type;

                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }
                    makine_Ekipman_Bakim_FotografDTO.Dosya = "Dosya/BakimFotograf/" + type; ;
                    makine_Ekipman_Bakim_FotografDTO.Id = 0;
                    makine_Ekipman_Bakim_FotografDTO.Makine_Ekipman_Bakim_Planlari_Id =makine_Ekipman_Bakim_PlanlariDTO.Id;

                    var resultObjeect = await _makine_Ekipman_Bakim_FotografService.AddAsync(makine_Ekipman_Bakim_FotografDTO, 1);
                }
                if (result.ResultStatus == ResultStatus.Success)
                {

                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                    return RedirectToAction("CreateBakim",new { Id = resultObject.Data.Makine_Ekipman_Id});

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
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> DeleteBakim(int id)
        {
            var result = await _makine_ekipman_bakim_PlanlariService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }



        public async Task<IActionResult> DetailBakim(int id)
        {
            //  var deneme = TempData["Makine_Ekipman_Id"];
            var resultObject = (await _makine_ekipman_bakim_PlanlariService.GetAsync(id)).Data;
            ViewBag.MakineBakim = resultObject;
            ViewBag.MakineEkipmanKodu = (await _makine_EkipmanService.GetAsync(resultObject.Makine_Ekipman_Id)).Data.Ekipman_Kodu;
            var result = await _makine_Ekipman_Bakim_FotografService.GetFoto(id);
            return View(result.Data);
        }

        public async Task<IActionResult> QRUret(int id)
        {
            var result = await _makine_EkipmanService.GetAsync(id);
            var inputData = result.Data.Ekipman_Kodu;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
                QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(inputData, QRCodeGenerator.ECCLevel.Q);
                QRCode qRCode = new QRCode(qRCodeData);
                using (Bitmap bitmap = qRCode.GetGraphic(20))
                {
                    bitmap.Save(memoryStream, ImageFormat.Png);
                    var d = memoryStream.ToArray();
                    result.Data.QRCode = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
                }
                var resultObject = await _makine_EkipmanService.UpdateAsync(result.Data,1);
                if (resultObject.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = "QR Kod başarıyla oluşturulmuştur";
                    return RedirectToAction("QRGoruntule", "Makine_Ekipman", new { Id = result.Data.Id });


                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<Byte[]> ReadQRcodem(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
               
                return stream.ToArray();
            }
        }


        public async Task<IActionResult> QRGoruntule(int id)
        {
            var result = await _makine_EkipmanService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> OnayBekleyenBakim()
        {
            var result = await _makine_ekipman_bakim_PlanlariService.GetBeklemeAsync();
    
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // POST: Makine_EkipmanController/Edit/5

        public async Task<IActionResult> Onay(int id)
        {
            var result = await _makine_ekipman_bakim_PlanlariService.GetAsync(id);

            if (result != null)
            {
                result.Data.OnayBirimSorumlu = 1;
                var birimResult = await _makine_ekipman_bakim_PlanlariService.UpdateAsync(result.Data, 2);

                if (birimResult.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = birimResult.Message;
                    return RedirectToAction("OnayBekleyenBakim");
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = birimResult.Message;
                    return View();
                }
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return View();
        }
        public async Task<IActionResult> Reddet(int id)
        {
            var result = await _makine_ekipman_bakim_PlanlariService.GetAsync(id);

            if (result != null)
            {
                result.Data.OnayBirimSorumlu = 2;
                var birimResult = await _makine_ekipman_bakim_PlanlariService.UpdateAsync(result.Data, 2);

                if (birimResult.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = birimResult.Message;
                    return RedirectToAction("OnayBekleyenBakim");
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = birimResult.Message;
                    return View();
                }
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return View();
        }



        public async Task<IActionResult> DetailBakim2(int id)
        {
            //  var deneme = TempData["Makine_Ekipman_Id"];
            var resultObject = (await _makine_ekipman_bakim_PlanlariService.GetAsync(id)).Data;
            ViewBag.MakineBakim = resultObject;
            ViewBag.MakineEkipmanKodu = (await _makine_EkipmanService.GetAsync(resultObject.Makine_Ekipman_Id)).Data.Ekipman_Kodu;
            var result = await _makine_Ekipman_Bakim_FotografService.GetFoto(id);
            return View(result.Data);
        }

        public async Task<IActionResult> BakimPlanlari()
        {
            var result = await _makine_ekipman_bakim_PlanlariService.GetAllAsync();

            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> UploadQRCode()
        {
            return View();
        }



        public async Task<IActionResult> ReadQRcode(Makine_EkipmanDTO ekipmanDTO)
        {

            var result = await _makine_EkipmanService.ReadEkipmanKodAsync(ekipmanDTO.Ekipman_Kodu);

            TempData["Makine_Ekipman_Id"] =Convert.ToInt32(result.Data.Id);
            var resultObject = await _makine_ekipman_bakim_PlanlariService.GetEkipman(result.Data.Id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                if (resultObject.ResultStatus == ResultStatus.Success)
                {
                    return View(resultObject.Data);
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = resultObject.Message;
                }
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> KontrolListesi(int id)
        {
            var result = await _makine_EkipmanService.GetAsync(id);
            ViewBag.MakineEkipmanId = id;
            TempData["MakineEkipmanId"] = id;
            ViewBag.EkipmanBilgiBaslik = (await _makine_Ekipman_Bilgi_BaslikService.GetAllMakineEkipmanAsync(id)).Data; 
            
            ViewBag.EkipmanBilgi = (await _makine_Ekipman_BilgilerService.GetAllAsync()).Data;              
            ViewBag.EkipmanKontrolBaslik = (await _makine_Ekipman_Kontrol_Kriter_BaslikService.GetAllMakineEkipmanAsync(id)).Data;              
            ViewBag.EkipmanKontrol = (await _makine_Ekipman_Kontrol_KriterService.GetAllAsync()).Data;              
            ViewBag.EkipmanOlcum = (await _makine_Ekipman_Olcum_Aleti_BilgilerService.GetAllMakineEkipmanAsync(id)).Data;
            
            ViewBag.EkipmanTest = (await _makine_Ekipman_Test_DegerleriService.GetAllMakineEkipmanAsync(id)).Data;  
           
            if (result.ResultStatus == ResultStatus.Success)
            {

                return View(result.Data);
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> KontrolListesi(int[] BilgiId, string[] BilgiMadde, string[] BilgiMaddeKarsilik, int[] TestId, string[] TestMadde, string[] TestMaddeKarsilik,int[] OlcumId, string[] OlcumMadde, string[] OlcumMaddeKarsilik,int[] KontrolId, string[] KontrolMadde, bool[] KontrolUygun,int[] KontrolDegerlendirme, Makine_EkipmanDTO makine_EkipmanDTO,int Id)
        {
            var result = await _makine_EkipmanService.GetAsync(Id);


            if (result != null)
            {
                makine_EkipmanDTO.Birim_Id = result.Data.Birim_Id;
                makine_EkipmanDTO.Ekipman_Kodu = result.Data.Ekipman_Kodu;
                makine_EkipmanDTO.Firma_Adi = result.Data.Firma_Adi;
                makine_EkipmanDTO.Periyodik_Kontrol_Tarih = result.Data.Periyodik_Kontrol_Tarih;
                makine_EkipmanDTO.Tekrar_Periyodik_Kontrol_Tarih = result.Data.Tekrar_Periyodik_Kontrol_Tarih;   
                makine_EkipmanDTO.Periyodik_Kontrol_Adres = result.Data.Periyodik_Kontrol_Adres;
                makine_EkipmanDTO.Tekrar_Periyodik_Kontrol_Tarih = result.Data.Tekrar_Periyodik_Kontrol_Tarih;      
               makine_EkipmanDTO.Periyodik_Kontrol_Adres = result.Data.Periyodik_Kontrol_Adres;
               makine_EkipmanDTO.Telefon_No = result.Data.Telefon_No;
               makine_EkipmanDTO.E_Posta = result.Data.E_Posta;
               makine_EkipmanDTO.Takip_Kontrol_Tarih = result.Data.Takip_Kontrol_Tarih;
               makine_EkipmanDTO.Rapor_Tarih = result.Data.Rapor_Tarih;
               makine_EkipmanDTO.Periyodik_Kontrol_Method = result.Data.Periyodik_Kontrol_Method;
               makine_EkipmanDTO.Kimlik_Rapor_No = result.Data.Kimlik_Rapor_No;
               makine_EkipmanDTO.Kapsam = result.Data.Kapsam;
               makine_EkipmanDTO.QRCode = result.Data.QRCode;
               makine_EkipmanDTO.Tali_Birim_Id = result.Data.Tali_Birim_Id;
               makine_EkipmanDTO.Makine_Id = result.Data.Makine_Id;
 

                var birimResult = await _makine_EkipmanService.UpdateAsync(makine_EkipmanDTO, 2);

            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }

            int i = 0;
            foreach(var item in BilgiId)
            {
                var resultBilgi= await _makine_Ekipman_BilgilerService.GetAsync(item);
                resultBilgi.Data.Madde_Ad = BilgiMadde[i];
                resultBilgi.Data.Madde_Ad_Karsilik = BilgiMaddeKarsilik[i];
                var resultObject = await _makine_Ekipman_BilgilerService.UpdateAsync(resultBilgi.Data, 1);
                i++;
            }     
            
            int i2 = 0;
            foreach(var item in TestId)
            {
                var resultTest= await _makine_Ekipman_Test_DegerleriService.GetAsync(item);
                resultTest.Data.Madde_Ad = TestMadde[i2];
                resultTest.Data.Madde_Ad_Karsilik = TestMaddeKarsilik[i2];
                var resultObject = await _makine_Ekipman_Test_DegerleriService.UpdateAsync(resultTest.Data, 1);
                i2++;
            }  
            
            int i3 = 0;
            foreach(var item in OlcumId)
            {
                var resultOlcum= await _makine_Ekipman_Olcum_Aleti_BilgilerService.GetAsync(item);
                resultOlcum.Data.Madde_Ad = OlcumMadde[i3];
                resultOlcum.Data.Madde_Ad_Karsilik = OlcumMaddeKarsilik[i3];
                var resultObject = await _makine_Ekipman_Olcum_Aleti_BilgilerService.UpdateAsync(resultOlcum.Data, 1);
                i3++;
            }  
            
            int i4 = 0;
            foreach(var item in KontrolId)
            {
                var resultKontrol= await _makine_Ekipman_Kontrol_KriterService.GetAsync(item);
                resultKontrol.Data.Madde_Ad = KontrolMadde[i4];
                resultKontrol.Data.Uygun = KontrolUygun[i4];
                resultKontrol.Data.Degerlendirme = KontrolDegerlendirme[i4];
                var resultObject = await _makine_Ekipman_Kontrol_KriterService.UpdateAsync(resultKontrol.Data, 1);
                i4++;
            }
            if(i!=0 && i2!=0 && i3!=0 && i4 != 0)
            {
                TempData["MessageIcon"] = "success";
                TempData["MessageText"] = "Kontrol Kriterleri Başarıyla Güncellenmiştir";
            }



            long ID = Convert.ToInt64(TempData["MakineEkipmanId"]);
            return RedirectToAction("KontrolListesi", new { Id = ID });
        }


        public async Task<IActionResult> OnayBekleyenBakimIsgUzman()
        {
            var result = await _makine_ekipman_bakim_PlanlariService.GetBeklemeAsync();

            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // POST: Makine_EkipmanController/Edit/5

        public async Task<IActionResult> OnayIsgUzman(int id)
        {
            var result = await _makine_ekipman_bakim_PlanlariService.GetAsync(id);

            if (result != null)
            {
                result.Data.OnayIsgUzman = 1;
                var birimResult = await _makine_ekipman_bakim_PlanlariService.UpdateAsync(result.Data, 2);

                if (birimResult.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = birimResult.Message;
                    return RedirectToAction("OnayBekleyenBakimIsgUzman");
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = birimResult.Message;
                    return View();
                }
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return View();
        }
        public async Task<IActionResult> ReddetIsgUzman(int id)
        {
            var result = await _makine_ekipman_bakim_PlanlariService.GetAsync(id);

            if (result != null)
            {
                result.Data.OnayIsgUzman = 2;
                var birimResult = await _makine_ekipman_bakim_PlanlariService.UpdateAsync(result.Data, 2);

                if (birimResult.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = birimResult.Message;
                    return RedirectToAction("OnayBekleyenBakimIsgUzman");
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = birimResult.Message;
                    return View();
                }
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return View();
        }


        public async Task<IActionResult> DetailBakimIsgUzman(int id)
        {
            //  var deneme = TempData["Makine_Ekipman_Id"];
            var resultObject = (await _makine_ekipman_bakim_PlanlariService.GetAsync(id)).Data;
            ViewBag.MakineBakim = resultObject;
            ViewBag.MakineEkipmanKodu = (await _makine_EkipmanService.GetAsync(resultObject.Makine_Ekipman_Id)).Data.Ekipman_Kodu;
            var result = await _makine_Ekipman_Bakim_FotografService.GetFoto(id);
            return View(result.Data);
        }


        public async Task<IActionResult> RedBakimBirimSorumlusu()
        {
            var result = await _makine_ekipman_bakim_PlanlariService.GetAllTimeRedBirim();

            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // GET: Makine_EkipmanController/Edit/5

        public async Task<IActionResult> EditIsgUzman(int id)
        {
            var result = await _makine_ekipman_bakim_PlanlariService.GetAsync(id);

            ViewBag.MakineEkipmanId = Convert.ToInt32(result.Data.Makine_Ekipman_Id);

            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditIsgUzman(int id, Makine_Ekipman_Bakim_PlanlariDTO makine_Ekipman_Bakim_PlanlariDTO)
        {


            var resultObject = await _makine_ekipman_bakim_PlanlariService.GetAsync(id);
            ViewBag.MakineEkipmanId = Convert.ToInt32(resultObject.Data.Makine_Ekipman_Id);
            makine_Ekipman_Bakim_PlanlariDTO.OnayBirimSorumlu = 0;

            if (resultObject != null)
            {
                makine_Ekipman_Bakim_PlanlariDTO.OnayBirimSorumlu = 0;
                makine_Ekipman_Bakim_PlanlariDTO.Makine_Ekipman_Id = resultObject.Data.Makine_Ekipman_Id;
                makine_Ekipman_Bakim_PlanlariDTO.Id = resultObject.Data.Id;
                var result = await _makine_ekipman_bakim_PlanlariService.UpdateAsync(makine_Ekipman_Bakim_PlanlariDTO, 1);
   
                if (result.ResultStatus == ResultStatus.Success)
                {

                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                    return RedirectToAction("RedBakimBirimSorumlusu");

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



        public async Task<IActionResult> RedBakimIsgUzman()
        {
            var result = await _makine_ekipman_bakim_PlanlariService.GetAllTimeRedIsgUzman();

            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // GET: Makine_EkipmanController/Edit/5

        public async Task<IActionResult> EditBirimSorumlusu(int id)
        {
            var result = await _makine_ekipman_bakim_PlanlariService.GetAsync(id);

            ViewBag.MakineEkipmanId = Convert.ToInt32(result.Data.Makine_Ekipman_Id);

            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditBirimSorumlusu(int id, Makine_Ekipman_Bakim_PlanlariDTO makine_Ekipman_Bakim_PlanlariDTO)
        {
            var resultObject = await _makine_ekipman_bakim_PlanlariService.GetAsync(id);
            ViewBag.MakineEkipmanId = Convert.ToInt32(resultObject.Data.Makine_Ekipman_Id);

            if (resultObject != null)
            {
                makine_Ekipman_Bakim_PlanlariDTO.OnayIsgUzman = 0;
                makine_Ekipman_Bakim_PlanlariDTO.Makine_Ekipman_Id = resultObject.Data.Makine_Ekipman_Id;
                makine_Ekipman_Bakim_PlanlariDTO.Id = resultObject.Data.Id;
                var result = await _makine_ekipman_bakim_PlanlariService.UpdateAsync(makine_Ekipman_Bakim_PlanlariDTO, 1);

                if (result.ResultStatus == ResultStatus.Success)
                {

                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                    return RedirectToAction("RedBakimBirimSorumlusu");

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



        public async Task<IActionResult> TumOnayBekleyen()
        {
            var result = await _makine_ekipman_bakim_PlanlariService.GetBeklemeAsync();

            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        public async Task<IActionResult> TumDetailBakim(int id)
        {
            //  var deneme = TempData["Makine_Ekipman_Id"];
            var resultObject = (await _makine_ekipman_bakim_PlanlariService.GetAsync(id)).Data;
            ViewBag.MakineBakim = resultObject;
            ViewBag.MakineEkipmanKodu = (await _makine_EkipmanService.GetAsync(resultObject.Makine_Ekipman_Id)).Data.Ekipman_Kodu;
            var result = await _makine_Ekipman_Bakim_FotografService.GetFoto(id);
            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> DeleteKontrol(int id)
        {
            var result = await _makine_Ekipman_KontrolService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }
    }
}
