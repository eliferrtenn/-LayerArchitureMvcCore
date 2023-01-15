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
    [Authorize(Roles = "SuperAdmin,Admin,IsgUzman,IsYeriHekim,BirimSorumlusu", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("OrtamOlcum/")]
    public class Ortam_OlcumController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IOrtam_OlcumService _ortamOlcumService;
        private readonly IIsverenService _isverenService;
        private readonly ITali_BirimService _tali_BirimService;



        public Ortam_OlcumController(IOrtam_OlcumService ortamOlcumService,IIsverenService isverenService,ITali_BirimService taliBirimService)
        {
            _ortamOlcumService = ortamOlcumService;
            _isverenService = isverenService;
            _tali_BirimService = taliBirimService;
        }

        [HttpGet]
        [Route("Liste")]
        // GET: Ortam_OlcumController
        public async Task<IActionResult> Index()
        {
            ViewBag.OrtamOlcumleriIndex = (await _ortamOlcumService.GetAllAsync()).Data;
            ViewBag.OrtamOlcum = (await _ortamOlcumService.GetAllAsync()).Data.Count;

            var result1 = await _tali_BirimService.GetAllAsync(currentKurul);
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Tali_Birim_Id = new SelectList(result1.Data, "Id", "Tali_Birim_Ad");
            var result2 = await _isverenService.GetAllAsync();
            if (result2.ResultStatus == ResultStatus.Success)
                ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
            return View();
        }
     
        [HttpPost]
        [Route("Liste")]
        public async Task<IActionResult> Index(Ortam_OlcumDTO ortamOlcum)
        {
            ViewBag.OrtamOlcumleriIndex = (await _ortamOlcumService.GetAllAsync()).Data;

            if (ModelState.IsValid)
            {
                var result = await _ortamOlcumService.AddAsync(ortamOlcum, 1);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = result.Message;
                    var result1 = await _tali_BirimService.GetAllAsync(currentKurul);
                    if (result1.ResultStatus == ResultStatus.Success)
                        ViewBag.Tali_Birim_Id = new SelectList(result1.Data, "Id", "Tali_Birim_Ad");
                    var result2 = await _isverenService.GetAllAsync();
                    if (result2.ResultStatus == ResultStatus.Success)
                        ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
                    return View();
                }
            }
            return RedirectToAction("Index");
        }


        // GET: Ortam_OlcumController/Edit/5
        [Route("Detaylar")]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _ortamOlcumService.GetAsync(id);
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

        // GET: Ortam_OlcumController/Edit/5
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _ortamOlcumService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _tali_BirimService.GetAllAsync(currentKurul);
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Tali_Birim_Id = new SelectList(result1.Data, "Id", "Tali_Birim_Ad");
                var result2 = await _isverenService.GetAllAsync();
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
                return View(result.Data);
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("Index");
        }

        // POST: Ortam_OlcumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id, Ortam_OlcumDTO birim)
        {
            var result1 = await _tali_BirimService.GetAllAsync(currentKurul);
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Tali_Birim_Id = new SelectList(result1.Data, "Id", "Tali_Birim_Ad");
            var result2 = await _isverenService.GetAllAsync();
            if (result2.ResultStatus == ResultStatus.Success)
                ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
            var result = await _ortamOlcumService.GetAsync(id);
            if (result != null)
            {
                var birimResult = await _ortamOlcumService.UpdateAsync(birim, 2);

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

        // GET: Ortam_OlcumController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Sil")]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _ortamOlcumService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }
    }
}
