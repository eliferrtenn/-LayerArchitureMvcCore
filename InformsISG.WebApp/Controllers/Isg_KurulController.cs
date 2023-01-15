using InformsISG.Core.Utilities.Results;
using InformsISG.Entities.Concrete;
using InformsISG.Entities.Dtos;
using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InformsISG.WebApp.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,IsgUzman,IsYeriHekim,BirimSorumlusu", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("Kurul")]
    public class Isg_KurulController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IISg_KurulService _isg_KurulService;

        public Isg_KurulController(IISg_KurulService isg_KurulService)
        {
            _isg_KurulService = isg_KurulService;
        }

        // GET: Isg_KurulController
        [Route("Liste")]
        public async Task<IActionResult> Index()
        {
            var result = await _isg_KurulService.GetAllAsync();
            ViewBag.Kurul = (await _isg_KurulService.GetAllAsync()).Data.Count;


            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // GET: Isg_KurulController/Create
        [Route("Olustur")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Isg_KurulController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        public async Task<IActionResult> Create(Isg_KurulDTO isg_kurul)
        {
            if (ModelState.IsValid)
            {
                var result = await _isg_KurulService.AddAsync(isg_kurul, 1);
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

        // GET: Isg_KurulController/Edit/5
        [Route("Duzenle")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _isg_KurulService.GetAsync(id);

            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // POST: Isg_KurulController/Edit/5
        [HttpPost]
        [Route("Duzenle")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Isg_KurulDTO isgKurulDTO)
        {
            var result = await _isg_KurulService.GetAsync(id);
            if (result != null)
            {  
                var isgKurulResult = await _isg_KurulService.UpdateAsync(isgKurulDTO, 2);

                if (isgKurulResult.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = isgKurulResult.Message;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = isgKurulResult.Message;
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


        // GET: Isg_KurulController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Isg_KurulController/Delete/5
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
