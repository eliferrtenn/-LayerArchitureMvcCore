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
    [Authorize(Roles = "SuperAdmin,Admin", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("AltBirim/")]
    public class Tali_BirimController : Controller
    {
        public int birim { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IBirimService _birimService;
        private readonly ITali_BirimService _tali_birimService;

        public Tali_BirimController(IBirimService birimService,ITali_BirimService taliBirimService)
        {
            _birimService = birimService;
            _tali_birimService = taliBirimService;
        }


        // GET: Tali_BirimController
        [Route("Liste")]
        public async Task<IActionResult> Index()
        {
            var result = await _tali_birimService.GetAllAsync(currentKurul);
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _birimService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.BirimList = result1.Data;
                return View(result.Data);
            }
            return View();
        }

        // GET: Tali_BirimController/Create
        [Route("Olustur")]
        public async Task<IActionResult> Create()
        {
            var result = await _tali_birimService.GetAllAsync(currentKurul);
            if (result.ResultStatus == ResultStatus.Success)
                ViewBag.talibirimList = result.Data;
            var result1 = await _birimService.GetAllAsync();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");
            return View();
        }

        // POST: Tali_BirimController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        public async Task<IActionResult> Create(Tali_BirimDTO taliBirim)
        {

            if (ModelState.IsValid)
            {
                taliBirim.Birim_Id = birim;
                taliBirim.Isveren_Id = 2;
                taliBirim.Alt_IsverenId = 1;
                var result = await _tali_birimService.AddAsync(taliBirim, 1);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = result.Message;
                    var result1 = await _birimService.GetAllAsync();
                    if (result1.ResultStatus == ResultStatus.Success)
                        ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");
                    return View();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Tali_BirimController/Edit/5
        [Route("Detaylar")]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _tali_birimService.GetAsync(id);
            ViewBag.BirimList = (await _birimService.GetAllAsync()).Data;
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
        // GET: Tali_BirimController/Edit/5
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _tali_birimService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _birimService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");
                return View(result.Data);
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("Index");
        }

        // POST: Tali_BirimController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id, Tali_BirimDTO taliBirim)
        {
            taliBirim.Isveren_Id = 2;
            taliBirim.Alt_IsverenId = 1;
            var result = await _tali_birimService.GetAsync(id);
            if (result != null)
            {
                var talibirimResult = await _tali_birimService.UpdateAsync(taliBirim, 2);

                if (talibirimResult.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = talibirimResult.Message;
                    return RedirectToAction("Index");
                }
            }
            else
            {
                var result1 = await _birimService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return View();
        }

        // GET: Tali_BirimController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Sil")]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _tali_birimService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }

        public async Task<JsonResult> GetTaliBirim(int id)
        {
            var result = await _tali_birimService.GetAllTaliBirim(id);
            if (result.ResultStatus == ResultStatus.Success)
                ViewBag.talibirimList = result.Data;
            return Json("0");
        }
    }
}
