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
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InformsISG.WebApp.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,IsgUzman,IsYeriHekim,BirimSorumlusu", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("PersonelDisiKaza/")]
    public class Kaza_Personel_DisiController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IKaza_Personel_DisiService _kaza_personelDisiService;
        private readonly IYaralanan_Vucut_BolgesiService _yaralanan_VucutBolgesiService;
        private readonly IYaralanma_SekliService _yaralanma_SekliService;
        private readonly IRisk_Analiz_RiskService _risk_Analiz_RiskService;
        private readonly IBirimService _birimService;

        private readonly IKaza_Personel_Disi_DosyaService _kaza_Personel_Disi_DosyaService;

        public Kaza_Personel_DisiController(IKaza_Personel_DisiService kazaPersonelDisiService,IYaralanan_Vucut_BolgesiService yaralananVucutBolgesiService, IYaralanma_SekliService yaralanmaSekliService,IRisk_Analiz_RiskService riskAnalizRiskService,IKaza_Personel_Disi_DosyaService kazaPersonelDisiDosyaService,IBirimService birimService)
        {
            _kaza_personelDisiService = kazaPersonelDisiService;
            _yaralanan_VucutBolgesiService = yaralananVucutBolgesiService;
            _yaralanma_SekliService = yaralanmaSekliService;
            _risk_Analiz_RiskService = riskAnalizRiskService;
            _kaza_Personel_Disi_DosyaService = kazaPersonelDisiDosyaService;
            _birimService = birimService;
        }

        // GET: KazaPersonelDisiController
        [Route("Liste")]
        public async Task<IActionResult> Index()
        {
            var result = await _kaza_personelDisiService.GetAllAsync();
            ViewBag.KazaPersonelDisi = (await _kaza_personelDisiService.GetAllAsync()).Data.Count;

            ViewBag.KazaPersonelDisiDosya = (await _kaza_Personel_Disi_DosyaService.GetAllAsync()).Data;
            ViewBag.Count = (await _kaza_Personel_Disi_DosyaService.GetAllAsync()).Data.Count;
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // GET: KazaPersonelDisiController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KazaPersonelDisiController/Create
        [Route("Olustur")]
        public async Task<IActionResult> Create()
        {

            var result = await _risk_Analiz_RiskService.GetAllAsync();
            if (result.ResultStatus == ResultStatus.Success)
                ViewBag.Risk_Analiz_Id = new SelectList(result.Data, "Id", "Risk");

            var result2 = await _yaralanan_VucutBolgesiService.GetAllAsync();
            if (result2.ResultStatus == ResultStatus.Success)
                ViewBag.Yaralanan_Vucut_Bolgesi_Id = new SelectList(result2.Data, "Id", "Yaralanan_Vucut_Bolgesi_Ad");

            var result3 = await _yaralanma_SekliService.GetAllAsync();
            if (result3.ResultStatus == ResultStatus.Success)
                ViewBag.Yaralanma_Sekli_Id = new SelectList(result3.Data, "Id", "Yaralanma_Sekli_Ad");
            return View();
        }

        // POST: KazaPersonelDisiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        public async Task<IActionResult> Create(Kaza_Personel_DisiDTO kazaPersonelDisi)
        {
            var resultObject = (await _birimService.GetAsync(currentKurul)).Data.Isg_Kurul_Id;

            kazaPersonelDisi.Isg_Kurul_Id = resultObject;
            kazaPersonelDisi.Isveren_Id = 4;
            if (ModelState.IsValid)
            {
                var result = await _kaza_personelDisiService.AddAsync(kazaPersonelDisi, 1);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                }
                else
                {
                    var result1 = await _risk_Analiz_RiskService.GetAllAsync();
                    if (result1.ResultStatus == ResultStatus.Success)
                        ViewBag.Risk_Analiz_Id = new SelectList(result1.Data, "Id", "Risk");
                    var result2 = await _yaralanan_VucutBolgesiService.GetAllAsync();
                    if (result2.ResultStatus == ResultStatus.Success)
                        ViewBag.Yaralanan_Vucut_Bolgesi_Id = new SelectList(result2.Data, "Id", "Yaralanan_Vucut_Bolgesi_Ad");
                    var result3 = await _yaralanma_SekliService.GetAllAsync();
                    if (result3.ResultStatus == ResultStatus.Success)
                        ViewBag.Yaralanma_Sekli_Id = new SelectList(result3.Data, "Id", "Yaralanma_Sekli_Ad");
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = result.Message;

                    return View();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: KazaPersonelDisiController/Edit/5
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _kaza_personelDisiService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _risk_Analiz_RiskService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Risk_Analiz_Id = new SelectList(result1.Data, "Id", "Risk");
                var result2 = await _yaralanan_VucutBolgesiService.GetAllAsync();
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Yaralanan_Vucut_Bolgesi_Id = new SelectList(result2.Data, "Id", "Yaralanan_Vucut_Bolgesi_Ad");
                var result3 = await _yaralanma_SekliService.GetAllAsync();
                if (result3.ResultStatus == ResultStatus.Success)
                    ViewBag.Yaralanma_Sekli_Id = new SelectList(result3.Data, "Id", "Yaralanma_Sekli_Ad");
                return View(result.Data);
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("Index");
        }

        // POST: KazaPersonelDisiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id,Kaza_Personel_DisiDTO kazaPersonelDisi)
        {

            var result = await _kaza_personelDisiService.GetAsync(id);
            if (result != null)
            {
                kazaPersonelDisi.Isg_Kurul_Id = result.Data.Isg_Kurul_Id;;
                var birimResult = await _kaza_personelDisiService.UpdateAsync(kazaPersonelDisi, 2);

                if (birimResult.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                    return RedirectToAction("Index");
                };
            }
            else
            {
                var result1 = await _risk_Analiz_RiskService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Risk_Analiz_Id = new SelectList(result1.Data, "Id", "Risk");
                var result2 = await _yaralanan_VucutBolgesiService.GetAllAsync();
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Yaralanan_Vucut_Bolgesi_Id = new SelectList(result2.Data, "Id", "Yaralanan_Vucut_Bolgesi_Ad");
                var result3 = await _yaralanma_SekliService.GetAllAsync();
                if (result3.ResultStatus == ResultStatus.Success)
                    ViewBag.Yaralanma_Sekli_Id = new SelectList(result3.Data, "Id", "Yaralanma_Sekli_Ad");
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return View();
        }

        // GET: KazaPersonelDisiController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Sil")]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _kaza_personelDisiService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }



        [HttpGet]
        [Route("DosyaIslem")]
        public async Task<IActionResult> KazaPersonelDisiDosyaIslem(int id)
        {
            var result2 = await _kaza_Personel_Disi_DosyaService.GetAllAsync();
            var result3 = await _kaza_Personel_Disi_DosyaService.GetAsync(0);
            foreach (var item in result2.Data)
            {
                if (item.Kaza_Personel_Disi_Id == id)
                {
                    result3 = await _kaza_Personel_Disi_DosyaService.GetAsync(item.Id);
                }
            }
            TempData["kazaPersonelDisiId"] = Convert.ToInt64(id);
            ViewBag.kazaPersonelDisiId = id;
            if (result3.Data == null)
            {
                return View();
            }
            return View(result3.Data);
        }


        [HttpGet]
        [Route("DosyaEkle")]
        public async Task<IActionResult> KazaPersonelDisiDosyaEkle(int id)
        {
            var result2 = await _kaza_Personel_Disi_DosyaService.GetAllAsync();
            var result3 = await _kaza_Personel_Disi_DosyaService.GetAsync(0);

            foreach (var item in result2.Data)
            {
                if (item.Kaza_Personel_Disi_Id == id)
                {
                    result3 = await _kaza_Personel_Disi_DosyaService.GetAsync(item.Id);
                }
            }
            ViewBag.kazaPersonelDisiId = Convert.ToInt64(id);
            TempData["kazaPersonelDisiId"] = id;
            if (result3.Data == null)
            {
                return View();
            }
            return View(result3.Data);
        }



        [HttpPost]
        [Route("DosyaEkle")]
        public async Task<IActionResult> KazaPersonelDisiDosyaEkle(IFormFile Dosya, Kaza_Personel_Disi_DosyaDTO kazaPersonelDisiDosya)
        {
            Guid guid = Guid.NewGuid();

            var filePaths = new List<string>();

            if (Dosya.Length > 0)
            {
                kazaPersonelDisiDosya.Dosya = Dosya.FileName;

                var path = Path.GetExtension(kazaPersonelDisiDosya.Dosya);
                var type = guid.ToString() + path;
                // full path to file in temp location
                var filePath = "wwwroot/Dosya/KazaPersonelDisi/" + type;

                filePaths.Add(filePath);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Dosya.CopyToAsync(stream);
                }
                kazaPersonelDisiDosya.Dosya = filePath;
                kazaPersonelDisiDosya.Id = 0;
                kazaPersonelDisiDosya.Kaza_Personel_Disi_Id = Convert.ToInt64(TempData["kazaPersonelDisiId"]);
                kazaPersonelDisiDosya.Isveren_Id = 2;
                var result = await _kaza_Personel_Disi_DosyaService.AddAsync(kazaPersonelDisiDosya, 1);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                    return RedirectToAction("Index");
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


        [Route("DosyaIndir")]
        public async Task<IActionResult> DownloadFileFromFileSystem(int id)
        {
            var file = await _kaza_Personel_Disi_DosyaService.GetAsync(id);
            if (file == null)
                return null;
            var memory = new MemoryStream();
            using (var stream = new FileStream(file.Data.Dosya, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "image/jpg", "KazaPersonelDisi" + file.Data.Dosya);
        }

        [Route("DosyaSil")]
        public async Task<IActionResult> DeleteFileFromFileSystem(int id)
        {
            var result = await _kaza_Personel_Disi_DosyaService.GetAsync(id);

            if (result != null)
            {
                var filePath = result.Data.Dosya;
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                var resultObject = await _kaza_Personel_Disi_DosyaService.HardDeleteAsync(id);

                if (resultObject.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = result.Message;
                }
            }
            return RedirectToAction("Index");
        }
      
        [HttpPost]
        [Route("DosyaSil")]
        public async Task<IActionResult> DeleteFileFromFileSystem(IFormFile Dosya, Kaza_Personel_Disi_DosyaDTO kazaPersonelDisiDosya)
        {
            Guid guid = Guid.NewGuid();

            var filePaths = new List<string>();

            if (Dosya.Length > 0)
            {
                kazaPersonelDisiDosya.Dosya = Dosya.FileName;

                var path = Path.GetExtension(kazaPersonelDisiDosya.Dosya);
                var type = guid.ToString() + path;
                // full path to file in temp location
                var filePath = "wwwroot/Dosya/KazaPersonelDisi/" + type;

                filePaths.Add(filePath);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Dosya.CopyToAsync(stream);
                }
                kazaPersonelDisiDosya.Dosya = filePath;
                kazaPersonelDisiDosya.Id = 0;
                kazaPersonelDisiDosya.Kaza_Personel_Disi_Id = Convert.ToInt64(TempData["kazaPersonelDisiId"]);
                kazaPersonelDisiDosya.Isveren_Id = 2;
                var result = await _kaza_Personel_Disi_DosyaService.AddAsync(kazaPersonelDisiDosya, 1);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                    return RedirectToAction("Index");
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


    }
}
