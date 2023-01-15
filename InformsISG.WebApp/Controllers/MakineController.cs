using InformsISG.Core.Utilities.Results;
using InformsISG.Entities.Dtos;
using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InformsISG.WebApp.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,IsgUzman,IsYeriHekim,BirimSorumlusu", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class MakineController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.User.Claims.First(x => x.Type == ClaimTypes.OtherPhone).Value); }
        private readonly IMakineService _makineService;
        private readonly IMakine_Kontrol_Kriter_BaslikService _makine_Kontrol_Kriter_BaslikService;
        private readonly IMakine_Kontrol_KriterService _makine_Kontrol_KriterService;


        public MakineController(IMakineService makineService,IMakine_Kontrol_Kriter_BaslikService makine_Kontrol_Kriter_BaslikService,IMakine_Kontrol_KriterService makine_Kontrol_KriterService)
        {
            _makineService = makineService;
            _makine_Kontrol_Kriter_BaslikService = makine_Kontrol_Kriter_BaslikService;
            _makine_Kontrol_KriterService = makine_Kontrol_KriterService;
        }

        [Route("Liste")]
        // GET: BirimController
        public async Task<IActionResult> Index()
        {
            var result = await _makineService.GetAllAsync();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }



        // GET: BirimController/Create
        [Route("Olustur")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: BirimController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        public async Task<IActionResult> Create(MakineDTO makine)
        {
            if (ModelState.IsValid)
            {
                var result = await _makineService.AddAsync(makine, 1);
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
            var result = await _makineService.GetAsync(id);
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

        // POST: BirimController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id, MakineDTO makine)
        {
            var result = await _makineService.GetAsync(id);

            if (result != null)
            {
                var birimResult = await _makineService.UpdateAsync(makine, 2);

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


        // GET: BirimController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Sil")]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _makineService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }


        [HttpPost]
        public async Task<JsonResult> KontrolKriterBaslikDelete(int id)
        {
            var result = await _makine_Kontrol_Kriter_BaslikService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }
        // GET: BirimController/Edit/5
        [Route("KontrolKriteri")]
        public async Task<IActionResult> KontrolKriteri(int id)
        {
            var result = await _makine_Kontrol_Kriter_BaslikService.GetAllMakineAsync(id);
            ViewBag.KontrolKriteri = (await _makine_Kontrol_KriterService.GetAllAsync()).Data;
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
     
        // GET: BirimController/Edit/5
        [Route("DuzenleKontrolKriteri")]
        public async Task<IActionResult> EditKontrolKriteri(int id)
        {
            ViewBag.KontrolKriteri = (await _makine_Kontrol_KriterService.GetAllMakineAsync(id)).Data;
            TempData["KontrolKriterBaslik"] = id;
            return View();
        }   
        // GET: BirimController/Edit/5
        [Route("DuzenleKontrolKriterii")]
        public async Task<IActionResult> EditKontrolKriteri2(Makine_Kontrol_KriterDTO makine_Kontrol_KriterDTO)
        {
            long ID = Convert.ToInt64(TempData["KontrolKriterBaslik"]);
            makine_Kontrol_KriterDTO.Makine_Kontrol_Kriter_Baslik_Id = Convert.ToInt64(TempData["KontrolKriterBaslik"]);
            var result = await _makine_Kontrol_KriterService.AddAsync(makine_Kontrol_KriterDTO, 1);

            ViewBag.KontrolKriteri = (await _makine_Kontrol_KriterService.GetAllMakineAsync(ID)).Data;


            if (result.ResultStatus == ResultStatus.Success)
            {
                TempData["MessageIcon"] = "success";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("EditKontrolKriteri", new { Id = ID });
        }


        [HttpPost]
        public async Task<JsonResult> KontrolKriterDelete(int id)
        {
            var result = await _makine_Kontrol_KriterService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }

        // GET: BirimController/Edit/5
        [Route("KontrolListesi")]
        public async Task<IActionResult> KontrolListesi(int id)
        {
            var result = await _makine_Kontrol_Kriter_BaslikService.GetAllMakineAsync(id);
            ViewBag.KontrolKriteri = (await _makine_Kontrol_KriterService.GetAllAsync()).Data;
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



    }
}
