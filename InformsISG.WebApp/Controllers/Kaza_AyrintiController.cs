using InformsISG.Core.Utilities.Results;
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
    [Route("KazaAyrinti")]
    public class Kaza_AyrintiController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IKaza_AyrintiService _kaza_AyrintiService;

        public Kaza_AyrintiController(IKaza_AyrintiService kazaAyrintiService)
        {
            _kaza_AyrintiService = kazaAyrintiService;
        }

        // GET: Kaza_AyrintiController
        [Route("Liste")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Kaza_AyrintiController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Kaza_AyrintiController/Create
        [Route("Olustur")]
        public ActionResult Create()
        {
            TempData["kazaId"] = TempData["kazaId"];
            return View();
        }

        // POST: Kaza_AyrintiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        public async Task<IActionResult> Create(Kaza_AyrintiDTO kazaAyrinti)
        {
            kazaAyrinti.Kaza_Id = Convert.ToInt64(TempData["kazaId"]);
            if (ModelState.IsValid)
            {
                var result = await _kaza_AyrintiService.AddAsync(kazaAyrinti, 1);
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
            return RedirectToAction("Index","Kaza");
        }

        // GET: Kaza_AyrintiController/Edit/5
        [Route("Duzenle")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Kaza_AyrintiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Duzenle")]
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

        // GET: Kaza_AyrintiController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Kaza_AyrintiController/Delete/5
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
