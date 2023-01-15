using InformsISG.Core.Utilities.Results;
using InformsISG.Entities.Dtos;
using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.WebApp.Controllers
{
    [Authorize(Roles = "SuperAdmin", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class YetkiController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IYetkiService _yetkiService;
        private readonly IKullaniciService _kullaniciService;
        private readonly IPersonel_BilgiService _personel_BilgiService;
        private readonly IBirimService _birimService;
  

        public YetkiController(IYetkiService yetkiService,IKullaniciService kullaniciService,IPersonel_BilgiService personel_BilgiService,IBirimService birimService)
        {
            _yetkiService = yetkiService;
            _kullaniciService = kullaniciService;
            _personel_BilgiService = personel_BilgiService;
            _birimService = birimService;
        }

        // GET: YetkiController
        public async Task<IActionResult> Index()
        {
            var result = await _kullaniciService.GetAllAsync();
            ViewBag.PersonelCount = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data.Count;
            ViewBag.YetkiCount = (await _kullaniciService.GetAllAsync()).Data.Count;

            ViewBag.Yetki = (await _yetkiService.GetAllAsync()).Data;
            ViewBag.Personel = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
            ViewBag.birim = (await _birimService.GetAllAsync()).Data;
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();

        }
        // GET: YetkiController/Create
        public async Task<IActionResult> Create()
        {
            var result1 = await _yetkiService.GetNonSuperAdmin();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Yetki_Id = new SelectList(result1.Data, "Id", "Yetki_Ad");
            var result2 = await _personel_BilgiService.GetAllAsync(currentKurul);
            if (result2.ResultStatus == ResultStatus.Success)
                ViewBag.Personel_Id = new SelectList(result2.Data, "Id", "Ad_Soyad");

            String password="";
            Random random = new Random();

            for(int i = 0; i < 4; i++)
            {
                //password += (char)random.Next(33, 48);
                password += (char)random.Next(48, 58);
                password += (char)random.Next(97, 123);
                password += (char)random.Next(65, 91);
            }

          
            ViewBag.deneme = password;
            
            return View();
        }

        // POST: YetkiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KullaniciDTO kullanici)
        {
                kullanici.Birim_Id = currentKurul;
            if (ModelState.IsValid)
            {
                var result = await _kullaniciService.AddAsync(kullanici, 1);

                if (result.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                }
                else
                {
                    var result1 = await _yetkiService.GetNonSuperAdmin();
                    if (result1.ResultStatus == ResultStatus.Success)
                        ViewBag.Yetki_Id = new SelectList(result1.Data, "Id", "Yetki_Ad");
                    var result2 = await _personel_BilgiService.GetAllAsync(currentKurul);
                    if (result2.ResultStatus == ResultStatus.Success)
                        ViewBag.Personel_Id = new SelectList(result2.Data, "Id", "Ad_Soyad");
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = result.Message;
                    return View();
                }
            }

            
            return RedirectToAction("Index");
        }

        // GET: YetkiController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result1 = await _yetkiService.GetNonSuperAdmin();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Yetki_Id = new SelectList(result1.Data, "Id", "Yetki_Ad");
            var result2 = await _personel_BilgiService.GetAllAsync(currentKurul);
            if (result2.ResultStatus == ResultStatus.Success)
                ViewBag.Personel_Id = new SelectList(result2.Data, "Id", "Ad_Soyad");
            var result = await _kullaniciService.GetAsync(id);
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

        // GET: YetkiController/Edit/5
        public async Task<IActionResult> Details(int id)
        {

            ViewBag.Yetki = (await _yetkiService.GetAllAsync()).Data;
            ViewBag.Personel = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;

            var result1 = await _yetkiService.GetNonSuperAdmin();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Yetki_Id = new SelectList(result1.Data, "Id", "Yetki_Ad");
            var result2 = await _personel_BilgiService.GetAllAsync(currentKurul);
            if (result2.ResultStatus == ResultStatus.Success)
                ViewBag.Personel_Id = new SelectList(result2.Data, "Id", "Ad_Soyad");
            var result = await _kullaniciService.GetAsync(id);
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
        // POST: YetkiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, KullaniciDTO kullaniciDTO)
        {
            var result = await _kullaniciService.GetAsync(id);
            if (result != null)
            {
                kullaniciDTO.Birim_Id = result.Data.Birim_Id;
                var birimResult = await _kullaniciService.UpdateAsync(kullaniciDTO, 2);

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


        // POST: YetkiController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Delete(int id)
        {
            var resultObject = await _kullaniciService.GetAsync(id);

            var ajaxResult = JsonConvert.SerializeObject(resultObject);
            return Json(ajaxResult);
        }
    }
}
