using InformsISG.Core.Utilities.Results;
using InformsISG.Entities.Dtos;
using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InformsISG.WebApp.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,IsgUzman,IsYeriHekim,BirimSorumlusu", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("KazaDosya")]
    public class Kaza_DosyaController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IKaza_DosyaService _kazaDosyaService;

        public Kaza_DosyaController(IKaza_DosyaService kazaDosyaService)
        {
            _kazaDosyaService = kazaDosyaService;
        }

        // GET: Kaza_DosyaController
        [Route("Liste")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Kaza_DosyaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Kaza_DosyaController/Create
        [Route("DosyaEkle")]
        public ActionResult KazaDosyaEkle()
        {
            TempData["kazaId"] = TempData["kazaId"];
            return View();
        }

        [HttpPost]
        [Route("DosyaEKle")]
        public async Task<IActionResult> KazaDosyaEkle(IFormFile Dosya, Kaza_DosyaDTO kazaDosyaDTO)
        {
            Guid guid = Guid.NewGuid();

            var filePaths = new List<string>();

            if (Dosya.Length > 0)
            {
                kazaDosyaDTO.Dosya = Dosya.FileName;

                var path = Path.GetExtension(kazaDosyaDTO.Dosya);
                var type = guid.ToString() + path;
                // full path to file in temp location
                var filePath = "Dosya/Kaza/" + type;

                filePaths.Add(filePath);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Dosya.CopyToAsync(stream);
                }
                kazaDosyaDTO.Dosya = filePath;
                kazaDosyaDTO.Id = 0;
                kazaDosyaDTO.Isveren_Id = 2;
                kazaDosyaDTO.Kaza_Id = Convert.ToInt64(TempData["kazaId"]);
                var result = await _kazaDosyaService.AddAsync(kazaDosyaDTO, 1);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                    return RedirectToAction("Index","Kaza");
                }
                else
                {
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }

                return View();
            }
            return View();
        }
        // POST: Kaza_DosyaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: Kaza_DosyaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Kaza_DosyaController/Edit/5
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

        // GET: Kaza_DosyaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Kaza_DosyaController/Delete/5
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
