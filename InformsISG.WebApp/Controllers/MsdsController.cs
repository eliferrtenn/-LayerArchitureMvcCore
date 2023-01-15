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
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InformsISG.WebApp.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,IsgUzman,IsYeriHekim,BirimSorumlusu", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("Msds/")]
    public class MsdsController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IMsdsService _msdsService;
        private readonly IISg_KurulService _isg_KurulService;
        private readonly IIsverenService _isverenService;
        private readonly IMsds_DosyaService _msds_DosyaService;
        private readonly IBirimService _birimService;

        public MsdsController(IMsdsService msdsService,IISg_KurulService isgKurulService,IIsverenService isverenService,IMsds_DosyaService msdsDosyaService,IBirimService birimService)
        {
            _msdsService = msdsService;
            _isg_KurulService = isgKurulService;
            _isverenService = isverenService;
            _msds_DosyaService = msdsDosyaService;
            _birimService = birimService;
        }

        // GET: MsdsController
        [Route("Liste")]
        public async Task<IActionResult> Index()
        {
          
            var result = await _msdsService.GetAllAsync();
            ViewBag.Msds = (await _msdsService.GetAllAsync()).Data.Count;

            ViewBag.MsdsDosya = (await _msds_DosyaService.GetAllAsync()).Data;
            ViewBag.Count = (await _msds_DosyaService.GetAllAsync()).Data.Count;
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _isg_KurulService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");
                var result2 = await _isverenService.GetAllAsync();
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
                return View(result.Data);
            }
            return View();
        }

        // GET: MsdsController/Create
        [Route("Olustur")]
        public async Task<IActionResult> Create()
        {
            var result1 = await _isg_KurulService.GetAllAsync();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");
            var result2 = await _isverenService.GetAllAsync();
            if (result2.ResultStatus == ResultStatus.Success)
                ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
            return View();
        }

        // POST: MsdsController/Create
        [HttpPost]
        [Route("Olustur")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MsdsDTO msds)
        {
            if (ModelState.IsValid)
            {
                var resultObject = (await _birimService.GetAsync(currentKurul)).Data.Isg_Kurul_Id;

                msds.Isg_Kurul_Id = resultObject;
                var result = await _msdsService.AddAsync(msds, 1);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                }
                else
                {
                    var result1 = await _isg_KurulService.GetAllAsync();
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

        [Route("Detaylar")]
        // GET: MsdsController/Edit/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _msdsService.GetAsync(id);
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

        [Route("Duzenle")]
        // GET: MsdsController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _msdsService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _isg_KurulService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");
                var result2 = await _isverenService.GetAllAsync();
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
                return View(result.Data);
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("Index");
        }

        // POST: MsdsController/Edit/5
        [Route("Duzenle")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,MsdsDTO msds)
        {

            var result = await _msdsService.GetAsync(id);
            if (result != null)
            {
                msds.Isg_Kurul_Id = result.Data.Isg_Kurul_Id;
                var birimResult = await _msdsService.UpdateAsync(msds, 2);
                if (birimResult.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = birimResult.Message;
                    return RedirectToAction("Index");
                }
                else
                {
                    var result1 = await _isg_KurulService.GetAllAsync();
                    if (result1.ResultStatus == ResultStatus.Success)
                        ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");
                    var result2 = await _isverenService.GetAllAsync();
                    if (result2.ResultStatus == ResultStatus.Success)
                        ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = birimResult.Message;
                    return View();
                }
                    
            }
            else
            {
                var result1 = await _isg_KurulService.GetAllAsync();
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

        // GET: MsdsController/Delete/5
        [Route("Sil")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _msdsService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }


        [Route("DosyaIslem")]
        [HttpGet]
        public async Task<IActionResult> MsdsDosyaIslem(int id)
        {
            var result2 = await _msds_DosyaService.GetAllAsync();
            var result3 =await  _msds_DosyaService.GetAsync(0);
            foreach(var item in result2.Data)
            {
                if (item.Msds_Id == id)
                {  
                   result3 =await  _msds_DosyaService.GetAsync(item.Id);
                }
            }
            TempData["msdsId"] =Convert.ToInt64(id);
            ViewBag.MsdsId = id;
            if (result3.Data == null)
            {
                return View();
            }
            return View(result3.Data);
        }
        

        [Route("DosyaEkle")]
        [HttpGet]
        public async Task<IActionResult> MsdsDosyaEkle(int id)
        {
            var result2 = await _msds_DosyaService.GetAllAsync();
            var result3 =await  _msds_DosyaService.GetAsync(0);

            foreach(var item in result2.Data)
            {
                if (item.Msds_Id == id)
                {
                   result3 =await  _msds_DosyaService.GetAsync(item.Id);
                }
            }
            ViewBag.MsdsId =Convert.ToInt64(id);
            TempData["msdsId"] = id;
            if (result3.Data == null)
            {
                return View();
            }
            return View(result3.Data);
        }

        [Route("DosyaEkle")]
        [HttpPost]
        public async Task<IActionResult> MsdsDosyaEkle(Msds_DosyaDTO msdsDosyaDTO,IFormFile file)
        {
            Guid guid = Guid.NewGuid();

            var filePaths = new List<string>();
            if (file.Length > 0)
                {
                msdsDosyaDTO.Dosya = file.FileName;

                var path = Path.GetExtension(msdsDosyaDTO.Dosya);
                    var type = guid.ToString() + path;

                    // full path to file in temp location
                    var filePath = "wwwroot/Dosya/Msds/" + type;

                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    msdsDosyaDTO.Dosya = filePath;
                    msdsDosyaDTO.Id = 0;
                    msdsDosyaDTO.Msds_Id = Convert.ToInt64(TempData["msdsId"]);
                    msdsDosyaDTO.Isveren_Id = 2;
                    var result = await _msds_DosyaService.AddAsync(msdsDosyaDTO, 1);
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
            var file = await _msds_DosyaService.GetAsync(id);
            if (file == null)
                return null;
            var memory = new MemoryStream();
            using (var stream = new FileStream(file.Data.Dosya, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "image/jpg", "Msds" + file.Data.Dosya);
        }

        [Route("DosyaSil")]
        public async Task<IActionResult> DeleteFileFromFileSystem(int id)
        {
            var result = await _msds_DosyaService.GetAsync(id);
            ViewBag.MsdsId = TempData["msdsId"];
            TempData["msdsId"] = TempData["msdsId"];
            if (result != null)
            {
                var filePath = result.Data.Dosya;
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                var resultObject = await _msds_DosyaService.HardDeleteAsync(id);

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

        [Route("DosyaSil")]
        [HttpPost]
        public async Task<IActionResult> DeleteFileFromFileSystem(IFormFile Dosya, Msds_DosyaDTO msdsDosyaDTO)
        {
            Guid guid = Guid.NewGuid();

            var filePaths = new List<string>();

            if (Dosya.Length > 0)
            {
                msdsDosyaDTO.Dosya = Dosya.FileName;

                var path = Path.GetExtension(msdsDosyaDTO.Dosya);
                var type = guid.ToString() + path;
                // full path to file in temp location
                var filePath = "wwwroot/Dosya/Msds/" + type;

                filePaths.Add(filePath);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Dosya.CopyToAsync(stream);
                }
                msdsDosyaDTO.Dosya = filePath;
                msdsDosyaDTO.Id = 0;
                msdsDosyaDTO.Msds_Id = Convert.ToInt64(TempData["msdsId"]);
                msdsDosyaDTO.Isveren_Id = 2;
                var result = await _msds_DosyaService.AddAsync(msdsDosyaDTO, 1);
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
