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
    [Route("Ozet/")]
    public class OzetController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IDofService _dofService;
        private readonly IDof_DosyaService _dof_DosyaService;
        private readonly IBirimService _birimService;
        private readonly ITali_BirimService _taliBirimService;
        private readonly IIsverenService _isverenService;

        private readonly IEgitim_TanimlaService _egitim_TanimlaService;
        private readonly IISg_KurulService _isgKurulService;
        private readonly IPersonel_BilgiService _personel_BilgiService;
        private readonly IIsg_Kurul_Karar2Service _isg_Kurul_Karar2Service;
        private readonly IMakine_Ekipman_Bakim_PlanlariService _makine_Ekipman_Bakim_PlanlariService;





        public OzetController(IDofService dofService, IBirimService birimServcie, ITali_BirimService taliBirimService, IISg_KurulService isgKurulService, IIsverenService isverenService, IDof_DosyaService dofDosyaService, IEgitim_TanimlaService egitimTanimlaService,IPersonel_BilgiService personelBilgiService,IIsg_Kurul_Karar2Service isg_Kurul_Karar2Service,IMakine_Ekipman_Bakim_PlanlariService makineEkipmanBakimPlanlariService)
        {
            _dofService = dofService;
            _dof_DosyaService = dofDosyaService;
            _birimService = birimServcie;
            _taliBirimService = taliBirimService;
            _isverenService = isverenService;

            _egitim_TanimlaService = egitimTanimlaService;
            _personel_BilgiService = personelBilgiService;
            _isgKurulService = isgKurulService;
            _isg_Kurul_Karar2Service = isg_Kurul_Karar2Service;
            _makine_Ekipman_Bakim_PlanlariService = makineEkipmanBakimPlanlariService;
        }


        // GET: DofController
        [Route("YaklasanEgitimler")]
        public async Task<IActionResult> YaklasanEgitimler()
        {
            var result = (await _egitim_TanimlaService.GetAllAsync());

            ViewBag.Dof = (await _dofService.GetAllAsync(currentKurul)).Data.Count;
            ViewBag.IsgKurulListe = (await _isgKurulService.GetAllAsync()).Data;

            ViewBag.TaliBirimListe = (await _taliBirimService.GetAllAsync(currentKurul)).Data;
            ViewBag.BirimListe = (await _birimService.GetAllAsync()).Data;
            if (result.ResultStatus == ResultStatus.Success)
            {
                var resultObject = result.Data.OrderByDescending(x => x.Egitim_Tarih).Where(x=>x.Egitim_Tarih>DateTime.Now);
                return View(resultObject);
            }
            return View();
        }
        
        // GET: DofController
        [Route("YerDegisenPersonel")]
        public async Task<IActionResult> YeriDegisenPersoneller()
        {
            var result = (await _personel_BilgiService.GetAllAsync(currentKurul));


            if (result.ResultStatus == ResultStatus.Success)
            {

                return View(result.Data);
            }
            return View();
        }   

        // GET: DofController
        [Route("YaklasanKurulToplanti")]
        public async Task<IActionResult> YaklasanKurulToplanti()
        {
            var result = (await _isg_Kurul_Karar2Service.GetAllAsync());
            ViewBag.PersonelListe = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;

            if (result.ResultStatus == ResultStatus.Success)
            {

                return View(result.Data);
            }
            return View();
        }

        // GET: DofController
        [Route("YaklasanBakimPlani")]
        public async Task<IActionResult> YaklasanBakimPlanlari()
        {
            var result = (await _makine_Ekipman_Bakim_PlanlariService.GetAllAsync());
            ViewBag.PersonelListe = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;

            if (result.ResultStatus == ResultStatus.Success)
            {

                return View(result.Data);
            }
            return View();
        }

        // GET: DofController
        [Route("Liste")]
        public async Task<IActionResult> Index()
        {
            var result = await _dofService.GetAllAsync(currentKurul);

            ViewBag.Dof = (await _dofService.GetAllAsync(currentKurul)).Data.Count;

            ViewBag.TaliBirimListe = (await _taliBirimService.GetAllAsync(currentKurul)).Data;
            ViewBag.BirimListe = (await _birimService.GetAllAsync()).Data;


            ViewBag.CountBirim = (await _birimService.GetAllAsync()).Data.Count;
            ViewBag.CountTaliBirim = (await _taliBirimService.GetAllAsync(currentKurul)).Data.Count;
            ViewBag.CountDosya = (await _dof_DosyaService.GetAllAsync()).Data.Count;


            ViewBag.DofDosya = (await _dof_DosyaService.GetAllAsync()).Data;
            ViewBag.Count = (await _dof_DosyaService.GetAllAsync()).Data.Count;
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _birimService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");

                var result2 = await _taliBirimService.GetAllAsync(currentKurul);
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Tali_Birim_Id = new SelectList(result2.Data, "Id", "Tali_Birim_Ad");
                return View(result.Data);
            }
            return View();
        }

        // GET: DofController/Create
        [Route("Olustur")]
        public async Task<IActionResult> Create()
        {
            var result1 = await _birimService.GetAllAsync();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");

            var result2 = await _taliBirimService.GetAllAsync(currentKurul);
            if (result2.ResultStatus == ResultStatus.Success)
                ViewBag.Tali_Birim_Id = new SelectList(result2.Data, "Id", "Tali_Birim_Ad");

            var result3 = await _isgKurulService.GetAllAsync();
            if (result3.ResultStatus == ResultStatus.Success)
                ViewBag.Isg_Kurul_Id = new SelectList(result3.Data, "Id", "Kurul_Ad");

            var result4 = await _isverenService.GetAllAsync();
            if (result4.ResultStatus == ResultStatus.Success)
                ViewBag.Isveren_Id = new SelectList(result4.Data, "Id", "Isveren_Ad");
            return View();
        }

        // POST: DofController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        public async Task<IActionResult> Create(DofDTO dof)
        {

            if (ModelState.IsValid)
            {
                var resultObject = (await _birimService.GetAsync(currentKurul)).Data.Isg_Kurul_Id;

                dof.Isg_Kurul_Id = resultObject;
                var result = await _dofService.AddAsync(dof, 1);
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

                    var result2 = await _taliBirimService.GetAllAsync(currentKurul);
                    if (result2.ResultStatus == ResultStatus.Success)
                        ViewBag.Tali_Birim_Id = new SelectList(result2.Data, "Id", "Tali_Birim_Ad");
                    return View();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: DofController/Edit/5
        [Route("Detaylar")]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _dofService.GetAsync(id);
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


        // GET: DofController/Edit/5
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _dofService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _birimService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");

                var result2 = await _taliBirimService.GetAllAsync(currentKurul);
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Tali_Birim_Id = new SelectList(result2.Data, "Id", "Tali_Birim_Ad");

                var result3 = await _isgKurulService.GetAllAsync();
                if (result3.ResultStatus == ResultStatus.Success)
                    ViewBag.Isg_Kurul_Id = new SelectList(result3.Data, "Id", "Kurul_Ad");

                var result4 = await _isverenService.GetAllAsync();
                if (result4.ResultStatus == ResultStatus.Success)
                    ViewBag.Isveren_Id = new SelectList(result4.Data, "Id", "Isveren_Ad");
                return View(result.Data);
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("Index");
        }

        // POST: DofController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id, DofDTO dof)
        {
            var result = await _dofService.GetAsync(id);
            if (result != null)
            {
                dof.Isg_Kurul_Id = result.Data.Isg_Kurul_Id;
                var dofResult = await _dofService.UpdateAsync(dof, 2);

                if (dofResult.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                    return RedirectToAction("Index");
                }
            }
            else
            {
                var result1 = await _birimService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");

                var result2 = await _taliBirimService.GetAllAsync(currentKurul);
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Tali_Birim_Id = new SelectList(result2.Data, "Id", "Tali_Birim_Ad");

                var result3 = await _isgKurulService.GetAllAsync();
                if (result3.ResultStatus == ResultStatus.Success)
                    ViewBag.Isg_Kurul_Id = new SelectList(result3.Data, "Id", "Kurul_Ad");

                var result4 = await _isverenService.GetAllAsync();
                if (result4.ResultStatus == ResultStatus.Success)
                    ViewBag.Isveren_Id = new SelectList(result4.Data, "Id", "Isveren_Ad");
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return View();
        }

        [HttpGet]
        [Route("DosyaIslem")]
        public async Task<IActionResult> DofDosyaIslem(int id)
        {
            var result = await _dofService.GetAsync(id);

            var result2 = await _dof_DosyaService.GetAllAsync();
            var result3 = await _dof_DosyaService.GetAsync(0);
            foreach (var item in result2.Data)
            {
                if (item.Dof_Id == id)
                {
                    result3 = await _dof_DosyaService.GetAsync(item.Id);
                }
            }
            TempData["dofId"] = Convert.ToInt64(id);
            ViewBag.DofId = id;
            if (result3.Data == null)
            {
                return View();
            }
            return View(result3.Data);
        }


        [HttpGet]
        [Route("DosyaEkle")]
        public async Task<IActionResult> DofDosyaEkle(int id)
        {
            var result = await _dofService.GetAsync(id);

            var result2 = await _dof_DosyaService.GetAllAsync();
            var result3 = await _dof_DosyaService.GetAsync(0);

            foreach (var item in result2.Data)
            {
                if (item.Dof_Id == id)
                {
                    result3 = await _dof_DosyaService.GetAsync(item.Id);
                }
            }
            ViewBag.DofId = Convert.ToInt64(id);
            TempData["dofId"] = id;
            if (result3.Data == null)
            {
                return View();
            }
            return View(result3.Data);
        }



        [HttpPost]
        [Route("DosyaEkle")]
        public async Task<IActionResult> DofDosyaEkle(IEnumerable<IFormFile> file, Dof_DosyaDTO dofDosyaDTO)
        {
            dofDosyaDTO.Id = 0;
            dofDosyaDTO.Dof_Id = Convert.ToInt64(TempData["dofId"]);
            dofDosyaDTO.Isveren_Id = 2;
            foreach (var item in file)
            {
                Guid guid = Guid.NewGuid();

                var filePaths = new List<string>();
                dofDosyaDTO.Dosya = item.FileName;

                var path = Path.GetExtension(dofDosyaDTO.Dosya);
                var type = guid.ToString() + path;
                var filePath = "wwwroot/Dosya/Dof/" + type;
                filePaths.Add(filePath);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                }
                dofDosyaDTO.Dosya = "Dosya/Dof/" + type;
                dofDosyaDTO.Id = 0;
                var result = await _dof_DosyaService.AddAsync(dofDosyaDTO, 1);
                //if (result.ResultStatus == ResultStatus.Success)
                //{
                //    TempData["MessageIcon"] = "success";
                //    TempData["MessageText"] = result.Message;
                //}
                //else
                //{
                //    if (System.IO.File.Exists(filePath))
                //    {
                //        System.IO.File.Delete(filePath);
                //    }
                //}

            }




            return RedirectToAction("Index");
        }


        [Route("DosyaIndir")]
        public async Task<IActionResult> DownloadFileFromFileSystem(int id)
        {
            var file = await _dof_DosyaService.GetAsync(id);
            if (file == null)
                return null;
            var memory = new MemoryStream();
            using (var stream = new FileStream(file.Data.Dosya, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "image/jpg", "DofDosya" + file.Data.Dosya);
        }


        [Route("DosyaSil")]
        public async Task<IActionResult> DeleteFileFromFileSystem(int id)
        {
            var result = await _dof_DosyaService.GetAsync(id);

            if (result != null)
            {
                var filePath = result.Data.Dosya;
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                var resultObject = await _dof_DosyaService.HardDeleteAsync(id);

                if (resultObject.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                    return View(result.Data);
                    //return RedirectToAction("MsdsDosyaEkle",result.Data);
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
        public async Task<IActionResult> DeleteFileFromFileSystem(IFormFile Dosya, Dof_DosyaDTO dofDosyaDTO)
        {
            Guid guid = Guid.NewGuid();

            var filePaths = new List<string>();

            if (Dosya.Length > 0)
            {
                dofDosyaDTO.Dosya = Dosya.FileName;

                var path = Path.GetExtension(dofDosyaDTO.Dosya);
                var type = guid.ToString() + path;
                // full path to file in temp location
                var filePath = "Dosya/Dof/" + type;

                filePaths.Add(filePath);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Dosya.CopyToAsync(stream);
                }
                dofDosyaDTO.Dosya = filePath;
                dofDosyaDTO.Id = 0;
                dofDosyaDTO.Dof_Id = Convert.ToInt64(TempData["dofId"]);
                dofDosyaDTO.Isveren_Id = 2;
                var result = await _dof_DosyaService.AddAsync(dofDosyaDTO, 1);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Sil")]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _dofService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }


        [HttpPost]
        public async Task<JsonResult> GetBirim(int id)
        {
            var result = await _taliBirimService.GetAllTaliBirim(id);
            return Json(new SelectList(result.Data.ToList(), "Id", "Tali_Birim_Ad"));
        }
    }
}
