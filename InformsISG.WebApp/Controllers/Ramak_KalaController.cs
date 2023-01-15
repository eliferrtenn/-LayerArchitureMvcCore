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
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InformsISG.WebApp.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,IsgUzman,IsYeriHekim,BirimSorumlusu", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("RamakKala/")]
    public class Ramak_KalaController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IRamak_KalaService _ramak_KalaService;
        private readonly IRamak_Kala_DosyaService _ramak_Kala_DosyaService;


        private readonly IPersonel_BilgiService _personel_BilgiService;
        private readonly IIsverenService _isverenService;
        private readonly IBirimService _birimService;
        private readonly ITali_BirimService _tali_BirimService;

        public Ramak_KalaController(IRamak_KalaService ramakKalaService,IPersonel_BilgiService personelBilgiService, IIsverenService isverenService, IBirimService birimService,ITali_BirimService taliBirimService,IRamak_Kala_DosyaService ramak_Kala_DosyaService)
        {
            _ramak_KalaService = ramakKalaService;
            _personel_BilgiService = personelBilgiService;
            _isverenService = isverenService;
            _birimService = birimService;
            _tali_BirimService = taliBirimService;
            _ramak_Kala_DosyaService = ramak_Kala_DosyaService;
        }
        // GET: Egitim_KonuController
        [Route("Liste")]
        public async Task<IActionResult> Index()
        {
            var result = await _ramak_KalaService.GetAllAsync();

            ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;


            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        [Route("Detaylar")]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _ramak_KalaService.GetAsync(id);


            ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
            ViewBag.BirimList = (await _birimService.GetAllAsync()).Data;
            ViewBag.TaliBirimList = (await _tali_BirimService.GetAllAsync(currentKurul)).Data;

            ViewBag.RamakKalaDosya = (await _ramak_Kala_DosyaService.GetAllRamakKalaAsync(id)).Data;
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

        // GET: Egitim_KonuController/Create
        [Route("Olustur")]
        public async Task<IActionResult> Create()
        {
            var result2 = await _tali_BirimService.GetAllAsync(currentKurul);
            ViewBag.Tali_Birim_Id = new SelectList(result2.Data, "Id", "Tali_Birim_Ad");

            var result3 = await _isverenService.GetAllAsync();
            ViewBag.Isveren_Id = new SelectList(result3.Data, "Id", "Isveren_Ad");

            var result4 = await _personel_BilgiService.GetAllAsync(currentKurul);
            if (result4.ResultStatus == ResultStatus.Success)
                ViewBag.Personel_Id = new SelectList(result4.Data, "Id", "Ad_Soyad");
            return View();
        }

        // POST: Kkd_TurController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        public async Task<IActionResult> Create(Ramak_KalaDTO ramak_KalaDTO)
        {

            ramak_KalaDTO.Isg_Kurul_Id = (await _birimService.GetAsync(currentKurul)).Data.Isg_Kurul_Id;
            ramak_KalaDTO.Birim_Id = currentKurul;
            var result2 = await _tali_BirimService.GetAllAsync(currentKurul);
            ViewBag.Tali_Birim_Id = new SelectList(result2.Data, "Id", "Tali_Birim_Ad");

            var result3 = await _isverenService.GetAllAsync();
            ViewBag.Isveren_Id = new SelectList(result3.Data, "Id", "Isveren_Ad");

            var result4 = await _personel_BilgiService.GetAllAsync(currentKurul);
            if (result4.ResultStatus == ResultStatus.Success)
                ViewBag.Personel_Id = new SelectList(result4.Data, "Id", "Ad_Soyad");
            if (ModelState.IsValid)
            {
                var result = await _ramak_KalaService.AddAsync(ramak_KalaDTO, 1);
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


        // GET: BirimController/Edit/5
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _ramak_KalaService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result2 = await _tali_BirimService.GetAllAsync(currentKurul);
                ViewBag.Tali_Birim_Id = new SelectList(result2.Data, "Id", "Tali_Birim_Ad");

                var result3 = await _isverenService.GetAllAsync();
                ViewBag.Isveren_Id = new SelectList(result3.Data, "Id", "Isveren_Ad");

                var result4 = await _personel_BilgiService.GetAllAsync(currentKurul);
                if (result4.ResultStatus == ResultStatus.Success)
                    ViewBag.Personel_Id = new SelectList(result4.Data, "Id", "Ad_Soyad");
                return View(result.Data);
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("Index");
        }

        // POST: BirimController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id, Ramak_KalaDTO ramak_KalaDTO)
        {
    
                var result2 = await _tali_BirimService.GetAllAsync(currentKurul);
                ViewBag.Tali_Birim_Id = new SelectList(result2.Data, "Id", "Tali_Birim_Ad");

                var result3 = await _isverenService.GetAllAsync();
                ViewBag.Isveren_Id = new SelectList(result3.Data, "Id", "Isveren_Ad");

                var result4 = await _personel_BilgiService.GetAllAsync(currentKurul);
                if (result4.ResultStatus == ResultStatus.Success)
                    ViewBag.Personel_Id = new SelectList(result4.Data, "Id", "Ad_Soyad");
                var result = await _ramak_KalaService.GetAsync(id);
            if (result != null)
            {
                ramak_KalaDTO.Birim_Id = result.Data.Birim_Id;
                ramak_KalaDTO.Isg_Kurul_Id = result.Data.Isg_Kurul_Id;
                var resultObject = await _ramak_KalaService.UpdateAsync(ramak_KalaDTO, 2);

                if (resultObject.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = resultObject.Message;
                    return RedirectToAction("Index");
                }
                else
                {

                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = resultObject.Message;
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


        // GET: BirimController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Sil")]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _ramak_KalaService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }


        [HttpGet]
        [Route("DosyaOlustur")]
        public ActionResult CreateDosya(int id)
        {
            TempData["Ramak_Kala_Id"] = id;
            ViewBag.Ramak_Kala_Id = id;
            return View();
        }

        [HttpPost]
        [Route("DosyaOlustur")]
        public async Task<IActionResult> CreateDosya(IEnumerable<IFormFile> file, Ramak_Kala_DosyaDTO ramak_Kala_DosyaDTO)
        {
            var filePaths = new List<string>();
            bool basarili = false;
            var ramakKalaId= (long)Convert.ToInt64(TempData["Ramak_Kala_Id"]);
            ramak_Kala_DosyaDTO.Ramak_Kala_Id = (long)Convert.ToInt64(TempData["Ramak_Kala_Id"]);
            ramak_Kala_DosyaDTO.Id = 0;

            TempData["Ramak_Kala_Id"] = TempData["Ramak_Kala_Id"];

            foreach (var item in file)
            {
                Guid guid = Guid.NewGuid();

                ramak_Kala_DosyaDTO.Dosya = item.FileName;

                var path = Path.GetExtension(ramak_Kala_DosyaDTO.Dosya);
                var type = guid.ToString() + path;

                // full path to file in temp location
                var filePath = "wwwroot/Dosya/RamakKala/" + type;

                filePaths.Add(filePath);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                }
                ramak_Kala_DosyaDTO.Dosya = "Dosya/RamakKala/" + type; ;
                ramak_Kala_DosyaDTO.Id = 0;
                ramak_Kala_DosyaDTO.Ramak_Kala_Id =ramakKalaId;

                var resultObject = await _ramak_Kala_DosyaService.AddAsync(ramak_Kala_DosyaDTO, 1);
                basarili = true;
            }
            if (basarili==true)
            {
                TempData["MessageIcon"] = "success";
                TempData["MessageText"] = "Ramak Kala Fotoğrafalr başarılı bir şekilde ekleenmiştir";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = "Ramak Kala fotoğraflar planı başarılı bir şekilde ekleenmiştir";
                return View();
            }

        }


    }
}
