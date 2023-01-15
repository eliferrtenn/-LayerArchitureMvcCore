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
    [Route("AcilEylemPlani/")]
    public class Acil_Eylem_PlaniController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IAcil_Eylem_PlaniService _acil_eylem_PlaniService;
        private readonly IBirimService _BirimService;
        private readonly IIsverenService _IsverenService;



        public Acil_Eylem_PlaniController(IAcil_Eylem_PlaniService acil_eylem_PlaniSerive,IBirimService birimSerive,IIsverenService isverenService)
        {
            _acil_eylem_PlaniService = acil_eylem_PlaniSerive;
            _BirimService = birimSerive;
            _IsverenService = isverenService;

        }
        // GET: Acil_Eylem_PlaniController
        //[Route("Home/Index")]
        [Route("Liste")]
        public async Task<IActionResult> Index()
        {
            var result = await _acil_eylem_PlaniService.GetAllAsync(currentKurul);
            ViewBag.Plan = (await _acil_eylem_PlaniService.GetAllAsync(currentKurul)).Data.Count;


            if (result.ResultStatus == ResultStatus.Success)
            {
                ViewBag.BirimListe = (await _BirimService.GetAllAsync()).Data;
                return View(result.Data);
            }
            return View();
        }

        // GET: Acil_Eylem_PlaniController/Create
        [Route("Olustur")]
        public async Task<IActionResult> Create()
        {
            var result1 = await _BirimService.GetAllAsync();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");
            var result2 = await _IsverenService.GetAllAsync();
            if (result2.ResultStatus == ResultStatus.Success)
                ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
            return View();
        }

        // POST: Acil_Eylem_PlaniController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        public async Task<IActionResult> Create(IFormFile Dosya, Acil_Eylem_PlaniDTO acilEylemPlani)
        {
            Guid guid = Guid.NewGuid();

            acilEylemPlani.Isveren_Id = 2;
            var filePaths = new List<string>();

            if (Dosya.Length > 0)
            {
                acilEylemPlani.Dosya = Dosya.FileName;
                acilEylemPlani.Birim_Id = currentKurul;
                var path = Path.GetExtension(acilEylemPlani.Dosya);
                var type = guid.ToString() + path;
                // full path to file in temp location
                //var filePath = Path.GetFullPath("Dosya/AcilEylemPlani/" +type);
                var filePath = "wwwroot/Dosya/AcilEylemPlani/" + type;
                filePaths.Add(filePath);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Dosya.CopyToAsync(stream);
                }
                acilEylemPlani.Dosya =filePath;
                acilEylemPlani.Id = 0;
                acilEylemPlani.Isveren_Id = 2;
                var result = await _acil_eylem_PlaniService.AddAsync(acilEylemPlani, 1);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                    return RedirectToAction("Index");
                }
                else
                {
                    {
                        var result1 = await _BirimService.GetAllAsync();
                        if (result1.ResultStatus == ResultStatus.Success)
                            ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");
                        var result2 = await _IsverenService.GetAllAsync();
                        if (result2.ResultStatus == ResultStatus.Success)
                            ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
                        TempData["MessageIcon"] = "error";
                        TempData["MessageText"] = result.Message;
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                    }
                    return View();
                }
            }
            return View();

        }


        // GET: Acil_Eylem_PlaniController/Edit/5
        [Route("Detaylar")]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _acil_eylem_PlaniService.GetAsync(id);
            ViewBag.BirimList =(await _BirimService.GetAllAsync()).Data;
            ViewBag.IsverenList =( await _IsverenService.GetAllAsync()).Data;
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

        // GET: Acil_Eylem_PlaniController/Edit/5
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _acil_eylem_PlaniService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _BirimService.GetAllAsync();
             if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");
            var result2 = await _IsverenService.GetAllAsync();
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

        // POST: Acil_Eylem_PlaniController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id, Acil_Eylem_PlaniDTO acileylemplani)
        {
            var result = await _acil_eylem_PlaniService.GetAsync(id);
            if (result != null)
            {
                acileylemplani.Dosya = result.Data.Dosya;
                var birimResult = await _acil_eylem_PlaniService.UpdateAsync(acileylemplani, 2);

                if (birimResult.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = birimResult.Message;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = birimResult.Message;
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

        // POST: Acil_Eylem_PlaniController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Sil")]
        public async Task<JsonResult> Delete(int id)
        {
            var resultObject = await _acil_eylem_PlaniService.GetAsync(id);
            if (resultObject != null)
            {
                var filePath = resultObject.Data.Dosya;
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
                var result = await _acil_eylem_PlaniService.HardDeleteAsync(id);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }

        [Route("Indir")]
        public FileResult DownloadFile(string fileName)
        {
            //Build the File Path.
            string path = "/Dosya/AcilEylemPlani/1.jpg";
    
            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }


        [Route("IndirDosya")]
        public async Task<IActionResult> DownloadFileFromFileSystem(int id)
        {
            var file = await _acil_eylem_PlaniService.GetAsync(id);
            if (file == null)
                return null;
            var memory = new MemoryStream();
            using (var stream = new FileStream(file.Data.Dosya, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "image/jpg", "AcilEylemPlaniBelge"+file.Data.Dosya);
        }

        [Route("DosyaSil")]
        public async Task<IActionResult> DeleteFileFromFileSystem(int id)
        {
            Guid guid = Guid.NewGuid();
            var result = await _acil_eylem_PlaniService.GetAsync(id);
            if (result != null)
            {
                var filePath = result.Data.Dosya;
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                result.Data.Dosya = "";
                var resultObject = await _acil_eylem_PlaniService.UpdateAsync(result.Data, 2);
                if (resultObject.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = "Dosya başarılı bir şekilde silinmiştir";
                    return RedirectToAction("EditFile",result.Data);
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = resultObject.Message;
                }
            }
            return RedirectToAction("Index");
        }

        [Route("DosyaDuzenle")]
        public async Task<IActionResult> EditFile(Acil_Eylem_PlaniDTO acileylemplani)
        {
            var result1 = await _BirimService.GetAllAsync();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");
            var result2 = await _IsverenService.GetAllAsync();
            if (result2.ResultStatus == ResultStatus.Success)
                ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
            return View(acileylemplani);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("DosyaDuzenle")]
        public async Task<IActionResult> EditFile(int id,IFormFile Dosya, Acil_Eylem_PlaniDTO acilEylemPlani)
        {
            Guid guid = Guid.NewGuid();

            acilEylemPlani.Isveren_Id = 2;
            var filePaths = new List<string>();

            var resultObject = await _acil_eylem_PlaniService.GetAsync(id);
            if (resultObject != null)
            {
                if (Dosya.Length > 0)
                {
                    acilEylemPlani.Dosya = Dosya.FileName;
                    var deneme = Path.GetExtension(acilEylemPlani.Dosya);
                    var type = guid.ToString() + deneme;
                    var filePath = "wwwroot/Dosya/AcilEylemPlani/" + type;
                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Dosya.CopyToAsync(stream);
                    }
                    acilEylemPlani.Dosya = filePath;
                    acilEylemPlani.Isveren_Id = 2;
                    var result = await _acil_eylem_PlaniService.UpdateAsync(acilEylemPlani, 1);
                    if (result.ResultStatus == ResultStatus.Success)
                    {
                        TempData["MessageIcon"] = "success";
                        TempData["MessageText"] = result.Message;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        var result1 = await _BirimService.GetAllAsync();
                        if (result1.ResultStatus == ResultStatus.Success)
                            ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");
                        var result2 = await _IsverenService.GetAllAsync();
                        if (result2.ResultStatus == ResultStatus.Success)
                            ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
                        TempData["MessageIcon"] = "error";
                        TempData["MessageText"] = resultObject.Message;
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                    }


                    return View();
                }
                else
                {
                    var result1 = await _BirimService.GetAllAsync();
                    if (result1.ResultStatus == ResultStatus.Success)
                        ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");
                    var result2 = await _IsverenService.GetAllAsync();
                    if (result2.ResultStatus == ResultStatus.Success)
                        ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
                    return View();
                }
            }
            else
            {

                var result1 = await _BirimService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");
                var result2 = await _IsverenService.GetAllAsync();
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = resultObject.Message;
            }
            return View();

        }


    }
}
