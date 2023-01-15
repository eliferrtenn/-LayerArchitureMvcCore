using AutoMapper;
using InformsISG.Core.Utilities.Results;
using InformsISG.Entities.Concrete;
using InformsISG.Entities.Dtos;
using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformsISG.WebApp.Controllers
{
    public class Acil_Durum_EkipleriController : Controller
    {
        private readonly IAcil_Durum_EkipleriService _acil_durum_EkipleriService;

        public Acil_Durum_EkipleriController(IAcil_Durum_EkipleriService acil_durum_EkipleriService)
        {
            _acil_durum_EkipleriService = acil_durum_EkipleriService;
        }
        // GET: Acil_Durum_EkipleriController
        public async Task<IActionResult> Index()
        {
            var result = await _acil_durum_EkipleriService.GetAllAsync();
            ViewBag.Ekipler = (await _acil_durum_EkipleriService.GetAllAsync()).Data.Count;


            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // GET: Acil_Durum_EkipleriController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Acil_Durum_EkipleriController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Acil_Durum_EkipleriDTO acilDurumEkipleri)
        {
            if (ModelState.IsValid)
            {
                var result = await _acil_durum_EkipleriService.AddAsync(acilDurumEkipleri, 1);
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

        // GET: Acil_Durum_EkipleriController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _acil_durum_EkipleriService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // POST: Acil_Durum_EkipleriController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Acil_Durum_EkipleriDTO acilDurumEkipleri)
        {
            
            if (ModelState.IsValid)
            {
                    DateTime dateTime = DateTime.Now;
                    var resultEkip = await _acil_durum_EkipleriService.UpdateAsync(acilDurumEkipleri, 1);
                    if (resultEkip.ResultStatus == ResultStatus.Success)
                    {
                        TempData["MessageIcon"] = "success";
                        TempData["MessageText"] = resultEkip.Message;
                    }
                    else
                    {
                        TempData["MessageIcon"] = "error";
                        TempData["MessageText"] = resultEkip.Message;
                        return View();
                    }
                
                //var result = await _acil_durum_EkipleriService.GetAsync(id);
                //if (result.ResultStatus == ResultStatus.Success)
                //{
                //DateTime dateTime = DateTime.Now;
                //acilDurumEkipleri.Degistirilme_Tarihi = dateTime;
                //var resultEkip = await _acil_durum_EkipleriService.UpdateAsync(acilDurumEkipleri, 1);
                //if (resultEkip.ResultStatus == ResultStatus.Success)
                //{
                //    TempData["MessageIcon"] = "success";
                //    TempData["MessageText"] = result.Message;
                //}
                //else
                //{
                //    TempData["MessageIcon"] = "error";
                //    TempData["MessageText"] = result.Message;
                //    return View();
                //}
                //}

            }
            return RedirectToAction("Index");
        }

        // GET: Acil_Durum_EkipleriController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Acil_Durum_EkipleriController/Delete/5
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
