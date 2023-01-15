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
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InformsISG.WebApp.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,IsgUzman,IsYeriHekim,BirimSorumlusu", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("Kkd/")]
    public class KkdController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IKkdService _kkdService;
        private readonly IKkd_TurService _kkd_TurService;
        private readonly IKkd_Tur_AltService _kkd_Tur_AltService;

        private readonly IISg_KurulService _isg_KurulService;
        private readonly IIsverenService _isverenService;
        private readonly IBirimService _birimService;
        private readonly ITali_BirimService _taliBirimService;
        private readonly IPersonel_BilgiService _personel_BilgiService;
        private readonly IKkd_Personel_AtamaService _kkd_Personel_AtamaService;
        


        public KkdController(IKkdService kkdService, IKkd_TurService kkdTurService, IKkd_Tur_AltService kkdTurAltService,IISg_KurulService isgKurulService,IIsverenService isverenService,IBirimService birimService,
            ITali_BirimService taliBirimService,IPersonel_BilgiService personelBilgiService,IKkd_Personel_AtamaService kkdPersonelAtamaService)
        {
            _kkdService = kkdService;
            _kkd_TurService = kkdTurService;
            _kkd_Tur_AltService = kkdTurAltService;
            _isg_KurulService = isgKurulService;
            _isverenService = isverenService;
            _birimService = birimService;
            _taliBirimService = taliBirimService;
            _personel_BilgiService = personelBilgiService;
            _kkd_Personel_AtamaService = kkdPersonelAtamaService;
        }

        // GET: KkdController
        [Route("Liste")]
        public async Task<IActionResult> Index()
        {
            var result = await _kkdService.GetAllAsync();
            ViewBag.Kkd = (await _kkd_TurService.GetAllAsync()).Data.Count;

            if (result.ResultStatus == ResultStatus.Success)
            {
                ViewBag.KkdTurAltListe = (await _kkd_Tur_AltService.GetAllAsync()).Data;
                return View(result.Data);
            }
            return View();
        }


        // GET: KkdController/Create
        [Route("Olustur")]
        public async Task<IActionResult> Create()
        {
            var result1 = await _kkd_TurService.GetAllAsync();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Kkd_Tur_Id = new SelectList(result1.Data, "Id", "Kkd_Tur_Ad");
            var result2 = await _kkd_Tur_AltService.GetAllAsync();
            if (result2.ResultStatus == ResultStatus.Success)
                ViewBag.Kkd_Tur_Alt_Id = new SelectList(result2.Data, "Id", "Kkd_Tur_Alt_Ad");   
            var result3 = await _isg_KurulService.GetAllAsync();
            if (result3.ResultStatus == ResultStatus.Success)
                ViewBag.Isg_Kurul_Id = new SelectList(result3.Data, "Id", "Kurul_Ad");
            var result4= await _isverenService.GetAllAsync();
            if (result4.ResultStatus == ResultStatus.Success)
                ViewBag.Isveren_Id = new SelectList(result4.Data, "Id", "Isveren_Ad");
            return View();
        }

        // POST: KkdController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        public async Task<IActionResult> Create(KkdDTO kkd)
        {
            if (ModelState.IsValid)
            {
                var resultObject = (await _birimService.GetAsync(currentKurul)).Data.Isg_Kurul_Id;
                kkd.Isg_Kurul_Id = resultObject;
                var result = await _kkdService.AddAsync(kkd, 1);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = result.Message;
                    var result1 = await _kkd_TurService.GetAllAsync();
                    if (result1.ResultStatus == ResultStatus.Success)
                        ViewBag.Kkd_Tur_Id = new SelectList(result1.Data, "Id", "Kkd_Tur_Ad");
                    var result2 = await _kkd_Tur_AltService.GetAllAsync();
                    if (result2.ResultStatus == ResultStatus.Success)
                        ViewBag.Kkd_Tur_Alt_Id = new SelectList(result2.Data, "Id", "Kkd_Tur_Alt_Ad");
                    var result3 = await _isg_KurulService.GetAllAsync();
                    if (result3.ResultStatus == ResultStatus.Success)
                        ViewBag.Isg_Kurul_Id = new SelectList(result3.Data, "Id", "Kurul_Ad");
                    var result4 = await _isverenService.GetAllAsync();
                    if (result4.ResultStatus == ResultStatus.Success)
                        ViewBag.Isveren_Id = new SelectList(result4.Data, "Id", "Isveren_Ad");
                    return View();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: KkdController/Edit/5
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _kkdService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _kkd_TurService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Kkd_Tur_Id = new SelectList(result1.Data, "Id", "Kkd_Tur_Ad");
                var result2 = await _kkd_Tur_AltService.GetAllAsync();
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Kkd_Tur_Alt_Id = new SelectList(result2.Data, "Id", "Kkd_Tur_Alt_Ad");
                var result3 = await _isg_KurulService.GetAllAsync();
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

        // POST: KkdController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id, KkdDTO kkd)
        {
            var result = await _kkdService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                kkd.Isg_Kurul_Id = result.Data.Isg_Kurul_Id;
                var kkdResult = await _kkdService.UpdateAsync(kkd, 2);

                if (kkdResult.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = kkdResult.Message;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = kkdResult.Message;
                    var result1 = await _kkd_TurService.GetAllAsync();
                    if (result1.ResultStatus == ResultStatus.Success)
                        ViewBag.Kkd_Tur_Id = new SelectList(result1.Data, "Id", "Kkd_Tur_Ad");
                    var result2 = await _kkd_Tur_AltService.GetAllAsync();
                    if (result2.ResultStatus == ResultStatus.Success)
                        ViewBag.Kkd_Tur_Alt_Id = new SelectList(result2.Data, "Id", "Kkd_Tur_Alt_Ad");
                    var result3 = await _isg_KurulService.GetAllAsync();
                    if (result3.ResultStatus == ResultStatus.Success)
                        ViewBag.Isg_Kurul_Id = new SelectList(result3.Data, "Id", "Kurul_Ad");
                    var result4 = await _isverenService.GetAllAsync();
                    if (result4.ResultStatus == ResultStatus.Success)
                        ViewBag.Isveren_Id = new SelectList(result4.Data, "Id", "Isveren_Ad");

                }
            }
            else
            {
                var result1 = await _kkd_TurService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Kkd_Tur_Id = new SelectList(result1.Data, "Id", "Kkd_Tur_Ad");
                var result2 = await _kkd_Tur_AltService.GetAllAsync();
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Kkd_Tur_Alt_Id = new SelectList(result2.Data, "Id", "Kkd_Tur_Alt_Ad");
                var result3 = await _isg_KurulService.GetAllAsync();
                if (result3.ResultStatus == ResultStatus.Success)
                    ViewBag.Isg_Kurul_Id = new SelectList(result3.Data, "Id", "Kurul_Ad");
                var result4 = await _isverenService.GetAllAsync();
                if (result4.ResultStatus == ResultStatus.Success)
                    ViewBag.Isveren_Id = new SelectList(result4.Data, "Id", "Isveren_Ad");
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("Index");
        }

        // GET: KkdController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Sil")]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _kkdService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }

        [HttpPost]
        public async Task<JsonResult> GetKkdTurAlt(int id)
        {
            var result = await _kkd_Tur_AltService.GetAllKkd(id);
            return Json(new SelectList(result.Data.ToList(), "Id", "Kkd_Tur_Alt_Ad"));
        }
     
        [Route("Detaylar")]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _kkdService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _kkd_TurService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Kkd_Tur_Id = new SelectList(result1.Data, "Id", "Kkd_Tur_Ad");
                var result2 = await _kkd_Tur_AltService.GetAllAsync();
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Kkd_Tur_Alt_Id = new SelectList(result2.Data, "Id", "Kkd_Tur_Alt_Ad");
                var result3 = await _isg_KurulService.GetAllAsync();
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



        // GET: KkdController/Edit/5
        [Route("KkdVePersonelGoster")]
        public async Task<IActionResult> KkdVePersonel(int id)
        {
            var result = await _kkdService.GetAsync(id);

            ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
            ViewBag.KkdPersonelAtama = (await _kkd_Personel_AtamaService.GetAllAsync()).Data;
            ViewBag.TaliBirimList = (await _taliBirimService.GetAllAsync(currentKurul)).Data;

            TempData["idd"]=id;

            TempData["id"] = id;

            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _taliBirimService.GetAllAsync(currentKurul);
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Tali_Birim_Id = new SelectList(result1.Data, "Id", "Tali_Birim_Ad");
                return View(result.Data);
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("Index");
        }

        // GET: Egitim_Tanimla
        [Route("PersonelAtama")]
        [HttpPost]
        public async Task<IActionResult> PersonelAtama(Personel_BilgiDTO personel)
        {
            ViewBag.TaliBirimList = (await _taliBirimService.GetAllAsync(currentKurul)).Data;

            var kkdId = Convert.ToInt64(TempData["id"]);

            var result = await _kkdService.GetAsync(kkdId);

            ViewBag.KkdPersonelAtama = (await _kkd_Personel_AtamaService.GetAllAsync()).Data;
            ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;


            if (result.ResultStatus == ResultStatus.Success)
            {
                ViewBag.talibirimId = personel.Tali_Birim_Id;
                ViewBag.egitimTanimId = TempData["id"];


                var personelAtama2 = (await _kkd_Personel_AtamaService.GetAllKkdAsync(kkdId)).Data;
                var personelListe2 = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;

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


        [Route("PersonelEkle")]
        public async Task<IActionResult> PersonelEkle(Kkd_Personel_AtamaDTO personel, long id, string[] names)
        {
            ViewBag.TaliBirimList = (await _taliBirimService.GetAllAsync(currentKurul)).Data;

            var result = await _kkd_Personel_AtamaService.GetAllAsync();
            if (result.ResultStatus == ResultStatus.Success)
            {
                ViewBag.kkdId = TempData["kkdid"];


                personel.Id = 0;
                personel.Kkd_Id = Convert.ToInt64(TempData["kkdid"]);
                for (int i = 0; i < names.Length; i++)
                {
                    personel.Personel_Id = Convert.ToInt64(names[i]);
                   await _kkd_Personel_AtamaService.AddAsync(personel, 1);

                }


                var talibirimResult = await _taliBirimService.GetAllAsync(currentKurul);

                result = await _kkd_Personel_AtamaService.GetAllAsync();

                if (talibirimResult.ResultStatus == ResultStatus.Success)
                {
                    ViewBag.Tali_Birim_Id = new SelectList(talibirimResult.Data.ToList(), "Id", "Tali_Birim_Ad");
                }
                ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
                return RedirectToAction("KkdVePersonel", "Kkd", new { ID = Convert.ToInt64(TempData["kkdid"]) });
            }
            return View();
        }


    }
}
