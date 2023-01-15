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
    [Route("Isveren/")]
    public class Alt_IsverenController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IAlt_IsverenService _altIsverenService;
        private readonly IISg_KurulService _isgKurulService;
        private readonly IBirimService _birimService;

        public Alt_IsverenController(IAlt_IsverenService alt_IsverenService,IISg_KurulService isg_KurulService,IBirimService birimService)
        {
            _altIsverenService = alt_IsverenService;
            _isgKurulService = isg_KurulService;
            _birimService = birimService;
        }

        [Route("Liste")]
        // GET: Alt_IsverenController
        public async Task<IActionResult> Index()
        {
            var result = await _altIsverenService.GetAllAsync();

            ViewBag.Isveren = (await _altIsverenService.GetAllAsync()).Data.Count;


            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _isgKurulService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");
                return View(result.Data);
            }
            return View();
        }

        [Route("Olustur")]
        // GET: Alt_IsverenController/Create
        public async Task<IActionResult> Create()
        {
            var result1 = await _isgKurulService.GetAllAsync();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");
            return View();
        }

        // POST: Alt_IsverenController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        public async Task<IActionResult> Create(Alt_IsverenDTO altIsveren)
        {
            var resultObject = (await _birimService.GetAsync(currentKurul)).Data.Isg_Kurul_Id;


            if (ModelState.IsValid)
            {
                DateTime dateTime = DateTime.Now;
                altIsveren.Isg_Kurul_Id = resultObject;
                var result = await _altIsverenService.AddAsync(altIsveren, 1);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = result.Message;
                    var result1 = await _isgKurulService.GetAllAsync();
                    if (result1.ResultStatus == ResultStatus.Success)
                        ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");
                    return View();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Alt_IsverenController/Edit/5
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _altIsverenService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _isgKurulService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");
                return View(result.Data);
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("Index");
        }

        // POST: Alt_IsverenController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id, Alt_IsverenDTO altIsverenDTO)
        {
            var result = await _altIsverenService.GetAsync(id);
            if (result != null)
            {
                altIsverenDTO.Isg_Kurul_Id = result.Data.Isg_Kurul_Id;
                var birimResult = await _altIsverenService.UpdateAsync(altIsverenDTO, 2);

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


        // GET: Alt_IsverenController/Edit/5
        [Route("Detaylar")]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _altIsverenService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _isgKurulService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");
                return View(result.Data);
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("Index");
        }

        // GET: Alt_IsverenController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Sil")]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _altIsverenService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);            
            return Json(ajaxResult);
        }
    }
}
