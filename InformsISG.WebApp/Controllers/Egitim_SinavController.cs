using InformsISG.Core.Utilities.Results;
using InformsISG.Entities.Concrete;
using InformsISG.Entities.Dtos;
using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InformsISG.WebApp.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,IsgUzman,IsYeriHekim,BirimSorumlusu", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("EgitimSinav/")]
    public class Egitim_SinavController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IEgitim_SinavService _egitim_SinavService;
        private readonly IEgitim_Sinav_NotService _egitim_Sinav_NotService;
        private readonly IISg_KurulService _isgKurulService;
        private readonly IIsverenService _isverenService;
        private readonly IBirimService _birimService;


        private readonly IEgitim_TanimlaService _egitimTanimlaService;
        private readonly IEgitim_Personel_AtamaService _egitim_personel_AtamaService;
        private readonly IPersonel_BilgiService _personel_BilgiService;


        public Egitim_SinavController(IEgitim_SinavService egitimSinavService,IIsverenService isverenService,IISg_KurulService isg_KurulService,IEgitim_TanimlaService egitimTanimlaService, IEgitim_Personel_AtamaService egitimPersonelAtamaService,IPersonel_BilgiService personelBilgiService,IEgitim_Sinav_NotService egitimSinavNotService,IBirimService birimService)
        {
            _egitim_SinavService = egitimSinavService;
            _isgKurulService = isg_KurulService;
            _isverenService = isverenService;
            _egitimTanimlaService = egitimTanimlaService;
            _egitim_personel_AtamaService = egitimPersonelAtamaService;
            _personel_BilgiService = personelBilgiService;
            _egitim_Sinav_NotService = egitimSinavNotService;
            _birimService = birimService;
        }

        // GET: Egitim_SinavController
        [Route("Liste")]
        public async Task<IActionResult> Index()
        {
            var result = await _egitim_SinavService.GetAllAsync();
            ViewBag.Sinav = (await _egitim_SinavService.GetAllAsync()).Data.Count;


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

        // GET: Egitim_SinavController/Create
        [Route("Olustur")]
        public async Task<IActionResult> Create()
        {
            var result1 = await _isgKurulService.GetAllAsync();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");
            var result2 = await _isverenService.GetAllAsync();
            if (result2.ResultStatus == ResultStatus.Success)
                ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");

            var egitimTanim = await _egitimTanimlaService.GetAllAsync();
            if (egitimTanim.ResultStatus == ResultStatus.Success)
            {
                ViewBag.EgitimTanim = new SelectList(egitimTanim.Data.ToList(), "Id", "Egitim_Ad");
            }

            return View();
        }

        // POST: Egitim_SinavController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        public async Task<IActionResult> Create(Egitim_SinavDTO egitim_sinav,long Id)
        {

            if (ModelState.IsValid)
            {
                var resultObject = (await _birimService.GetAsync(currentKurul)).Data.Isg_Kurul_Id;

                egitim_sinav.Isg_Kurul_Id = resultObject;
                var result = await _egitim_SinavService.AddAsync(egitim_sinav, 1);
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

        // GET: Egitim_SinavController/Edit/5
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _egitim_SinavService.GetAsync(id);


            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _isgKurulService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");
                var result2 = await _isverenService.GetAllAsync();
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");


                var egitimTanim = await _egitimTanimlaService.GetAllAsync();
                if (egitimTanim.ResultStatus == ResultStatus.Success)
                {
                    ViewBag.EgitimTanim = new SelectList(egitimTanim.Data.ToList(), "Id", "Egitim_Ad");
                }
                return View(result.Data);
            }
            return View();
        }

        // POST: Egitim_SinavController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Duzenle")]
        public async Task<ActionResult> Edit(int id, Egitim_SinavDTO egitimSinav)
        {

            var result1 = await _isgKurulService.GetAllAsync();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");
            var result2 = await _isverenService.GetAllAsync();
            if (result2.ResultStatus == ResultStatus.Success)
                ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");


            var egitimTanim = await _egitimTanimlaService.GetAllAsync();
            if (egitimTanim.ResultStatus == ResultStatus.Success)
            {
                ViewBag.EgitimTanim = new SelectList(egitimTanim.Data.ToList(), "Id", "Egitim_Ad");
            }
            var result = await _egitim_SinavService.GetAsync(id);

            if (result.ResultStatus == ResultStatus.Success)
            {
                var resultObject = await _egitim_SinavService.UpdateAsync(egitimSinav, 1);
                if (resultObject.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = resultObject.Message;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = resultObject.Message;
                }
                return View(result.Data);
            }
            return View();
        }

        // GET: Egitim_SinavController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Egitim_SinavController/Delete/5
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

        // GET: Egitim_SinavController/Edit/5
        [Route("SinavNot")]
        public async Task<IActionResult> Egitim_Sinav_Not(Egitim_Sinav_NotDTO egitimSinav,int id)
        {
            int COUNT = 0;
            ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
            //foreach (var item in PersonelAtaList)
            //    {
            //    if(item.Egitim_Tanimla_Id == id)
            //        {
            //        foreach(var item2 in PersonelList)
            //            {
            //            if(item.Personel_Id == item2.Id)
            //            {
            //                COUNT++;
            //                egitimSinav.Personel_Id = item.Personel_Id;
            //                egitimSinav.Id = 0;
            //                egitimSinav.Egitim_Sinav_Id = id;
            //                await _egitim_Sinav_NotService.AddAsync(egitimSinav, 1);
            //            }
            //        } } }

            ViewBag.Count = COUNT;
            TempData["COUNT"] = COUNT;
            var result = await _egitim_SinavService.GetAsync(id);
            ViewBag.Sinav= (await _egitim_Sinav_NotService.GetSinav(id)).Data;
            var resultt = result.Data.Egitim_Tanimla_Id;
            var result5 = await _egitim_personel_AtamaService.GetPersonel(resultt);
            
            TempData["EgitimTanimlaId"] =Convert.ToInt32(result.Data.Egitim_Tanimla_Id);
            ViewBag.ID = result.Data.Id;

            ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
            ViewBag.PersonelAtaList = (await _egitim_personel_AtamaService.GetAllAsync()).Data;
            TempData["ID"] = id;
            if (result5.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _isgKurulService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");
                var result2 = await _isverenService.GetAllAsync();
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
                var egitimTanim = await _egitimTanimlaService.GetAllAsync();
                if (egitimTanim.ResultStatus == ResultStatus.Success)
                {
                    ViewBag.EgitimTanim = new SelectList(egitimTanim.Data.ToList(), "Id", "Egitim_Ad");
                }
                return View(result5.Data);
            }
            return View();
        }

        // GET: Egitim_SinavController/Edit/5
        [Route("Ayrintilar")]
        public async Task<IActionResult> Details(int id)
        {
            int COUNT = 0;
            ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
            ViewBag.Count = COUNT;
            TempData["COUNT"] = COUNT;
            var result = await _egitim_SinavService.GetAsync(id);
            ViewBag.Sinav = (await _egitim_Sinav_NotService.GetSinav(id)).Data;
            var resultt = result.Data.Egitim_Tanimla_Id;
            var result5 = await _egitim_personel_AtamaService.GetPersonel(resultt);

            TempData["EgitimTanimlaId"] = Convert.ToInt32(result.Data.Egitim_Tanimla_Id);
            ViewBag.ID = result.Data.Id;

            ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
            ViewBag.PersonelAtaList = (await _egitim_personel_AtamaService.GetAllAsync()).Data;
            TempData["ID"] = id;
            if (result5.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _isgKurulService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");
                var result2 = await _isverenService.GetAllAsync();
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
                var egitimTanim = await _egitimTanimlaService.GetAllAsync();
                if (egitimTanim.ResultStatus == ResultStatus.Success)
                {
                    ViewBag.EgitimTanim = new SelectList(egitimTanim.Data.ToList(), "Id", "Egitim_Ad");
                }
                return View(result5.Data);
            }
            return View();
        }


        public async Task<IActionResult> DENEME(IList<Egitim_Sinav_NotDTO> not)
        {

            return View(not);
        }

        // GET: Egitim_SinavController/Edit/5
        [HttpPost]
        [Route("SinavNot")]
        public async Task<IActionResult> Egitim_Sinav_Not(int[] Id, int[] SinavNot, string[] Aciklama,Egitim_Sinav_NotDTO egitimSinavNot)
        {
            int i = 0;
            egitimSinavNot.Egitim_Sinav_Id = Convert.ToInt64(TempData["ID"]);
            foreach (var item in Id)
            {
                egitimSinavNot.Id = 0;
                egitimSinavNot.Personel_Id = item;
                egitimSinavNot.Sinav_Not =Convert.ToInt32(SinavNot[i]);
                egitimSinavNot.Aciklama = Aciklama[i];
                await _egitim_Sinav_NotService.AddAsync(egitimSinavNot,1);
                i++;
            }

            return RedirectToAction("Index");
        }   
      
        [HttpPost]
        [Route("SinavNotDuzenle")]
        public async Task<IActionResult> Egitim_Sinav_NotDuzenle(int[] Id, int[] SinavNot, string[] Aciklama,Egitim_Sinav_NotDTO egitimSinavNot, int[] Id2)
        {
            int i = 0;
            int basariliMi = 0;
            foreach (var item in Id)
            {
                var result = await _egitim_Sinav_NotService.GetAsync(Id2[i]);
                result.Data.Sinav_Not =Convert.ToInt32(SinavNot[i]);
                result.Data.Aciklama = Aciklama[i];
                var resultObject = await _egitim_Sinav_NotService.UpdateAsync(result.Data, 1);
                if(resultObject.ResultStatus == ResultStatus.Success)
                {
                    basariliMi = 1;
                }
                else
                {
                    basariliMi = 0;                                                                                                                                 
                }
                i++;
            }
            if (basariliMi == 1)
            {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = "Sınav notları başarılı bir şekilde eklenmiştir";
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = "Sınav notları eklenememiştir";
            }

            return RedirectToAction("Index");
        }

    }
}

