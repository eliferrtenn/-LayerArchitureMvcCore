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
    [Route("Kaza/")]
    public class KazaController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IKazaService _kazaService;
        private readonly IPersonel_BilgiService _personelBilgiService;
        private readonly IYaralanan_Vucut_BolgesiService _yaralanan_VucutBolgesiService;
        private readonly IYaralanma_SekliService _yaralanma_SekliService;

        private readonly IISg_KurulService _isgKurulService;
        private readonly IIsverenService _isverenService;
        private readonly ITali_BirimService _taliBirimService;
        private readonly IKaza_AyrintiService _kaza_AyrintiService;
        private readonly IKaza_DosyaService _kaza_DosyaService;
        private readonly IBirimService _birimService;


        public KazaController(IKazaService kazaService,IPersonel_BilgiService personelBilgiService,IISg_KurulService isgKurulService, IIsverenService isverenService,IYaralanan_Vucut_BolgesiService yaralananVucutBolgesiService,IYaralanma_SekliService yaralanmaSekliService,ITali_BirimService taliBirimService,IKaza_AyrintiService kazaAyrintiService,IKaza_DosyaService kazaDosyaService,IBirimService birimService)
        {
            _kazaService = kazaService;
            _personelBilgiService = personelBilgiService;
            _yaralanan_VucutBolgesiService = yaralananVucutBolgesiService;
            _yaralanma_SekliService = yaralanmaSekliService;

            _isgKurulService = isgKurulService;
            _isverenService = isverenService;
            _taliBirimService = taliBirimService;

            _kaza_AyrintiService = kazaAyrintiService;
            _kaza_DosyaService = kazaDosyaService;
            _birimService = birimService;
        }


        // GET: Kaza
        [Route("Liste")]
        public async Task<IActionResult> Index()
        {
            var result = await _kazaService.GetAllAsync();
            ViewBag.Kaza = (await _kazaService.GetAllAsync()).Data.Count;

            ViewBag.KazaDosya = (await _kaza_DosyaService.GetAllAsync()).Data;
            ViewBag.Count = (await _kaza_DosyaService.GetAllAsync()).Data.Count;
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // GET: Kaza/Edit/5
        [Route("Detaylar")]
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.KazaId = id;
            TempData["KazaId"] = id;
            ViewBag.KazaAyrintiList = (await _kaza_AyrintiService.GetAllAsync()).Data;
            ViewBag.KazaDosyaList = (await _kaza_DosyaService.GetAllAsync()).Data;


            var result = await _kazaService.GetAsync(id);

            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _personelBilgiService.GetAllAsync(currentKurul);
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Personel_Id = new SelectList(result1.Data, "Id", "Ad_Soyad");

                var result2 = await _yaralanan_VucutBolgesiService.GetAllAsync();
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Yaralanan_Vucut_Bolgesi_Id = new SelectList(result2.Data, "Id", "Yaralanan_Vucut_Bolgesi_Ad");

                var result3 = await _yaralanma_SekliService.GetAllAsync();
                if (result3.ResultStatus == ResultStatus.Success)
                    ViewBag.Yaralanma_Sekli_Id = new SelectList(result3.Data, "Id", "Yaralanma_Sekli_Ad");

                var result4 = await _isgKurulService.GetAllAsync();
                if (result4.ResultStatus == ResultStatus.Success)
                    ViewBag.Isg_Kurul_Id = new SelectList(result4.Data, "Id", "Kurul_Ad");

                var result5 = await _isverenService.GetAllAsync();
                if (result5.ResultStatus == ResultStatus.Success)
                    ViewBag.Isveren_Id = new SelectList(result5.Data, "Id", "Isveren_Ad");

                var result6 = await _taliBirimService.GetAllAsync(currentKurul);
                if (result6.ResultStatus == ResultStatus.Success)
                    ViewBag.Tali_Birim_Id = new SelectList(result6.Data, "Id", "Tali_Birim_Ad");
                return View(result.Data);
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("Index");
        }


        // GET: Kaza/Create
        [Route("Olustur")]
        public async Task<IActionResult> Create()
        {
            var result1 = await _personelBilgiService.GetAllAsync(currentKurul);
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Personel_Id = new SelectList(result1.Data, "Id", "Ad_Soyad");

            var result2 = await _yaralanan_VucutBolgesiService.GetAllAsync();
            if (result2.ResultStatus == ResultStatus.Success)
                ViewBag.Yaralanan_Vucut_Bolgesi_Id = new SelectList(result2.Data, "Id", "Yaralanan_Vucut_Bolgesi_Ad");

            var result3 = await _yaralanma_SekliService.GetAllAsync();
            if (result3.ResultStatus == ResultStatus.Success)
                ViewBag.Yaralanma_Sekli_Id = new SelectList(result3.Data, "Id", "Yaralanma_Sekli_Ad");

            var result4 = await _isgKurulService.GetAllAsync();
            if (result4.ResultStatus == ResultStatus.Success)
                ViewBag.Isg_Kurul_Id = new SelectList(result4.Data, "Id", "Kurul_Ad");

            var result5 = await _isverenService.GetAllAsync();
            if (result5.ResultStatus == ResultStatus.Success)
                ViewBag.Isveren_Id = new SelectList(result5.Data, "Id", "Isveren_Ad");

            var result6 = await _taliBirimService.GetAllAsync(currentKurul);
            if (result6.ResultStatus == ResultStatus.Success)
                ViewBag.Tali_Birim_Id = new SelectList(result6.Data, "Id", "Tali_Birim_Ad");

            return View();
        }

        // POST: Kaza/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        public async Task<IActionResult> Create(KazaDTO kaza)
        {
            if (ModelState.IsValid)
            {
                var resultObject = (await _birimService.GetAsync(currentKurul)).Data.Isg_Kurul_Id;

                kaza.Isg_Kurul_Id = resultObject;
                var result = await _kazaService.AddAndGetAsync(kaza, 1);
                var deneme = result.Data.Id;
                if (result.ResultStatus == ResultStatus.Success)
                {
                    TempData["kazaId"] = JsonConvert.SerializeObject(result.Data.Id);
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = result.Message;
                    var result1 = await _personelBilgiService.GetAllAsync(currentKurul);
                    if (result1.ResultStatus == ResultStatus.Success)
                        ViewBag.Personel_Id = new SelectList(result1.Data, "Id", "Ad_Soyad");

                    var result2 = await _yaralanan_VucutBolgesiService.GetAllAsync();
                    if (result2.ResultStatus == ResultStatus.Success)
                        ViewBag.Yaralanan_Vucut_Bolgesi_Id = new SelectList(result2.Data, "Id", "Yaralanan_Vucut_Bolgesi_Ad");

                    var result3 = await _yaralanma_SekliService.GetAllAsync();
                    if (result3.ResultStatus == ResultStatus.Success)
                        ViewBag.Yaralanma_Sekli_Id = new SelectList(result3.Data, "Id", "Yaralanma_Sekli_Ad");

                    var result4 = await _isgKurulService.GetAllAsync();
                    if (result4.ResultStatus == ResultStatus.Success)
                        ViewBag.Isg_Kurul_Id = new SelectList(result4.Data, "Id", "Kurul_Ad");

                    var result5 = await _isverenService.GetAllAsync();
                    if (result5.ResultStatus == ResultStatus.Success)
                        ViewBag.Isveren_Id = new SelectList(result5.Data, "Id", "Isveren_Ad");

                    var result6 = await _taliBirimService.GetAllAsync(currentKurul);
                    if (result6.ResultStatus == ResultStatus.Success)
                        ViewBag.Tali_Birim_Id = new SelectList(result6.Data, "Id", "Tali_Birim_Ad");
                    return View();
                }
            }
            return RedirectToAction("Create","Kaza_Ayrinti");
        }

        // GET: Kaza/Edit/5
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.KazaId = id;
            TempData["KazaId"] = id;
            ViewBag.KazaAyrintiList = (await _kaza_AyrintiService.GetAllAsync()).Data;
            ViewBag.KazaDosyaList = (await _kaza_DosyaService.GetAllAsync()).Data;


            var result = await _kazaService.GetAsync(id);
           
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _personelBilgiService.GetAllAsync(currentKurul);
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Personel_Id = new SelectList(result1.Data, "Id", "Ad_Soyad");

                var result2 = await _yaralanan_VucutBolgesiService.GetAllAsync();
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Yaralanan_Vucut_Bolgesi_Id = new SelectList(result2.Data, "Id", "Yaralanan_Vucut_Bolgesi_Ad");

                var result3 = await _yaralanma_SekliService.GetAllAsync();
                if (result3.ResultStatus == ResultStatus.Success)
                    ViewBag.Yaralanma_Sekli_Id = new SelectList(result3.Data, "Id", "Yaralanma_Sekli_Ad");

                var result4 = await _isgKurulService.GetAllAsync();
                if (result4.ResultStatus == ResultStatus.Success)
                    ViewBag.Isg_Kurul_Id = new SelectList(result4.Data, "Id", "Kurul_Ad");

                var result5 = await _isverenService.GetAllAsync();
                if (result5.ResultStatus == ResultStatus.Success)
                    ViewBag.Isveren_Id = new SelectList(result5.Data, "Id", "Isveren_Ad");

                var result6 = await _taliBirimService.GetAllAsync(currentKurul);
                if (result6.ResultStatus == ResultStatus.Success)
                    ViewBag.Tali_Birim_Id = new SelectList(result6.Data, "Id", "Tali_Birim_Ad");
                return View(result.Data);
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("Index");
        }


        // POST: Kaza/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id, KazaDTO kaza)
        {

            ViewBag.KazaId = id;
            TempData["KazaId"] = id;

            ViewBag.KazaAyrintiList = (await _kaza_AyrintiService.GetAllAsync()).Data;
            ViewBag.KazaDosyaList = (await _kaza_DosyaService.GetAllAsync()).Data;

            var result = await _kazaService.GetAsync(id);
            if (result != null)
            {
                kaza.Isg_Kurul_Id = result.Data.Isg_Kurul_Id;
                var birimResult = await _kazaService.UpdateAsync(kaza, 2);

                if (birimResult.ResultStatus == ResultStatus.Success)
                {
                    var result1 = await _personelBilgiService.GetAllAsync(currentKurul);
                    if (result1.ResultStatus == ResultStatus.Success)
                        ViewBag.Personel_Id = new SelectList(result1.Data, "Id", "Ad_Soyad");

                    var result2 = await _yaralanan_VucutBolgesiService.GetAllAsync();
                    if (result2.ResultStatus == ResultStatus.Success)
                        ViewBag.Yaralanan_Vucut_Bolgesi_Id = new SelectList(result2.Data, "Id", "Yaralanan_Vucut_Bolgesi_Ad");

                    var result3 = await _yaralanma_SekliService.GetAllAsync();
                    if (result3.ResultStatus == ResultStatus.Success)
                        ViewBag.Yaralanma_Sekli_Id = new SelectList(result3.Data, "Id", "Yaralanma_Sekli_Ad");

                    var result4 = await _isgKurulService.GetAllAsync();
                    if (result4.ResultStatus == ResultStatus.Success)
                        ViewBag.Isg_Kurul_Id = new SelectList(result4.Data, "Id", "Kurul_Ad");

                    var result5 = await _isverenService.GetAllAsync();
                    if (result5.ResultStatus == ResultStatus.Success)
                        ViewBag.Isveren_Id = new SelectList(result5.Data, "Id", "Isveren_Ad");

                    var result6 = await _taliBirimService.GetAllAsync(currentKurul);
                    if (result6.ResultStatus == ResultStatus.Success)
                        ViewBag.Tali_Birim_Id = new SelectList(result6.Data, "Id", "Tali_Birim_Ad");
                    var resultObject = await _kazaService.GetAsync(id);
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = birimResult.Message;
                    return View(resultObject.Data);
                }


            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return View();
        }
         
        // POST: Kaza/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Duzenle2")]
        public async Task<IActionResult> Edit2(int id, Kaza_AyrintiDTO kazaAyrinti)
        {
            ViewBag.KazaId = TempData["KazaId"];
            TempData["KazaId"] = TempData["KazaId"];

            ViewBag.KazaAyrintiList = (await _kaza_AyrintiService.GetAllAsync()).Data;
            ViewBag.KazaDosyaList = (await _kaza_DosyaService.GetAllAsync()).Data;

            var result = await _kaza_AyrintiService.GetKazaAsync(id);
            if (result != null)
            {
                kazaAyrinti.Id = result.Data.Id;
                kazaAyrinti.Kaza_Id = result.Data.Kaza_Id;
                var birimResult = await _kaza_AyrintiService.UpdateAsync(kazaAyrinti, 2);

                if (birimResult.ResultStatus == ResultStatus.Success)
                {
                    var result1 = await _personelBilgiService.GetAllAsync(currentKurul);
                    if (result1.ResultStatus == ResultStatus.Success)
                        ViewBag.Personel_Id = new SelectList(result1.Data, "Id", "Ad_Soyad");

                    var result2 = await _yaralanan_VucutBolgesiService.GetAllAsync();
                    if (result2.ResultStatus == ResultStatus.Success)
                        ViewBag.Yaralanan_Vucut_Bolgesi_Id = new SelectList(result2.Data, "Id", "Yaralanan_Vucut_Bolgesi_Ad");

                    var result3 = await _yaralanma_SekliService.GetAllAsync();
                    if (result3.ResultStatus == ResultStatus.Success)
                        ViewBag.Yaralanma_Sekli_Id = new SelectList(result3.Data, "Id", "Yaralanma_Sekli_Ad");

                    var result4 = await _isgKurulService.GetAllAsync();
                    if (result4.ResultStatus == ResultStatus.Success)
                        ViewBag.Isg_Kurul_Id = new SelectList(result4.Data, "Id", "Kurul_Ad");

                    var result5 = await _isverenService.GetAllAsync();
                    if (result5.ResultStatus == ResultStatus.Success)
                        ViewBag.Isveren_Id = new SelectList(result5.Data, "Id", "Isveren_Ad");

                    var result6 = await _taliBirimService.GetAllAsync(currentKurul);
                    if (result6.ResultStatus == ResultStatus.Success)
                        ViewBag.Tali_Birim_Id = new SelectList(result6.Data, "Id", "Tali_Birim_Ad");

                    var resultObject = await _kazaService.GetAsync(result.Data.Kaza_Id);
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = birimResult.Message;
                    return View(resultObject.Data);
                }  
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return View();
        }

        
        // POST: Kaza/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("KazaAyrintiDuzenle")]
        public ActionResult EditKazaAyrinti(int id, Kaza_AyrintiDTO kazaAyrinti)
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

        // GET: Kaza/Delete/
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Sil")]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _kazaService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }


        [HttpGet]
        [Route("DosyaIslem")]
        public async Task<IActionResult> KazaDosyaIslem(int id)
        {
            var result2 = await _kaza_DosyaService.GetAllAsync();
            var result3 = await _kaza_DosyaService.GetAsync(0);
            foreach (var item in result2.Data)
            {
                if (item.Kaza_Id == id)
                {
                    result3 = await _kaza_DosyaService.GetAsync(item.Id);
                }
            }
            TempData["kazaId"] = Convert.ToInt64(id);
            ViewBag.kazaId = id;
            if (result3.Data == null)
            {
                return View();
            }
            return View(result3.Data);
        }


        [HttpGet]
        [Route("DosyaEkle")]
        public async Task<IActionResult> KazaDosyaEkle(int id)
        {
            var result2 = await _kaza_DosyaService.GetAllAsync();
            var result3 = await _kaza_DosyaService.GetAsync(0);

            foreach (var item in result2.Data)
            {
                if (item.Kaza_Id == id)
                {
                    result3 = await _kaza_DosyaService.GetAsync(item.Id);
                }
            }
            ViewBag.kazaId = Convert.ToInt64(id);
            TempData["kazaId"] = id;
            if (result3.Data == null)
            {
                return View();
            }
            return View(result3.Data);
        }

        [HttpPost]
        [Route("DosyaEkle")]
        public async Task<IActionResult> KazaDosyaEkle(IFormFile Dosya, Kaza_DosyaDTO kazaDosya)
        {
            Guid guid = Guid.NewGuid();
            var filePaths = new List<string>();
            if (Dosya != null)
            {
                if (Dosya.Length > 0)
                {
                    kazaDosya.Dosya = Dosya.FileName;

                    var path = Path.GetExtension(kazaDosya.Dosya);
                    var type = guid.ToString() + path;
                    var filePath = "wwwroot/Dosya/Kaza/" + type;

                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Dosya.CopyToAsync(stream);
                    }
                    kazaDosya.Dosya = filePath;
                    kazaDosya.Id = 0;
                    kazaDosya.Kaza_Id = Convert.ToInt64(TempData["kazaId"]);
                    kazaDosya.Isveren_Id = 2;
                    var result = await _kaza_DosyaService.AddAsync(kazaDosya, 1);
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

            }
            else
            {
                kazaDosya.Id = 0;
                kazaDosya.Kaza_Id = Convert.ToInt64(TempData["kazaId"]);
                kazaDosya.Isveren_Id = 2;
                var result = await _kaza_DosyaService.AddAsync(kazaDosya, 1);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = result.Message;
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [Route("DosyaIndir")]
        public async Task<IActionResult> DownloadFileFromFileSystem(int id)
        {
            var file = await _kaza_DosyaService.GetAsync(id);
            if (file == null)
                return null;
            var memory = new MemoryStream();
            using (var stream = new FileStream(file.Data.Dosya, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "image/jpg", "Kaza" + file.Data.Dosya);
        }

        [Route("DosyaSil")]
        public async Task<IActionResult> DeleteFileFromFileSystem(int id)
        {
            var result = await _kaza_DosyaService.GetAsync(id);

            if (result != null)
            {
                var filePath = result.Data.Dosya;
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                var resultObject = await _kaza_DosyaService.HardDeleteAsync(id);

                if (resultObject.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = resultObject.Message;
                    RedirectToAction("Index");
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
        public async Task<IActionResult> DeleteFileFromFileSystem(IFormFile Dosya, Kaza_DosyaDTO kazaDosya)
        {
            Guid guid = Guid.NewGuid();

            var filePaths = new List<string>();
            if (Dosya.Length > 0)
            {
                kazaDosya.Dosya = Dosya.FileName;

                var path = Path.GetExtension(kazaDosya.Dosya);
                var type = guid.ToString() + path;
                // full path to file in temp location
                var filePath = "wwwroot/Dosya/Kaza/" + type;

                filePaths.Add(filePath);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Dosya.CopyToAsync(stream);
                }
                kazaDosya.Dosya = filePath;
                kazaDosya.Id = 0;
                kazaDosya.Kaza_Id = Convert.ToInt64(TempData["kazaId"]);
                kazaDosya.Isveren_Id = 2;
                var result = await _kaza_DosyaService.AddAsync(kazaDosya, 1);
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
