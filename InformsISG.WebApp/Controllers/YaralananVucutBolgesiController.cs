using InformsISG.Core.Utilities.Results;
using InformsISG.Entities.Concrete;
using InformsISG.Entities.Dtos;
using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InformsISG.WebApp.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,IsgUzman,IsYeriHekim,BirimSorumlusu", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("YaralananVucut/")]
    public class YaralananVucutBolgesiController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IYaralanan_Vucut_BolgesiService _yaralananVucutBolgesiService;
        private readonly IYaralanma_SekliService _yaralanmaSekliService;

        public YaralananVucutBolgesiController(IYaralanan_Vucut_BolgesiService yaralananVucutBolgesiService,IYaralanma_SekliService 
            yaralanmaSekliService)
        {
            _yaralananVucutBolgesiService = yaralananVucutBolgesiService;
            _yaralanmaSekliService = yaralanmaSekliService;
                
        }

        // GET: YaralananVucutBolgesiController
        public async Task<IActionResult> Index()
        {
            var result = await _yaralananVucutBolgesiService.GetAllAsync();

            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _yaralananVucutBolgesiService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Yaralanma_Sekli_Id = new SelectList(result1.Data, "Id", "Yaralanma_Sekli_Ad");
                return View(result.Data);
            }
            return View();
        }

        // GET: YaralananVucutBolgesiController/Create
        public async Task<IActionResult> Create()
        {
            var result1 = await _yaralananVucutBolgesiService.GetAllAsync();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Yaralanma_Sekli_Id = new SelectList(result1.Data, "Id", "Yaralanma_Sekli_Ad");
            return View();
        }

        // POST: YaralananVucutBolgesiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Yaralanan_Vucut_BolgesiDTO yaralananVucutBolgesi)
        {
            if (ModelState.IsValid)
            {
                var result = await _yaralananVucutBolgesiService.AddAsync(yaralananVucutBolgesi, 1);
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

        // GET: YaralananVucutBolgesiController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _yaralananVucutBolgesiService.GetAsync(id);

            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _yaralananVucutBolgesiService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Yaralanma_Sekli_Id = new SelectList(result1.Data, "Id", "Yaralanma_Sekli_Ad");
                return View(result.Data);
            }
            return View();
        }

        // POST: YaralananVucutBolgesiController/Edit/5
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

        // GET: YaralananVucutBolgesiController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: YaralananVucutBolgesiController/Delete/5
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
    }
}
