using InformsISG.Core.Utilities.Results;
using InformsISG.Entities.Dtos;
using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InformsISG.WebApp.Controllers
{
    [Authorize(Roles = "SuperAdmin,IsYeriHekim", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("Muayene/")]
    public class SaglikController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IMuayeneService _muayeneService;
        private readonly IPersonel_BilgiService _personel_BilgiService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ITali_BirimService _taliBirimService;


        public SaglikController(IMuayeneService muayeneService,IPersonel_BilgiService personelBilgiService, IWebHostEnvironment webHostEnvironment, ITali_BirimService taliBirimService)
        {
            _muayeneService = muayeneService;
            _personel_BilgiService = personelBilgiService;
            _webHostEnvironment = webHostEnvironment;
            _taliBirimService = taliBirimService;
        }


        // GET: SaglikController
        [Route("Liste")]
        public async Task<IActionResult> Index()
        {
            var result = await _muayeneService.GetAllAsync();
            ViewBag.Saglik = (await _muayeneService.GetAllAsync()).Data.Count;

            if (result.ResultStatus == ResultStatus.Success)
            {
                ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
                ViewBag.TaliBirimListe = (await _taliBirimService.GetAllAsync(currentKurul)).Data;

                return View(result.Data);
            }
            return View();
        }

        // GET: SaglikController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SaglikController/Create
        [Route("Olustur")]
        public ActionResult Create()
        {
            TempData["PersonelId"] = TempData["PersonelId"];

            ViewBag.PersonelId = TempData["PersonelId"];
            return View();
        }

        // POST: SaglikController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        public async Task<IActionResult> Create(MuayeneDTO muayene)
        {
               muayene.Personel_Id= Convert.ToInt64(TempData["PersonelId"].ToString());
               muayene.Isveren_Id = 2;
                var result = await _muayeneService.AddAsync(muayene, 1);
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
            
            return RedirectToAction("Index");
        }

        // GET: SaglikController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SaglikController/Edit/5
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

        // GET: SaglikController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SaglikController/Delete/5
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

        // GET: SaglikController
        [Route("PersonelListe")]
        public async Task<IActionResult> IndexPersonel()
        {
            var result = await _personel_BilgiService.GetAllAsync(currentKurul);

            if (result.ResultStatus == ResultStatus.Success)
            {
                ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
                ViewBag.TaliBirimListe = (await _taliBirimService.GetAllAsync(currentKurul)).Data;

                return View(result.Data);
            }
            return View();
        }

        // GET: SaglikController
        [Route("PersonelSec")]
        public async Task<IActionResult> ChoosePersonel(int id)
        {

            TempData["PersonelId"] = id;
            ViewBag.PersonelId = id;
            var result = await _muayeneService.GetAllAsync();

            if (result.ResultStatus == ResultStatus.Success)
            {
                ViewBag.PersonelList = (await _muayeneService.GetAllAsync()).Data;
                return View(result.Data);
            }
            return View();
        }

        // GET: SaglikController
        [Route("MuayeneDetay")]
        public async Task<IActionResult> MuayenePersonel(int id)
        {

            TempData["PersonelId"] = id;
            var result = await _muayeneService.GetAsync(id);
            ViewBag.PersonelId =Convert.ToInt32(result.Data.Personel_Id);

            if (result.ResultStatus == ResultStatus.Success)
            {
                ViewBag.PersonelList = (await _muayeneService.GetAllAsync()).Data;
                return View(result.Data);
            }
            return View();
        }


        [HttpPost]
        public async Task<JsonResult> EndeksHesaplama(int id)
        {
            var yenideger = id;
            var boy = id % 1000;
            double boy2 = boy / 100;
            var kutle = id/1000;

            var result = kutle/(boy2*boy2);

            return Json(result);
        }
    }
}
