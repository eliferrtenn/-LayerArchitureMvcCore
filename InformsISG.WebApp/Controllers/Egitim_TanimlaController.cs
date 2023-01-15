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
    [Route("EgitimTanim/")]
    public class Egitim_TanimlaController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IEgitim_TanimlaService _egitim_TanimlaService;
        private readonly IEgitim_Konu_Alt_BaslikService _egitim_konu_alt_BaslikService;
        private readonly IISg_KurulService _isg_KurulService;
        private readonly IIsverenService _isverenService;

        private readonly IEgitim_Konu_Alt_BaslikService _egitim_konu_AltBaslikService;
        private readonly IEgitim_KonuService _egitim_KonuService;
        private readonly IEgitim_Personel_AtamaService _egitim_Personel_AtamaService;
        private readonly IPersonel_BilgiService _personel_BilgiService;
        private readonly ITali_BirimService _tali_BirimService;
        private readonly IEgitim_Veren_PersonelService _egitim_veren_PersonelService;
        private readonly IBirimService _birimService;
        private readonly IEgitim_Tanim_KonuService _egitim_Tanim_KonuService;



        public Egitim_TanimlaController(IEgitim_TanimlaService egitimTanimlaService, IEgitim_Konu_Alt_BaslikService egitimKonuAltBaslikService, IISg_KurulService isgKurulService, IIsverenService isverenService, IEgitim_Konu_Alt_BaslikService egitim_konu_AltbaslikService, IEgitim_KonuService egitim_KonuService, IEgitim_Personel_AtamaService egitimPersonelAtamaService, IPersonel_BilgiService personelBilgiService, ITali_BirimService tali_BirimService, IEgitim_Veren_PersonelService egitimverenPersonelService,IBirimService birimService,IEgitim_Tanim_KonuService egitim_Tanim_KonuService)
        {
            _egitim_TanimlaService = egitimTanimlaService;
            _egitim_konu_alt_BaslikService = egitimKonuAltBaslikService;
            _isg_KurulService = isgKurulService;
            _isverenService = isverenService;
            _egitim_konu_AltBaslikService = egitim_konu_AltbaslikService;
            _egitim_KonuService = egitim_KonuService;
            _egitim_Personel_AtamaService = egitimPersonelAtamaService;
            _personel_BilgiService = personelBilgiService;
            _tali_BirimService = tali_BirimService;
            _egitim_veren_PersonelService = egitimverenPersonelService;
            _birimService = birimService;
            _egitim_Tanim_KonuService = egitim_Tanim_KonuService;
        }

        // GET: Egitim_Tanimla
        [Route("Liste")]
        public async Task<IActionResult> Index()
        {
            var result = await _egitim_TanimlaService.GetAllAsync();

            ViewBag.Tanim = (await _egitim_TanimlaService.GetAllAsync()).Data.Count;


            if (result.ResultStatus == ResultStatus.Success)
            {
                ViewBag.EgitimKonuAltBaslikListe = (await _egitim_konu_AltBaslikService.GetAllAsync()).Data;
                ViewBag.IsgKurulListe = (await _isg_KurulService.GetAllAsync()).Data;
                return View(result.Data);
            }

            return View();
        }


        // GET: Egitim_Tanimla/Create
        [Route("Olustur")]
        public async Task<IActionResult> Create()
        {
            ViewBag.EgitimKonu = (await _egitim_KonuService.GetAllAsync()).Data;
            ViewBag.EgitimKonuAltBaslik = (await _egitim_konu_alt_BaslikService.GetAllAsync()).Data;


            var result1 = await _egitim_konu_alt_BaslikService.GetAllAsync();
            ViewBag.Egitim_Konu_Alt_Baslik_Id = new SelectList(result1.Data, "Id", "Alt_Baslik_Ad");
            var result2 = await _isg_KurulService.GetAllAsync();
            ViewBag.Isg_Kurul_Id = new SelectList(result2.Data, "Id", "Kurul_Ad");
            var result3 = await _isverenService.GetAllAsync();
            ViewBag.Isveren_Id = new SelectList(result3.Data, "Id", "Isveren_Ad");

            var result4 = await _personel_BilgiService.GetAllAsync(currentKurul);
            if (result4.ResultStatus == ResultStatus.Success)
                ViewBag.Personel_Id = new SelectList(result4.Data, "Id", "Ad_Soyad");

            return View();
        }

        // POST: Egitim_Tanimla/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        public async Task<IActionResult> Create(Egitim_TanimlaDTO egitimTanimla, long Id,String description,String[] names,Egitim_Tanim_KonuDTO egitim_Tanim_KonuDTO)
        {
            if (ModelState.IsValid)
            {
                var resultObject = (await _birimService.GetAsync(currentKurul)).Data.Isg_Kurul_Id;
                egitimTanimla.Isg_Kurul_Id = resultObject;
                var result = await _egitim_TanimlaService.AddAndGetAsync(egitimTanimla, 1);
                egitim_Tanim_KonuDTO.Egitim_Tanimla_Id = result.Data.Id;
                for (int i=0;i<names.Length ; i++)
                {
                    egitim_Tanim_KonuDTO.Egitim_Konu_Alt_Baslik_Id = Convert.ToInt64(names[i]);
                    await _egitim_Tanim_KonuService.AddAsync(egitim_Tanim_KonuDTO,1);
                }
       
                if (result.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                }
                else
                {
                    var result1 = await _egitim_konu_alt_BaslikService.GetAllAsync();
                    ViewBag.Egitim_Konu_Alt_Baslik_Id = new SelectList(result1.Data, "Id", "Alt_Baslik_Ad");
                    var result2 = await _isg_KurulService.GetAllAsync();
                    ViewBag.Isg_Kurul_Id = new SelectList(result2.Data, "Id", "Kurul_Ad");
                    var result3 = await _isverenService.GetAllAsync();
                    ViewBag.Isveren_Id = new SelectList(result3.Data, "Id", "Isveren_Ad");
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = result.Message;
                    return View();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Egitim_Tanimla
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.EgitimKonu = (await _egitim_KonuService.GetAllAsync()).Data;
            ViewBag.EgitimKonuAltBaslik = (await _egitim_konu_alt_BaslikService.GetAllAsync()).Data;
            var result = await _egitim_TanimlaService.GetAsync(id);

            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _egitim_konu_alt_BaslikService.GetAllAsync();
                ViewBag.Egitim_Konu_Alt_Baslik_Id = new SelectList(result1.Data, "Id", "Alt_Baslik_Ad");
                var result2 = await _isg_KurulService.GetAllAsync();
                ViewBag.Isg_Kurul_Id = new SelectList(result2.Data, "Id", "Kurul_Ad");
                var result3 = await _isverenService.GetAllAsync();
                ViewBag.Isveren_Id = new SelectList(result3.Data, "Id", "Isveren_Ad");
                return View(result.Data);
            }


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id, Egitim_TanimlaDTO egitimTanimla)
        {
            ViewBag.EgitimKonu = (await _egitim_KonuService.GetAllAsync()).Data;
            ViewBag.EgitimKonuAltBaslik = (await _egitim_konu_alt_BaslikService.GetAllAsync()).Data;
            var result = await _egitim_TanimlaService.GetAsync(id);
            if (result != null)
            {
                egitimTanimla.Isg_Kurul_Id = result.Data.Isg_Kurul_Id;
                var birimResult = await _egitim_TanimlaService.UpdateAsync(egitimTanimla, 2);

                if (birimResult.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = birimResult.Message;
                    return RedirectToAction("Index");
                }
                else
                {
                    var result1 = await _egitim_konu_alt_BaslikService.GetAllAsync();
                    ViewBag.Egitim_Konu_Alt_Baslik_Id = new SelectList(result1.Data, "Id", "Alt_Baslik_Ad");
                    var result2 = await _isg_KurulService.GetAllAsync();
                    ViewBag.Isg_Kurul_Id = new SelectList(result2.Data, "Id", "Kurul_Ad");
                    var result3 = await _isverenService.GetAllAsync();
                    ViewBag.Isveren_Id = new SelectList(result3.Data, "Id", "Isveren_Ad");
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = birimResult.Message;
                    return View();
                }
              
            }
            else
            {
                var result1 = await _egitim_konu_alt_BaslikService.GetAllAsync();
                ViewBag.Egitim_Konu_Alt_Baslik_Id = new SelectList(result1.Data, "Id", "Alt_Baslik_Ad");
                var result2 = await _isg_KurulService.GetAllAsync();
                ViewBag.Isg_Kurul_Id = new SelectList(result2.Data, "Id", "Kurul_Ad");
                var result3 = await _isverenService.GetAllAsync();
                ViewBag.Isveren_Id = new SelectList(result3.Data, "Id", "Isveren_Ad");
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return View();
        }

        // GET: Egitim_Tanimla
        [Route("Detaylar")]
        public async Task<IActionResult> Details(int id)
        {
            var result4 = await _egitim_TanimlaService.GetAsync(id);
            
            ViewBag.EgitimKonu = (await _egitim_KonuService.GetAllAsync()).Data;
            ViewBag.EgitimKonuAltBaslik = (await _egitim_konu_alt_BaslikService.GetAllAsync()).Data;
            var result = await _egitim_TanimlaService.GetAsync(id);

            ViewBag.EgitimVerenList = (await _egitim_veren_PersonelService.GetAllEgitimVeren(id)).Data;
            ViewBag.EgitimeGirecekListe = (await _egitim_Personel_AtamaService.GetPersonel(id)).Data;
            ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;

            ViewBag.EgitimTanimKonu = (await _egitim_Tanim_KonuService.GetEgitimAsync(id)).Data;

            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _egitim_konu_alt_BaslikService.GetAllAsync();
                ViewBag.Egitim_Konu_Alt_Baslik_Id = new SelectList(result1.Data, "Id", "Alt_Baslik_Ad");
                var result2 = await _isg_KurulService.GetAllAsync();
                ViewBag.Isg_Kurul_Id = new SelectList(result2.Data, "Id", "Kurul_Ad");
                var result3 = await _isverenService.GetAllAsync();
                ViewBag.Isveren_Id = new SelectList(result3.Data, "Id", "Isveren_Ad");
                return View(result.Data);
            }


            return View();
        }
        // GET: Egitim_Tanimla/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Sil")]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _egitim_TanimlaService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }

        // GET: Egitim_Tanimla
        [Route("PersonelAta")]
        public async Task<IActionResult> PersonelAta(int id)
        {
            var result = await _egitim_Personel_AtamaService.GetAllAsync();
            ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
            ViewBag.EgitimVerenPersonelList = (await _egitim_veren_PersonelService.GetAllAsync()).Data;

            TempData["id"] = id;
            //var result5= await _egitim_Personel_AtamaService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                //ViewBag.deneme = result5.Data.Egitim_Tanimla_Id;
                ViewBag.egitimTanimId = id;
                var result1 = await _egitim_konu_alt_BaslikService.GetAllAsync();
                ViewBag.Egitim_Konu_Alt_Baslik_Id = new SelectList(result1.Data, "Id", "Alt_Baslik_Ad");
                var result2 = await _isg_KurulService.GetAllAsync();
                ViewBag.Isg_Kurul_Id = new SelectList(result2.Data, "Id", "Kurul_Ad");
                var result3 = await _isverenService.GetAllAsync();
                ViewBag.Isveren_Id = new SelectList(result3.Data, "Id", "Isveren_Ad");
                var talibirimResult = await _tali_BirimService.GetAllAsync(currentKurul);
                if (talibirimResult.ResultStatus == ResultStatus.Success)
                {
                    ViewBag.Tali_Birim_Id = new SelectList(talibirimResult.Data.ToList(), "Id", "Tali_Birim_Ad");
                }


                var result4 = await _personel_BilgiService.GetAllAsync(currentKurul);

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
            var result = await _egitim_Personel_AtamaService.GetAllAsync();
            ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
            ViewBag.EgitimVerenPersonelList = (await _egitim_veren_PersonelService.GetAllAsync()).Data;

            //var result5= await _egitim_Personel_AtamaService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                ViewBag.talibirimId = personel.Tali_Birim_Id;
                ViewBag.egitimTanimId = TempData["id"];

                var egitimTanimId=Convert.ToInt64(TempData["id"]);



                var personelAtama2 = (await _egitim_Personel_AtamaService.GetEgitimAsync(egitimTanimId)).Data;
                var personelListe2 = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;

                List<long> personelListe3= new List<long>();

                foreach (var item in personelListe2)
                {
                    personelListe3.Add(item.Id);
                };
                List<long> personelAtama3= new List<long>();

                foreach (var item in personelAtama2)
                {
                    personelAtama3.Add(item.Personel_Id);
                };
                ViewBag.liste = personelListe3.Except(personelAtama3).ToList();
 
                var talibirimResult = await _tali_BirimService.GetAllAsync(currentKurul);

                if (talibirimResult.ResultStatus == ResultStatus.Success)
                {
                    ViewBag.Tali_Birim_Id = new SelectList(talibirimResult.Data.ToList(), "Id", "Tali_Birim_Ad");
                }
                return View(result.Data);
            }
            return View();
        }

        [Route("PersonelEkle")]
        public async Task<IActionResult> PersonelEkle(Egitim_Personel_AtamaDTO personel, long id,string[] names)
        {
            var result = await _egitim_Personel_AtamaService.GetAllAsync();

            if (result.ResultStatus == ResultStatus.Success)
            {
                ViewBag.egitimTanimId = TempData["id"];
                personel.Id = 0;
                personel.Sertifika_Basildi = true;
                personel.Egitime_Katilim = 1;
                personel.Egitim_Tanimla_Id = Convert.ToInt64(TempData["id"].ToString());

                for(int i = 0; i < names.Length; i++)
                {
                    personel.Personel_Id =Convert.ToInt64(names[i]);
                    await _egitim_Personel_AtamaService.AddAsync(personel, 1);
                }

                var result1 = await _egitim_konu_alt_BaslikService.GetAllAsync();
                ViewBag.Egitim_Konu_Alt_Baslik_Id = new SelectList(result1.Data, "Id", "Alt_Baslik_Ad");
                var result2 = await _isg_KurulService.GetAllAsync();
                ViewBag.Isg_Kurul_Id = new SelectList(result2.Data, "Id", "Kurul_Ad");
                var result3 = await _isverenService.GetAllAsync();
                ViewBag.Isveren_Id = new SelectList(result3.Data, "Id", "Isveren_Ad");
                var talibirimResult = await _tali_BirimService.GetAllAsync(currentKurul);

                result = await _egitim_Personel_AtamaService.GetAllAsync();

                if (talibirimResult.ResultStatus == ResultStatus.Success)
                {
                    ViewBag.Tali_Birim_Id = new SelectList(talibirimResult.Data.ToList(), "Id", "Tali_Birim_Ad");
                }
                ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
                ViewBag.EgitimVerenPersonelList = (await _egitim_veren_PersonelService.GetAllAsync()).Data;
                return View(result.Data);
            }
            return View();
        }


        [Route("PersonelCikar")]
        public async Task<IActionResult> PersonelCikar(long id,string[] Ids)
        {
            var result = await _egitim_Personel_AtamaService.GetAllAsync();
            ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
            ViewBag.EgitimVerenPersonelList = (await _egitim_veren_PersonelService.GetAllAsync()).Data;
            if (result.ResultStatus == ResultStatus.Success)
            {
                ViewBag.egitimTanimId = TempData["id"];
                for (int i = 0; i < Ids.Length; i++)
                {
                    await _egitim_Personel_AtamaService.DeleteAsync(Convert.ToInt64(Ids[i]),1);
                }
       

                var result1 = await _egitim_konu_alt_BaslikService.GetAllAsync();
                ViewBag.Egitim_Konu_Alt_Baslik_Id = new SelectList(result1.Data, "Id", "Alt_Baslik_Ad");
                var result2 = await _isg_KurulService.GetAllAsync();
                ViewBag.Isg_Kurul_Id = new SelectList(result2.Data, "Id", "Kurul_Ad");
                var result3 = await _isverenService.GetAllAsync();
                ViewBag.Isveren_Id = new SelectList(result3.Data, "Id", "Isveren_Ad");
                var talibirimResult = await _tali_BirimService.GetAllAsync(currentKurul);

                result = await _egitim_Personel_AtamaService.GetAllAsync();

                if (talibirimResult.ResultStatus == ResultStatus.Success)
                {
                    ViewBag.Tali_Birim_Id = new SelectList(talibirimResult.Data.ToList(), "Id", "Tali_Birim_Ad");
                }
                return View(result.Data);
            }
            return View();
        }


        [Route("EgitimVerenEkle")]
        public async Task<IActionResult> EgitimVerenEkle(Egitim_Veren_PersonelDTO personel, long id)
        {
            var result = await _egitim_Personel_AtamaService.GetAllAsync();


            var id2 = TempData["id"];
            if (result.ResultStatus == ResultStatus.Success)
            {
                ViewBag.egitimTanimId = TempData["id"];
                personel.Id = 0;
                personel.Personel_Id = id;
                personel.Egitim_Tanimla_Id = Convert.ToInt64(TempData["id"].ToString());
                personel.Isveren_Id = 2;
                var result5 = await _egitim_veren_PersonelService.AddAsync(personel, 1);

                var result1 = await _egitim_konu_alt_BaslikService.GetAllAsync();
                ViewBag.Egitim_Konu_Alt_Baslik_Id = new SelectList(result1.Data, "Id", "Alt_Baslik_Ad");
                var result2 = await _isg_KurulService.GetAllAsync();
                ViewBag.Isg_Kurul_Id = new SelectList(result2.Data, "Id", "Kurul_Ad");
                var result3 = await _isverenService.GetAllAsync();
                ViewBag.Isveren_Id = new SelectList(result3.Data, "Id", "Isveren_Ad");
                var talibirimResult = await _tali_BirimService.GetAllAsync(currentKurul);

                result = await _egitim_Personel_AtamaService.GetAllAsync();

                if (talibirimResult.ResultStatus == ResultStatus.Success)
                {
                    ViewBag.Tali_Birim_Id = new SelectList(talibirimResult.Data.ToList(), "Id", "Tali_Birim_Ad");
                }
                ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
                ViewBag.EgitimVerenPersonelList = (await _egitim_veren_PersonelService.GetAllAsync()).Data;
                return View(result.Data);
            }
            return View();
        }

        [Route("EgitimVerenCikar")]
        public async Task<IActionResult> EgitimVerenCikar(long id)
        {
            var result = await _egitim_Personel_AtamaService.GetAllAsync();

            if (result.ResultStatus == ResultStatus.Success)
            {
                ViewBag.egitimTanimId = TempData["id"];
                var resultEgitim= await _egitim_veren_PersonelService.HardDeleteAsync(id);
                if (resultEgitim.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = resultEgitim.Message;
                }
                var result1 = await _egitim_konu_alt_BaslikService.GetAllAsync();
                ViewBag.Egitim_Konu_Alt_Baslik_Id = new SelectList(result1.Data, "Id", "Alt_Baslik_Ad");
                var result2 = await _isg_KurulService.GetAllAsync();
                ViewBag.Isg_Kurul_Id = new SelectList(result2.Data, "Id", "Kurul_Ad");
                var result3 = await _isverenService.GetAllAsync();
                ViewBag.Isveren_Id = new SelectList(result3.Data, "Id", "Isveren_Ad");
                var talibirimResult = await _tali_BirimService.GetAllAsync(currentKurul);

                result = await _egitim_Personel_AtamaService.GetAllAsync();

                if (talibirimResult.ResultStatus == ResultStatus.Success)
                {
                    ViewBag.Tali_Birim_Id = new SelectList(talibirimResult.Data.ToList(), "Id", "Tali_Birim_Ad");
                }
                ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
                ViewBag.EgitimVerenPersonelList = (await _egitim_veren_PersonelService.GetAllAsync()).Data;
                result = await _egitim_Personel_AtamaService.GetAllAsync();
                return View(result.Data);
            }
            return View();
        }

        public async Task<JsonResult> EditCustomer([FromBody] Egitim_Personel_AtamaDTO cust)
        {

            var result = await _egitim_TanimlaService.GetAsync(cust.Id);

            return Json(result);
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        [Route("TarihBirSonraki")]
        public async Task<JsonResult> TarihBirSonraki(int id)
        {
            var result = await _egitim_TanimlaService.GetAsync(id);
            var resultObject = result.Data.Egitim_Tarih.AddYears(1);
            
           // var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(resultObject);
        }


    }
}
