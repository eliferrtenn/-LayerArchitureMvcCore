using FastReport;
using FastReport.Data;
using FastReport.Utils;
using InformsISG.Core.Utilities.Results;
using InformsISG.Entities.Concrete;
using InformsISG.Entities.Dtos;
using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
    [Route("KurulKarar/")]
    public class Isg_Kurul_KararController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IISg_Kurul_KararService _isgKurulKararService;
        private readonly IISg_KurulService _isgKurulService;
        private readonly IIsverenService _isverenService;
        private readonly IISg_Kurul_Karar_DosyaService _isgKurulKararDosyaService;
        private readonly IISg_Kurul_Karar_GundemService _isgKurulKararGundemService;
        private readonly IIsg_Kurul_Karar2Service _isgKurulKarar2Service;
        private readonly IBirimService _birimService;

        private readonly IISg_Kurul_ElemanService _isgKurulElemanService;
        private readonly IPersonel_BilgiService _personelBilgiService;
        private readonly ITali_BirimService _taliBirimService;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public Isg_Kurul_KararController(IISg_Kurul_KararService isg_kurul_kararService, IISg_KurulService isgKurulService, IIsverenService isverenService, IPersonel_BilgiService personelBilgiService, IISg_Kurul_Karar_DosyaService isgKurulKararDosyaService, IISg_Kurul_Karar_GundemService isgKurulKararGundemService,IBirimService birimService,IIsg_Kurul_Karar2Service isg_Kurul_Karar2Service,IISg_Kurul_ElemanService isgKurulElemanService,ITali_BirimService taliBirimService, IWebHostEnvironment webHostEnvironment)
        {
            _isgKurulKararService = isg_kurul_kararService;
            _isgKurulService = isgKurulService;
            _isverenService = isverenService;
            _personelBilgiService = personelBilgiService;
            _isgKurulKararDosyaService = isgKurulKararDosyaService;
            _isgKurulKararGundemService = isgKurulKararGundemService;
            _birimService = birimService;
            _isgKurulKarar2Service = isg_Kurul_Karar2Service;
            _isgKurulElemanService = isgKurulElemanService;
            _taliBirimService = taliBirimService;
            _webHostEnvironment = webHostEnvironment;
        }


        // GET: Isg_Kurul_KararController
        [Route("Liste")]
        public async Task<IActionResult> Index()
        {
            var result = await _isgKurulKararService.GetAllAsync();
            ViewBag.KurulKarar = (await _isgKurulKararService.GetAllAsync()).Data.Count;

            ViewBag.KurulDosya = (await _isgKurulKararDosyaService.GetAllAsync()).Data;
            ViewBag.Count = (await _isgKurulKararDosyaService.GetAllAsync()).Data.Count;
            ViewBag.PersonelList = (await _personelBilgiService.GetAllAsync(currentKurul)).Data;

            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _isgKurulService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");
                var result2 = await _isverenService.GetAllAsync();
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
                return View(result.Data);
            }
            return View();
        }

        // GET: Isg_Kurul_KararController/Create
        [Route("Olustur")]
        public async Task<IActionResult> Create()
        {
            ViewBag.PersonelList = (await _personelBilgiService.GetAllAsync(currentKurul)).Data;

            var result1 = await _isgKurulService.GetAllAsync();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");
            var result2 = await _isverenService.GetAllAsync();
            if (result2.ResultStatus == ResultStatus.Success)
                ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
            return View();
        }

        // POST: Isg_Kurul_KararController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        public async Task<IActionResult> Create(Isg_Kurul_KararDTO isg_Kurul_Karar)
        {
            {
                if (ModelState.IsValid)
                {
                    var resultObject = (await _birimService.GetAsync(currentKurul)).Data.Isg_Kurul_Id;
                    isg_Kurul_Karar.Isg_Kurul_Id = resultObject;
                    var result = await _isgKurulKararService.AddAsync(isg_Kurul_Karar, 1);
                    if (result.ResultStatus == ResultStatus.Success)
                    {
                        TempData["MessageIcon"] = "success";
                        TempData["MessageText"] = result.Message;
                    }
                    else
                    {
                        var result1 = await _isgKurulService.GetAllAsync();
                        if (result1.ResultStatus == ResultStatus.Success)
                            ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");
                        var result2 = await _isverenService.GetAllAsync();
                        if (result2.ResultStatus == ResultStatus.Success)
                            ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
                        TempData["MessageIcon"] = "error";
                        TempData["MessageText"] = result.Message;
                        return View();
                    }
                }
                return RedirectToAction("Index");
            }
        }


        // GET: Isg_Kurul_KararController/Edit/5
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _isgKurulKararService.GetAsync(id);

            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _isgKurulService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");
                var result2 = await _isverenService.GetAllAsync();
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
                return View(result.Data);
            }
            return View();
        }
       
        // GET: Isg_Kurul_KararController/Edit/5
        [Route("Detaylar")]
        public async Task<IActionResult> DetailsKarar(int id)
        {
            var result = await _isgKurulKararService.GetAsync(id);
            ViewBag.KurulGundemList = (await _isgKurulKararGundemService.GetAllAsync()).Data;
            TempData["IsgKararId"] = id;
            ViewBag.Isg_Karar_Id = id;
            ViewBag.KurulElemanList = (await _isgKurulElemanService.GetKurulKararAsync(id)).Data;
            ViewBag.PersonelList = (await _personelBilgiService.GetAllAsync(currentKurul)).Data;
            ViewBag.KurulToplantiListe = (await _isgKurulKarar2Service.GetKurulToplanti(id)).Data;
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _isgKurulService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");
                var result2 = await _isverenService.GetAllAsync();
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
                return View(result.Data);
            }
            return View();
        }

        // GET: Isg_Kurul_KararController/Edit/5
        public async Task<IActionResult> Details(long id)
        {
            var result = await _isgKurulKararService.GetAsync(id);
            ViewBag.KurulGundemList = (await _isgKurulKararGundemService.GetAllAsync()).Data;
            TempData["id"] = id;
            ViewBag.Isg_Karar_Id=id;
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _isgKurulService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");
                var result2 = await _isverenService.GetAllAsync();
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
                return View(result.Data);
            }
            return View();
        }

        // POST: Isg_Kurul_KararController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id, Isg_Kurul_KararDTO isg_Kurul_KararDTO)
        {
            var result = await _isgKurulKararService.GetAsync(id);
            if (result != null)
            {
                isg_Kurul_KararDTO.Isg_Kurul_Id = result.Data.Isg_Kurul_Id;
                var kurulResult = await _isgKurulKararService.UpdateAsync(isg_Kurul_KararDTO, 2);
                if (kurulResult.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = kurulResult.Message;
                    return RedirectToAction("Index");
                }
            }
            else
            {
                var result1 = await _isgKurulService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");
                var result2 = await _isverenService.GetAllAsync();
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return View();
        }

        // GET: Isg_Kurul_KararController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Sil")]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _isgKurulKararService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }

        [HttpPost]
        [Route("GundemMaddesiEklee")]
        public async Task<IActionResult> GundemMaddesiEkle2(Isg_Kurul_Karar_GundemDTO cust)
        {
            long ID= Convert.ToInt64(TempData["IsgKurulKararId"]);
            cust.Isg_Kurul_Karar_Id =Convert.ToInt64(TempData["IsgKurulKararId"]);
            var result = await _isgKurulKararGundemService.AddAsync(cust, 1);
            ViewBag.KurulGundemList_ = (await _isgKurulKararGundemService.GetAllAsync()).Data;

            if (result.ResultStatus == ResultStatus.Success)
            {
                TempData["MessageIcon"] = "success";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("GundemMaddesiEkle",new { Id=ID});
        }

        [HttpGet]
        public async Task<IActionResult> GundemMaddesiEkle(int id)
        {
            ViewBag.IsgKurulKararId_ = id;
            TempData["IsgKurulKararId"] = id; 
            ViewBag.KurulGundemList_ = (await _isgKurulKararGundemService.GetAllAsync()).Data;
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GundemMaddesiCikar(int id)
        {
            var result = await _isgKurulKararGundemService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }

        [HttpGet]
        [Route("KurulKarar")]
        public async Task<IActionResult> KurulKarar(int id)
        {
            ViewBag.IsgKurulKararId_ = id;
            TempData["IsgKurulKararId"] = id;
            ViewBag.KurulKararListe = (await _isgKurulKarar2Service.GetAllAsync()).Data;
            ViewBag.PersonelListe = (await _personelBilgiService.GetAllAsync(currentKurul)).Data;

            var result1 = await _personelBilgiService.GetAllAsync(currentKurul);
            ViewBag.Personel_Id = new SelectList(result1.Data, "Id", "Ad_Soyad");

            return View();
        }

        [HttpPost]
        [Route("KurulKararr")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> KurulKarar2(Isg_Kurul_Karar2DTO cust)
        {
            long ID = Convert.ToInt64(TempData["IsgKurulKararId"]);
            cust.Isg_Kurul_Karar_Id = Convert.ToInt64(TempData["IsgKurulKararId"]);
            cust.TamamlandiMi = false;
            var result = await _isgKurulKarar2Service.AddAsync(cust, 1);
            ViewBag.KurulKararListe = (await _isgKurulKarar2Service.GetAllAsync()).Data;

            if (result.ResultStatus == ResultStatus.Success)
            {
                TempData["MessageIcon"] = "success";
                TempData["MessageText"] = result.Message;
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("KurulKarar", new { Id = ID });

        }

        [HttpPost]
        public async Task<JsonResult> KurulKararCikar(int id)
        {
            var result = await _isgKurulKarar2Service.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }


        [HttpGet]
        [Route("DosyaIslem")]
        public async Task<IActionResult> KurulKararDosyaIslem(int id)
        {
            var result2 = await _isgKurulKararDosyaService.GetAllAsync();
            var result3 = await _isgKurulKararDosyaService.GetAsync(0);
            foreach (var item in result2.Data)
            {
                if (item.Isg_Kurul_Karar_Id == id)
                {
                    result3 = await _isgKurulKararDosyaService.GetAsync(item.Id);
                }
            }
            TempData["KararId"] = Convert.ToInt64(id);
            ViewBag.KararId = id;
            if (result3.Data == null)
            {
                return View();
            }
            return View(result3.Data);
        }


        [HttpGet]
        [Route("DosyaEkle")]
        public async Task<IActionResult> KurulKararDosyaEkle(int id)
        {
            var result2 = await _isgKurulKararDosyaService.GetAllAsync();
            var result3 = await _isgKurulKararDosyaService.GetAsync(0);

            foreach (var item in result2.Data)
            {
                if (item.Isg_Kurul_Karar_Id == id)
                {
                    result3 = await _isgKurulKararDosyaService.GetAsync(item.Id);
                }
            }
            ViewBag.KararId = Convert.ToInt64(id);
            TempData["KararId"] = id;
            if (result3.Data == null)
            {
                return View();
            }
            return View(result3.Data);
        }


        [HttpPost]
        [Route("DosyaEkle")]
        public async Task<IActionResult> KurulKararDosyaEkle(IFormFile Dosya, Isg_Kurul_Karar_DosyaDTO isgKurulKararDosyaDTO)
        {
            Guid guid = Guid.NewGuid();

            var filePaths = new List<string>();

            if (Dosya.Length > 0)
            {
                isgKurulKararDosyaDTO.Dosya = Dosya.FileName;

                var path = Path.GetExtension(isgKurulKararDosyaDTO.Dosya);
                var type = guid.ToString() + path;
                // full path to file in temp location
                var filePath = "wwwroot/Dosya/IsgKurulKarar/" + type;

                filePaths.Add(filePath);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Dosya.CopyToAsync(stream);
                }
                isgKurulKararDosyaDTO.Dosya = filePath;
                isgKurulKararDosyaDTO.Id = 0;
                isgKurulKararDosyaDTO.Isg_Kurul_Karar_Id = Convert.ToInt64(TempData["KararId"]);
                isgKurulKararDosyaDTO.Isveren_Id = 2;
                var result = await _isgKurulKararDosyaService.AddAsync(isgKurulKararDosyaDTO, 1);
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
            var file = await _isgKurulKararDosyaService.GetAsync(id);
            if (file == null)
                return null;
            var memory = new MemoryStream();
            using (var stream = new FileStream(file.Data.Dosya, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "image/jpg", "IsgKurulKarar" + file.Data.Dosya);
        }


        [Route("DosyaSil")]
        public async Task<IActionResult> DeleteFileFromFileSystem(int id)
        {
            var result = await _isgKurulKararDosyaService.GetAsync(id);
            ViewBag.KararId = TempData["KararId"];
            TempData["KararId"] = TempData["KararId"];
            if (result != null)
            {
                var filePath = result.Data.Dosya;
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                var resultObject = await _isgKurulKararDosyaService.HardDeleteAsync(id);

                if (resultObject.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = resultObject.Message;
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


        //KURULKARARELEMAN
        // GET: Egitim_Tanimla
        [Route("PersonelEkle")]
        public async Task<IActionResult> PersonelEkle(int id)
        {
            var result = await _isgKurulElemanService.GetAllAsync();
            ViewBag.PersonelList = (await _personelBilgiService.GetAllAsync(currentKurul)).Data;

            TempData["id"] = id;
            //var result5= await _egitim_Personel_AtamaService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                //ViewBag.deneme = result5.Data.Egitim_Tanimla_Id;
                ViewBag.IsgKurulKararId = id;

                var result4 = await _personelBilgiService.GetAllAsync(currentKurul);

                if (result4.ResultStatus == ResultStatus.Success)
                    ViewBag.Personel_Id = new SelectList(result4.Data, "Id", "Ad_Soyad");

                return View(result.Data);
            }
            return View();
        }

        // GET: Egitim_Tanimla
        [Route("PersonelListele")]
        public async Task<IActionResult> PersonelListe(Personel_BilgiDTO personel)
        {
            var result = await _isgKurulElemanService.GetAllAsync();
            ViewBag.PersonelList = (await _personelBilgiService.GetAllAsync(currentKurul)).Data;


            //var result5= await _egitim_Personel_AtamaService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                ViewBag.talibirimId = personel.Tali_Birim_Id;
                ViewBag.egitimTanimId = TempData["id"];

                var egitimTanimId = Convert.ToInt64(TempData["id"]);
                var personelAtama2 = (await _isgKurulElemanService.GetKurulKararAsync(egitimTanimId)).Data;
                var personelListe2 = (await _personelBilgiService.GetAllAsync(currentKurul)).Data;

                List<long> personelListe3 = new List<long>();

                foreach (var item in personelListe2)
                {
                    personelListe3.Add(item.Id);
                };
                List<long> personelAtama3 = new List<long>();

                foreach (var item in personelAtama2)
                {
                    personelAtama3.Add(item.Personel_Id);
                };
                ViewBag.liste = personelListe3.Except(personelAtama3).ToList();

                var talibirimResult = await _taliBirimService.GetAllAsync(currentKurul);

                if (talibirimResult.ResultStatus == ResultStatus.Success)
                {
                    ViewBag.Tali_Birim_Id = new SelectList(talibirimResult.Data.ToList(), "Id", "Tali_Birim_Ad");
                }
                return View(result.Data);
            }
            return View();
        }



        [Route("PersonelEkle2")]
        [HttpPost]
        public async Task<IActionResult> PersonelEkle2(Isg_Kurul_ElemanDTO isgeleman, long id, string[] names)
        {
            var result = await _isgKurulElemanService.GetAllAsync();

            if (result.ResultStatus == ResultStatus.Success)
            {
                ViewBag.egitimTanimId = TempData["id"];
                isgeleman.Id = 0;

                isgeleman.Isg_Kurul_Karar_Id = Convert.ToInt64(TempData["id"].ToString());
                for (int i = 0; i < names.Length; i++)
                {
                    isgeleman.Personel_Id = Convert.ToInt64(names[i]);
                    await _isgKurulElemanService.AddAsync(isgeleman, 1);

                }

                var result3 = await _isverenService.GetAllAsync();
                ViewBag.Isveren_Id = new SelectList(result3.Data, "Id", "Isveren_Ad");
                var talibirimResult = await _taliBirimService.GetAllAsync(currentKurul);

                result = await _isgKurulElemanService.GetAllAsync();
                if (talibirimResult.ResultStatus == ResultStatus.Success)
                {
                    ViewBag.Tali_Birim_Id = new SelectList(talibirimResult.Data.ToList(), "Id", "Tali_Birim_Ad");
                }
                ViewBag.PersonelList = (await _personelBilgiService.GetAllAsync(currentKurul)).Data;
                return View(result.Data);
            }
            return View();
        }

        [Route("Yazdir")]
        public async Task<FileResult> ReportGenerate(int id)
        {
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            String path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\Toplanti_Tutanagi.frx";
            var webReport = new Report();

            var mssqlDataConnection = new MsSqlDataConnection
            {
                ConnectionString = @"Server=.;Database=InformsISG2;User Id=sa;Password=MeskiInforms!.123;"
            };
            webReport.Dictionary.Connections.Add(mssqlDataConnection);
            RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
            webReport.Load(path);
            webReport.SetParameterValue("ID", id);

            if (webReport.Prepare())
            {
                FastReport.Export.PdfSimple.PDFSimpleExport pdfExport = new();
                pdfExport.ShowProgress = true;
                pdfExport.Subject = "TEST";
                pdfExport.Title = "Rapor BAŞLIĞI";
                MemoryStream ms = new();
                webReport.Export(pdfExport, ms);
                ms.Position = 0;
                pdfExport.Dispose();
                return File(ms, "application/pdf", "Report01.pdf");
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public async Task<IActionResult> KurulKararOnay(Isg_Kurul_Karar2DTO isg_kurul_karar, int id)
        {
            var result = await _isgKurulKarar2Service.GetAsync(id);
            result.Data.TamamlandiMi = true;
            isg_kurul_karar.Id = result.Data.Id;
            isg_kurul_karar.Isg_Kurul_Karar_Id = result.Data.Isg_Kurul_Karar_Id;
            isg_kurul_karar.Karar_No = result.Data.Karar_No;
            isg_kurul_karar.Alinan_Kararlar = result.Data.Alinan_Kararlar;
            isg_kurul_karar.Personel_Id = result.Data.Personel_Id;
            isg_kurul_karar.Baslangic_Tarih = result.Data.Baslangic_Tarih;
            isg_kurul_karar.Bitis_Tarih = result.Data.Bitis_Tarih;
            isg_kurul_karar.TamamlandiMi = true;
            var resultObj = await _isgKurulKarar2Service.UpdateAsync(isg_kurul_karar, 2);


            ViewBag.IsgKurulKararId_ = isg_kurul_karar.Isg_Kurul_Karar_Id;
            TempData["IsgKurulKararId"] = isg_kurul_karar.Isg_Kurul_Karar_Id;
            ViewBag.KurulKararListe = (await _isgKurulKarar2Service.GetAllAsync()).Data;
            ViewBag.PersonelListe = (await _personelBilgiService.GetAllAsync(currentKurul)).Data;

            var result1 = await _personelBilgiService.GetAllAsync(currentKurul);
            ViewBag.Personel_Id = new SelectList(result1.Data, "Id", "Ad_Soyad");
            if (resultObj.ResultStatus == ResultStatus.Success)
            {
                TempData["MessageIcon"] = "success";
                TempData["MessageText"] = resultObj.Message;
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = resultObj.Message;
            }

            return RedirectToAction("KurulKarar", "Isg_Kurul_Karar");
        }

        [Route("TamamlanmamisKurul")]
        public async Task<IActionResult> TamamlanmamisKurul()
        {
            var result = await _isgKurulKararService.GetAllAsync();
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _isgKurulService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");
                var result2 = await _isverenService.GetAllAsync();
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
                return View(result.Data);
            }
            return View();
        }




    }

}
