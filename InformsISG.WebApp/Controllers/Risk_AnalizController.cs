using FastReport;
using FastReport.Data;
using FastReport.Utils;
using InformsISG.Core.Utilities.Results;
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
    [Route("Risk/")]
    public class Risk_AnalizController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IRisk_AnalizService _risk_AnalizService;
        private readonly IBirimService _BirimService;
        private readonly ITali_BirimService _tali_BirimService;
        private readonly IRisk_YontemService _risk_YontemService;
        private readonly IRisk_Analiz_TabloService _risk_Analiz_TabloService;

        private readonly ITehlike_TanimService _tehlike_TanimService;
        private readonly IRisk_Analiz_RiskService _risk_Analiz_RiskService;
        private readonly IPersonel_BilgiService _personel_BilgiService;

        private readonly IRisk_KategoriService _risk_KategoriService;
        private readonly IRisk_Ust_GrupService _risk_ust_GrupService;
        private readonly IRisk_KonuGrupService _risk_Konu_GrupService;
        private readonly IRisk_KonuService _risk_KonuService;
        private readonly IRisk_KutuphaneService _risk_KutuphaneService;
        private readonly IDofService _dofService;
        private readonly IWebHostEnvironment _webHostEnvironment;



        public string TreeViewJSON { get; set; }


        public Risk_AnalizController(IRisk_AnalizService riskAnalizService,IBirimService birimService,ITali_BirimService taliBirimService,IRisk_YontemService riskYontemService,IRisk_Analiz_TabloService riskAnalizTabloService, ITehlike_TanimService tehlikeTanimService,IRisk_Analiz_RiskService riskAnalizRiskService,IPersonel_BilgiService personelBilgiService,IRisk_KategoriService riskKategoriService,IRisk_Ust_GrupService riskUstGrupService,IRisk_KonuGrupService riskKonuGrupService,IRisk_KonuService riskKonuService,IRisk_KutuphaneService riskKutuphaneService,IDofService dofService,IWebHostEnvironment webHostEnvironment)
        {
            _risk_AnalizService = riskAnalizService;
            _BirimService = birimService;
            _tali_BirimService = taliBirimService;
            _risk_YontemService = riskYontemService;
            _risk_Analiz_TabloService = riskAnalizTabloService;
            _tehlike_TanimService = tehlikeTanimService;
            _risk_Analiz_RiskService = riskAnalizRiskService;
            _personel_BilgiService = personelBilgiService;
            _risk_KategoriService = riskKategoriService;
            _risk_ust_GrupService = riskUstGrupService;
            _risk_Konu_GrupService = riskKonuGrupService;
            _risk_KonuService = riskKonuService;
            _risk_KutuphaneService = riskKutuphaneService;
            _dofService = dofService;
            _webHostEnvironment = webHostEnvironment;

        }

        // GET: RiskAnaliz
        [Route("Liste")]
        public async Task<IActionResult> Index()
        {
            var result = await _risk_AnalizService.GetAllAsync(currentKurul);
            ViewBag.Risk = (await _risk_AnalizService.GetAllAsync(currentKurul)).Data.Count;


            if (result.ResultStatus == ResultStatus.Success)
            {
                ViewBag.BirimList = (await _BirimService.GetAllAsync()).Data;
                ViewBag.TaliBirimList = (await _tali_BirimService.GetAllAsync(currentKurul)).Data;
                return View(result.Data);
            }
            return View();
        }


        // GET: RiskAnaliz/Create
        [Route("Olustur")]
        public async Task<IActionResult> Create()
        {
            var result = await _BirimService.GetAllAsync();
            if (result.ResultStatus == ResultStatus.Success)
                ViewBag.Birim_Id = new SelectList(result.Data, "Id", "Birim_Ad");
            var result2 = await _tali_BirimService.GetAllAsync(currentKurul);
            if (result2.ResultStatus == ResultStatus.Success)
                ViewBag.Tali_Birim_Id = new SelectList(result2.Data, "Id", "Tali_Birim_Ad");        
            var result3 = await _risk_YontemService.GetAllAsync();
            if (result3.ResultStatus == ResultStatus.Success)
                ViewBag.Risk_Yontem_Id = new SelectList(result3.Data, "Id", "Risk_Yontem_Ad");    
            var result4 = await _personel_BilgiService.GetAllAsync(currentKurul);
            if (result4.ResultStatus == ResultStatus.Success)
                ViewBag.Personel_Id = new SelectList(result4.Data, "Id", "Ad_Soyad");    
            var result5 = await _risk_KategoriService.GetAllAsync();
            if (result5.ResultStatus == ResultStatus.Success)
                ViewBag.Risk_Kategori_Id = new SelectList(result5.Data, "Id", "Risk_Kategori_Ad");

            return View();
        }


        public async Task OnGetAsync()
        {
            List<TreeViewNodeDTO> nodes = new List<TreeViewNodeDTO>();
            var result1 = await _risk_KategoriService.GetAllAsync();
            //Loop and add the Parent Nodes.
            foreach (Risk_KategoriDTO type in result1.Data)
            {
                nodes.Add(new TreeViewNodeDTO { id = type.Id.ToString(), parent = "#", text = type.Risk_Kategori_Ad });
            }
            var result2 = await _risk_ust_GrupService.GetAllAsync();
            foreach(Risk_Ust_GrupDTO subType in result2.Data)
            {
                nodes.Add(new TreeViewNodeDTO { id = subType.Risk_Kategori_Id.ToString() + "-" + subType.Id.ToString(), parent = subType.Risk_Kategori_Id.ToString(), text = subType.Risk_Ust_Grup_Adi });
            }

            //Serialize to JSON string.
            ViewBag.Json = JsonConvert.SerializeObject(nodes);
        }
        public void OnPostSubmit(string selectedItems)
        {
            List<TreeViewNodeDTO> items = JsonConvert.DeserializeObject<List<TreeViewNodeDTO>>(selectedItems);
        }
        // POST: RiskAnaliz/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        public async Task<IActionResult> Create(IFormFile Dosya,Risk_AnalizDTO riskanaliz,string kutuphaneKategori,string kutuphaneUstGrup,string kutuphaneKonuGrup, string[] kutuphaneKonu,Risk_KutuphaneDTO kutuphaneDTO)
        {
            var result2 = await _tali_BirimService.GetAllAsync(currentKurul);
            if (result2.ResultStatus == ResultStatus.Success)
                ViewBag.Tali_Birim_Id = new SelectList(result2.Data, "Id", "Tali_Birim_Ad");
            var result3 = await _risk_YontemService.GetAllAsync();
            if (result3.ResultStatus == ResultStatus.Success)
                ViewBag.Risk_Yontem_Id = new SelectList(result3.Data, "Id", "Risk_Yontem_Ad");
            var result4 = await _personel_BilgiService.GetAllAsync(currentKurul);
            if (result4.ResultStatus == ResultStatus.Success)
                ViewBag.Personel_Id = new SelectList(result4.Data, "Id", "Ad_Soyad");
            var result5 = await _risk_KategoriService.GetAllAsync();
            if (result5.ResultStatus == ResultStatus.Success)
                ViewBag.Risk_Kategori_Id = new SelectList(result5.Data, "Id", "Risk_Kategori_Ad");
            Guid guid = Guid.NewGuid();
            var resultObject = (await _BirimService.GetAsync(currentKurul)).Data.Isg_Kurul_Id;
            riskanaliz.Isg_Kurul_Id = resultObject;
            var filePaths = new List<string>();

            if(Dosya != null)
            {
                if (Dosya.Length > 0)
                {
                    riskanaliz.Id = 0;
                    riskanaliz.Dosya = Dosya.FileName;
                    var path = Path.GetExtension(riskanaliz.Dosya);
                    var type = guid.ToString() + path;
                    var filePath = "wwwroot/Dosya/Risk/" + type;
                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Dosya.CopyToAsync(stream);
                    }
                    riskanaliz.Dosya = filePath;
                    riskanaliz.Id = 0;
                    var result = await _risk_AnalizService.AddAndGetAsync(riskanaliz, 1);

                    //Kutuphane baslangic
                    kutuphaneDTO.Id = 0;
                    kutuphaneDTO.Risk_Analiz_Id = result.Data.Id;
                    kutuphaneDTO.Risk_Kategori_Id = Convert.ToInt64(kutuphaneKategori);
                    kutuphaneDTO.Risk_Ust_Grup_Id = Convert.ToInt64(kutuphaneUstGrup);
                    kutuphaneDTO.Risk_Konu_Grup_Id = Convert.ToInt64(kutuphaneKonuGrup);

                    foreach (var item in kutuphaneKonu)
                    {
                        kutuphaneDTO.Risk_Konu_Id = Convert.ToInt64(item);
                        await _risk_KutuphaneService.AddAsync(kutuphaneDTO, 1);
                    }


                    if (result.ResultStatus == ResultStatus.Success)
                    {
                        TempData["MessageIcon"] = "success";
                        TempData["MessageText"] = "Risk Analiz başarılı bir şekilde eklenmiştir";
                        return RedirectToAction("Index");
                    }
                    else
                    {
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
            else
            {
                riskanaliz.Id = 0;
                var result = await _risk_AnalizService.AddAndGetAsync(riskanaliz, 1);

                //Kutuphane baslangic
                kutuphaneDTO.Id = 0;
                kutuphaneDTO.Risk_Analiz_Id = result.Data.Id;
                kutuphaneDTO.Risk_Kategori_Id = Convert.ToInt64(kutuphaneKategori);
                kutuphaneDTO.Risk_Ust_Grup_Id = Convert.ToInt64(kutuphaneUstGrup);
                kutuphaneDTO.Risk_Konu_Grup_Id = Convert.ToInt64(kutuphaneKonuGrup);

                foreach (var item in kutuphaneKonu)
                {
                    kutuphaneDTO.Risk_Konu_Id = Convert.ToInt64(item);
                    await _risk_KutuphaneService.AddAsync(kutuphaneDTO, 1);
                }


                if (result.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = "Risk Analiz başarılı bir şekilde eklenmiştir";
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

        // GET: RiskAnaliz/Edit/5
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id)
        {

            ViewBag.BirimList = (await _BirimService.GetAllAsync()).Data;
            ViewBag.TaliBirimList = (await _tali_BirimService.GetAllAsyncTum()).Data;


            ViewBag.RiskAnalizTabloList = (await _risk_Analiz_TabloService.GetAllAsync()).Data;
            ViewBag.TehlikeList = (await _tehlike_TanimService.GetAllAsync()).Data;
            ViewBag.RiskAnalizList = (await _risk_Analiz_RiskService.GetAllAsync()).Data;
            ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
            ViewBag.RiskAnalizSelect = (await _risk_AnalizService.GetAsync(id)).Data.Risk_Yontem_Id;
            ViewBag.RiskAnalizId = id;
            TempData["RiskAnalizId"] = id;

            var result4 = await _BirimService.GetAllAsync();
            if (result4.ResultStatus == ResultStatus.Success)
                ViewBag.Birim_Id = new SelectList(result4.Data, "Id", "Birim_Ad");
            var result5 = await _tali_BirimService.GetAllAsync(currentKurul);
            if (result5.ResultStatus == ResultStatus.Success)
                ViewBag.Tali_Birim_Id = new SelectList(result5.Data, "Id", "Tali_Birim_Ad");

            var result1 = await _tehlike_TanimService.GetAllAsync();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Tehlike_Tanim_Id = new SelectList(result1.Data, "Id", "Tehlike_Tanim_Ad");
            var result2 = await _risk_Analiz_RiskService.GetAllAsync();
            if (result2.ResultStatus == ResultStatus.Success)
                ViewBag.Risk_Analiz_Id = new SelectList(result2.Data, "Id", "Risk");
            var result3 = await _personel_BilgiService.GetAllAsync(currentKurul);
            if (result3.ResultStatus == ResultStatus.Success)
                ViewBag.Personel_Id = new SelectList(result3.Data, "Id", "Ad_Soyad");
            
            return View();
        }

        // GET: RiskAnaliz/Edit/5
        [Route("Detaylar")]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _risk_AnalizService.GetAsync(id);

            var result5 = await _risk_KategoriService.GetAllAsync();
            if (result5.ResultStatus == ResultStatus.Success)
                ViewBag.Risk_Kategori_Id = new SelectList(result5.Data, "Id", "Risk_Kategori_Ad");

            ViewBag.KutuphaneServis = (await _risk_KutuphaneService.GetAllRiskAsync(id)).Data;
            ViewBag.KutuphaneKonu = (await _risk_KonuService.GetAllAsync()).Data;
            return View(result.Data);
        }
        // GET: RiskAnaliz/Edit/5
        [Route("DuzenleRisk")]
        public async Task<IActionResult> EditKutuphaneKonu(int id)
        {
            TempData["id"] = id;
            var result = await _risk_AnalizService.GetAsync(id);
            var result5 = await _risk_KategoriService.GetAllAsync();
            if (result5.ResultStatus == ResultStatus.Success)
                ViewBag.Risk_Kategori_Id = new SelectList(result5.Data, "Id", "Risk_Kategori_Ad");

            ViewBag.KutuphaneServis = (await _risk_KutuphaneService.GetAllRiskAsync(id)).Data;
            ViewBag.KutuphaneKonu = (await _risk_KonuService.GetAllAsync()).Data;
    
            return View(result.Data);
        }

        [Route("KutuphaneKonuCikar")]
        public async Task<IActionResult> DeleteKutuphaneKonu(long id, string[] Ids)
        {
            var silinme = 0;
            var riskAnalizId = (await _risk_KutuphaneService.GetAsync(Convert.ToInt32(TempData["id"]))).Data.Risk_Analiz_Id;
            var result = await _risk_AnalizService.GetAsync(riskAnalizId);

            var result5 = await _risk_KategoriService.GetAllAsync();
            if (result5.ResultStatus == ResultStatus.Success)
                ViewBag.Risk_Kategori_Id = new SelectList(result5.Data, "Id", "Risk_Kategori_Ad");

            ViewBag.egitimTanimId = TempData["id"];
                for (int i = 0; i < Ids.Length; i++)
                {
                    await _risk_KutuphaneService.DeleteAsync(Convert.ToInt64(Ids[i]), 1);
                    silinme = 1;
                }
            result = await _risk_AnalizService.GetAsync(riskAnalizId);
            ViewBag.KutuphaneServis = (await _risk_KutuphaneService.GetAllRiskAsync(riskAnalizId)).Data;
            ViewBag.KutuphaneKonu = (await _risk_KonuService.GetAllAsync()).Data;
            if (silinme ==1)
            {
                TempData["MessageIcon"] = "success";
                TempData["MessageText"] = "Konular başarılı bir şekilde silinmiştir";
                return View(result.Data);

            }

            return View(result.Data);
        }


        // GET: RiskAnaliz/Edit/5
        [Route("DuzenleRisk")]
        [HttpPost]
        public async Task<IActionResult> EditKutuphaneKonu(int id, Risk_AnalizDTO riskanaliz, string kutuphaneKategori, string kutuphaneUstGrup, string kutuphaneKonuGrup, string[] kutuphaneKonu, Risk_KutuphaneDTO kutuphaneDTO)
        {
            var result = await _risk_AnalizService.GetAsync(id);
            kutuphaneDTO.Id = 0;
            kutuphaneDTO.Risk_Analiz_Id = result.Data.Id;
            kutuphaneDTO.Risk_Kategori_Id = Convert.ToInt64(kutuphaneKategori);
            kutuphaneDTO.Risk_Ust_Grup_Id = Convert.ToInt64(kutuphaneUstGrup);
            kutuphaneDTO.Risk_Konu_Grup_Id = Convert.ToInt64(kutuphaneKonuGrup);

            foreach (var item in kutuphaneKonu)
            {
                kutuphaneDTO.Risk_Konu_Id = Convert.ToInt64(item);
                await _risk_KutuphaneService.AddAsync(kutuphaneDTO, 1);
            }
            var result5 = await _risk_KategoriService.GetAllAsync();
            if (result5.ResultStatus == ResultStatus.Success)
                ViewBag.Risk_Kategori_Id = new SelectList(result5.Data, "Id", "Risk_Kategori_Ad");

            ViewBag.KutuphaneServis = (await _risk_KutuphaneService.GetAllRiskAsync(id)).Data;
            ViewBag.KutuphaneKonu = (await _risk_KonuService.GetAllAsync()).Data;
            if (result.ResultStatus == ResultStatus.Success)
            {
                TempData["MessageIcon"] = "success";
                TempData["MessageText"] = "Konular başarılı bir şekilde eklenmiştir";
                return View(result.Data);

            }
            return View(result.Data);
        }


        // POST: RiskAnaliz/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id,Risk_AnalizDTO riskAnaliz)
        {

            var result4 = await _BirimService.GetAllAsync();
            if (result4.ResultStatus == ResultStatus.Success)
                ViewBag.Birim_Id = new SelectList(result4.Data, "Id", "Birim_Ad");
            var result5 = await _tali_BirimService.GetAllAsyncTum();
            if (result5.ResultStatus == ResultStatus.Success)
                ViewBag.Tali_Birim_Id = new SelectList(result5.Data, "Id", "Tali_Birim_Ad");
            ViewBag.RiskAnalizTabloList = (await _risk_Analiz_TabloService.GetAllAsync()).Data;
            ViewBag.TehlikeList = (await _tehlike_TanimService.GetAllAsync()).Data;
            ViewBag.RiskAnalizList = (await _risk_Analiz_RiskService.GetAllAsync()).Data;
            ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
            ViewBag.RiskAnalizId = id;
            TempData["RiskAnalizId"] = id;
            var result1 = await _tehlike_TanimService.GetAllAsync();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Tehlike_Tanim_Id = new SelectList(result1.Data, "Id", "Tehlike_Tanim_Ad");
            var result2 = await _risk_Analiz_RiskService.GetAllAsync();
            if (result2.ResultStatus == ResultStatus.Success)
                ViewBag.Risk_Analiz_Id = new SelectList(result2.Data, "Id", "Risk");
            var result3 = await _personel_BilgiService.GetAllAsync(currentKurul);
            if (result3.ResultStatus == ResultStatus.Success)
                ViewBag.Personel_Id = new SelectList(result3.Data, "Id", "Ad_Soyad");

            var result = await _risk_AnalizService.GetAsync(id);

            if (result != null)
            {
                riskAnaliz.Isg_Kurul_Id = result.Data.Isg_Kurul_Id;
                riskAnaliz.Dosya = result.Data.Dosya;
                var birimResult = await _risk_AnalizService.UpdateAsync(riskAnaliz, 2);

                if (birimResult.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = birimResult.Message;
                    return RedirectToAction("Index");
                }
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = birimResult.Message;
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            
            return View();
        }


        [Route("TabloDuzenle")]
        public async Task<IActionResult> EditTablo(int id)
        {

            ViewBag.TehlikeList = (await _tehlike_TanimService.GetAllAsync()).Data;
            ViewBag.RiskAnalizList = (await _risk_Analiz_RiskService.GetAllAsync()).Data;
            ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
            ViewBag.RiskAnalizSelect = (await _risk_Analiz_TabloService.GetAsync(id)).Data;
            ViewBag.RiskAnalizId = id;
            TempData["RiskAnalizId"] = id;
            ViewBag.RiskAnalizTabloList = (await _risk_Analiz_TabloService.GetAllAsync()).Data;
            var result3 = await _personel_BilgiService.GetAllAsync(currentKurul);
            if (result3.ResultStatus == ResultStatus.Success)
                ViewBag.Personel_Id = new SelectList(result3.Data, "Id", "Ad_Soyad");

            var result4 = await _BirimService.GetAllAsync();
            if (result4.ResultStatus == ResultStatus.Success)
                ViewBag.Birim_Id = new SelectList(result4.Data, "Id", "Birim_Ad");
            var result5 = await _tali_BirimService.GetAllAsyncTum();
            if (result5.ResultStatus == ResultStatus.Success)
                ViewBag.Tali_Birim_Id = new SelectList(result5.Data, "Id", "Tali_Birim_Ad");

            var result = await _risk_Analiz_TabloService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                 return View(result.Data);
            }

            return View();
        }

        // POST: RiskAnaliz/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TabloDuzenle")]
        public async Task<IActionResult> EditTablo(int id, IFormFile Resim, Risk_Analiz_TabloDTO riskAnalizTablo,DofDTO dofDTO)
        {
            ViewBag.RiskAnalizId = TempData["RiskAnalizId"];
            TempData["RiskAnalizId"] = TempData["RiskAnalizId"];
            riskAnalizTablo.Risk_Seviye2 = "e";

            var resultObject = await _risk_AnalizService.GetAsync(Convert.ToInt64(TempData["RiskAnalizId"]));

            if (resultObject.Data.Risk_Yontem_Id == 1)
            {
                if (riskAnalizTablo.Olasilik1 == 0)
                {
                    riskAnalizTablo.Olasilik1 = 0;
                }
                else if (riskAnalizTablo.Olasilik1 == 1)
                {
                    riskAnalizTablo.Olasilik1 = 0.2f;
                }
                else if (riskAnalizTablo.Olasilik1 == 2)
                {
                    riskAnalizTablo.Olasilik1 = 0.5f;
                }
                else if (riskAnalizTablo.Olasilik1 == 3)
                {
                    riskAnalizTablo.Olasilik1 = 1f;
                }
                else if (riskAnalizTablo.Olasilik1 == 4)
                {
                    riskAnalizTablo.Olasilik1 = 3f;
                }
                else if (riskAnalizTablo.Olasilik1 == 5)
                {
                    riskAnalizTablo.Olasilik1 = 6f;
                }
                else if (riskAnalizTablo.Olasilik1 == 6)
                {
                    riskAnalizTablo.Olasilik1 = 10f;
                }

                if (riskAnalizTablo.Frekans1 == 0)
                {
                    riskAnalizTablo.Frekans1 = 0;
                }
                else if (riskAnalizTablo.Frekans1 == 1)
                {
                    riskAnalizTablo.Frekans1 = 0.5f;
                }
                else if (riskAnalizTablo.Frekans1 == 2)
                {
                    riskAnalizTablo.Frekans1 = 1f;
                }
                else if (riskAnalizTablo.Frekans1 == 3)
                {
                    riskAnalizTablo.Frekans1 = 2f;
                }
                else if (riskAnalizTablo.Frekans1 == 4)
                {
                    riskAnalizTablo.Frekans1 = 3f;
                }
                else if (riskAnalizTablo.Frekans1 == 5)
                {
                    riskAnalizTablo.Frekans1 = 6f;
                }
                else if (riskAnalizTablo.Frekans1 == 6)
                {
                    riskAnalizTablo.Frekans1 = 10f;
                }


                if (riskAnalizTablo.Siddet1 == 0)
                {
                    riskAnalizTablo.Siddet1 = 0;
                }
                else  if (riskAnalizTablo.Siddet1 == 1)
                {
                    riskAnalizTablo.Siddet1 = 1f;
                }
                else if (riskAnalizTablo.Siddet1 == 2)
                {
                    riskAnalizTablo.Siddet1 = 3f;
                }
                else if (riskAnalizTablo.Siddet1 == 3)
                {
                    riskAnalizTablo.Siddet1 = 7f;
                }
                else if (riskAnalizTablo.Siddet1 == 4)
                {
                    riskAnalizTablo.Siddet1 = 15f;
                }
                else if (riskAnalizTablo.Siddet1 == 5)
                {
                    riskAnalizTablo.Siddet1 = 40f;
                }
                else if (riskAnalizTablo.Siddet1 == 6)
                {
                    riskAnalizTablo.Siddet1 = 100f;
                }

                riskAnalizTablo.Risk_Puan1 = riskAnalizTablo.Olasilik1 * riskAnalizTablo.Frekans1 * riskAnalizTablo.Siddet1;

                riskAnalizTablo.Olasilik2 =0;
                riskAnalizTablo.Siddet2 = 0;
                riskAnalizTablo.Frekans2 = 0;
                riskAnalizTablo.Risk_Puan2 = 0;

                if (riskAnalizTablo.Risk_Puan1 <= 20)
                {
                    riskAnalizTablo.Risk_Seviye1 = "ÖNEMSİZ RİSK(Önlem öncelikli değildir)";
                }
                else if (riskAnalizTablo.Risk_Puan1 > 21 && riskAnalizTablo.Risk_Puan2 <= 70)
                {
                    riskAnalizTablo.Risk_Seviye1 = "OLASI RİSK(Gözetim altında uygulanmalıdır)";
                }
                else if (riskAnalizTablo.Risk_Puan1 > 70 && riskAnalizTablo.Risk_Puan1 <= 200)
                {
                    riskAnalizTablo.Risk_Seviye1 = "ÖNEMLİ RİSK(Uzun dönemde iyileştirilmelidir.Yıl içerisinde)";
                }
                else if (riskAnalizTablo.Risk_Puan1 > 200 && riskAnalizTablo.Risk_Puan1 <= 400)
                {
                    riskAnalizTablo.Risk_Seviye1 = "ÇOK ÖNEMLİ RİSK(Kısa dönemde iyileştirilmelidir.Birkaç ay içinde)";
                }
                else if (riskAnalizTablo.Risk_Puan1 > 400)
                {
                    riskAnalizTablo.Risk_Seviye1 = "TOLERANS  GÖSTERİLEMEZ RİSK.(Hemen gerekli önlemler alınmalı veya işin durdurulması düşünülmelidir.)";
                }


            }
            else
            {
                riskAnalizTablo.Olasilik1 = 0;
                riskAnalizTablo.Siddet1 = 0;
                riskAnalizTablo.Frekans1 = 0;
                riskAnalizTablo.Risk_Puan1 = 0;




                if (riskAnalizTablo.Olasilik2 == 0)
                {
                    riskAnalizTablo.Olasilik2 = 1f;
                }
                else if (riskAnalizTablo.Olasilik2 == 1)
                {
                    riskAnalizTablo.Olasilik2 = 2f;
                }
                else if (riskAnalizTablo.Olasilik2 == 2)
                {
                    riskAnalizTablo.Olasilik2 = 3f;
                }
                else if (riskAnalizTablo.Olasilik2 == 3)
                {
                    riskAnalizTablo.Olasilik2 = 4f;
                }
                else if (riskAnalizTablo.Olasilik2 == 4)
                {
                    riskAnalizTablo.Olasilik2 = 5f;
                }


                if (riskAnalizTablo.Siddet2 == 0)
                {
                    riskAnalizTablo.Siddet2 = 1f;
                }
                else if (riskAnalizTablo.Siddet2 == 1)
                {
                    riskAnalizTablo.Siddet2 = 2f;
                }
                else if (riskAnalizTablo.Siddet2 == 2)
                {
                    riskAnalizTablo.Siddet2 = 3f;
                }
                else if (riskAnalizTablo.Siddet2 == 3)
                {
                    riskAnalizTablo.Siddet2 = 4f;
                }
                else if (riskAnalizTablo.Siddet2 == 4)
                {
                    riskAnalizTablo.Siddet2 = 5f;
                }

                riskAnalizTablo.Risk_Puan2 = riskAnalizTablo.Olasilik2 * riskAnalizTablo.Siddet2;




                if (riskAnalizTablo.Risk_Puan2 <= 6)
                {
                    riskAnalizTablo.Risk_Seviye2 = "Düşük Risk Seviyesi";
                }
                else if (riskAnalizTablo.Risk_Puan2 > 6 && riskAnalizTablo.Risk_Puan2 <= 12)
                {
                    riskAnalizTablo.Risk_Seviye2 = "Orta Risk Seviyesi";
                }
                else if (riskAnalizTablo.Risk_Puan2 > 12)
                {
                    riskAnalizTablo.Risk_Seviye2 = "Yüksek Risk Seviyesi";
                }



            }

            ViewBag.RiskAnalizTabloList = (await _risk_Analiz_TabloService.GetAllAsync()).Data;
            ViewBag.TehlikeList = (await _tehlike_TanimService.GetAllAsync()).Data;
            ViewBag.RiskAnalizList = (await _risk_Analiz_RiskService.GetAllAsync()).Data;
            ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
            var result3 = await _personel_BilgiService.GetAllAsync(currentKurul);
            if (result3.ResultStatus == ResultStatus.Success)
                ViewBag.Personel_Id = new SelectList(result3.Data, "Id", "Ad_Soyad");

            riskAnalizTablo.Risk_Id = Convert.ToInt64(TempData["RiskAnalizId"]);
            riskAnalizTablo.Risk_Analiz_Id = 1;
            riskAnalizTablo.Tehlike_Tanim_Id = 1;
            Guid guid = Guid.NewGuid();
            var filePaths = new List<string>();

            var result4 = await _BirimService.GetAllAsync();
            if (result4.ResultStatus == ResultStatus.Success)
                ViewBag.Birim_Id = new SelectList(result4.Data, "Id", "Birim_Ad");
            var result5 = await _tali_BirimService.GetAllAsyncTum();
            if (result5.ResultStatus == ResultStatus.Success)
                ViewBag.Tali_Birim_Id = new SelectList(result5.Data, "Id", "Tali_Birim_Ad");

            if(Resim != null)
            {
                if (Resim.Length > 0)
                {
                    riskAnalizTablo.Resim = Resim.FileName;
                    var path = Path.GetExtension(riskAnalizTablo.Resim);
                    var type = guid.ToString() + path;
                    var filePath = "wwwroot/Dosya/RiskAnalizTablo/" + type;
                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Resim.CopyToAsync(stream);
                    }
                    riskAnalizTablo.Resim = filePath;
                    riskAnalizTablo.Id = 0;
                    var result = await _risk_Analiz_TabloService.AddAndGetAsync(riskAnalizTablo, 1);



                    //DOF KISMI
                    dofDTO.Id = 0;
                    dofDTO.Dof_Ad = riskAnalizTablo.Duzeltici_Faaliyet;
                    dofDTO.Dof_No = Convert.ToString(TempData["RiskAnalizId"]) + Convert.ToString(result.Data.Id);
                    dofDTO.Sorumlular = riskAnalizTablo.Sorumlular;
                    dofDTO.Birim_Id = riskAnalizTablo.Birim_Id;
                    dofDTO.Tali_Birim_Id = riskAnalizTablo.Tali_Birim_Id;
                    dofDTO.Isveren_Id = (await _BirimService.GetAsync(riskAnalizTablo.Birim_Id)).Data.Isveren_Id;
                    dofDTO.Isg_Kurul_Id = (await _BirimService.GetAsync(riskAnalizTablo.Birim_Id)).Data.Isg_Kurul_Id;
                    dofDTO.Dof_Acik = true;

                    var resultDof = await _dofService.AddAsync(dofDTO, 1);


                    if (result.ResultStatus == ResultStatus.Success)
                    {

                        TempData["MessageIcon"] = "success";
                        TempData["MessageText"] = "Tablo başarılı bir şekilde eklenmiştir";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["MessageIcon"] = "error";
                        TempData["MessageText"] = result.Message;
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                    }
                    return RedirectToAction("Index");
                }

            }
            else
            {
                    riskAnalizTablo.Id = 0;
                    var result = await _risk_Analiz_TabloService.AddAndGetAsync(riskAnalizTablo, 1);

                    //DOF KISMI
                    dofDTO.Id = 0;
                    dofDTO.Dof_Ad = riskAnalizTablo.Duzeltici_Faaliyet;
                    dofDTO.Dof_No = Convert.ToString(TempData["RiskAnalizId"]) + Convert.ToString(result.Data.Id);
                    dofDTO.Sorumlular = riskAnalizTablo.Sorumlular;
                    dofDTO.Birim_Id = riskAnalizTablo.Birim_Id;
                    dofDTO.Tali_Birim_Id = riskAnalizTablo.Tali_Birim_Id;
                    dofDTO.Isveren_Id = (await _BirimService.GetAsync(riskAnalizTablo.Birim_Id)).Data.Isveren_Id;
                    dofDTO.Isg_Kurul_Id = (await _BirimService.GetAsync(riskAnalizTablo.Birim_Id)).Data.Isg_Kurul_Id;
                    dofDTO.Dof_Acik = true;

                    var resultDof = await _dofService.AddAsync(dofDTO, 1);


                    if (result.ResultStatus == ResultStatus.Success)
                    {

                        TempData["MessageIcon"] = "success";
                        TempData["MessageText"] = "Tablo başarılı bir şekilde eklenmiştir";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["MessageIcon"] = "error";
                        TempData["MessageText"] = result.Message;
   
                    }
                    return RedirectToAction("Index");
                
            }



            return RedirectToAction("Index");
        }


        // POST: RiskAnaliz/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Sil")]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _risk_AnalizService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }    
        
        // POST: RiskAnaliz/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TabloSil")]
        public async Task<JsonResult> DeleteTablo(int id)
        {
            var result = await _risk_Analiz_TabloService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }

        [HttpPost]
        [Route("GetTaliBirim")]
        public async Task<JsonResult> GetTaliBirim(int id)
        {
            var result = await _tali_BirimService.GetAllTaliBirim(id);
            return Json(new SelectList(result.Data.ToList(), "Id", "Tali_Birim_Ad"));
        }

        [HttpPost]
        public async Task<JsonResult> Hesap(int id)
        {
            var yenideger = id;
            var frekans1 = id % 10;
            yenideger = id / 10;
            var olasilik1 = yenideger % 10;
             yenideger = yenideger / 10;
            var siddet1 = yenideger % 10;

            float olasilik = 1f;
            float siddet = 1;
            float frekans = 1;

            if (olasilik1 == 0)
            {
                olasilik = 0.2f;
            }
            else if (olasilik1 == 1)
            {
                olasilik = 0.5f;
            }
            else if (olasilik1 == 2)
            {
                olasilik = 1f;
            }
            else if (olasilik1 == 3)
            {
                olasilik = 3f;
            }
            else if (olasilik1 == 4)
            {
                olasilik = 6f;
            }
            else if (olasilik1 == 5)
            {
                olasilik = 10f;
            }

            if (frekans1 == 0)
            {
                frekans = 0.5f;
            }
            else if (frekans1 == 1)
            {
                frekans = 1f;
            }
            else if (frekans1 == 2)
            {
                frekans = 2f;
            }
            else if (frekans1 == 3)
            {
                frekans = 3f;
            }
            else if (frekans1 == 4)
            {
                frekans = 6f;
            }
            else if (frekans1 == 5)
            {
                frekans = 10f;
            }


            if (siddet1 == 0)
            {
                siddet = 1f;
            }
            else if (siddet1 == 1)
            {
                siddet = 3f;
            }
            else if (siddet1 == 2)
            {
                siddet = 7f;
            }
            else if (siddet1 == 3)
            {
                siddet = 15f;
            }
            else if (siddet1 == 4)
            {
                siddet = 40f;
            }
            else if (siddet1 == 5)
            {
                siddet = 100f;
            }

            var result = olasilik * siddet * frekans;

            return Json(result);
        }
        public async Task<JsonResult> Hesap2(int id)
        {
            var yenideger = id;
            var olasilik1 = yenideger % 10;
             yenideger = yenideger / 10;
            var siddet1 = yenideger % 10;

            float olasilik = 1f;
            float siddet = 1;
            float frekans = 1;

            if (olasilik1 == 0)
            {
                olasilik = 1f;
            }
            else if (olasilik1 == 1)
            {
                olasilik = 2f;
            }
            else if (olasilik1 == 2)
            {
                olasilik = 3f;
            }
            else if (olasilik1 == 3)
            {
                olasilik = 4f;
            }
            else if (olasilik1 == 4)
            {
                olasilik = 5f;
            }

            if (siddet1 == 0)
            {
                siddet = 1f;
            }
            else if (siddet1 == 1)
            {
                siddet = 2f;
            }
            else if (siddet1 == 2)
            {
                siddet = 3f;
            }
            else if (siddet1 == 3)
            {
                siddet = 4f;
            }
            else if (siddet1 == 4)
            {
                siddet = 5f;
            }

            var result = olasilik * siddet;

            return Json(result);
        }

        [Route("DosyIndir")]
        public async Task<IActionResult> DownloadFileFromFileSystem(int id)
        {
            var file = await _risk_Analiz_TabloService.GetAsync(id);
            if (file == null)
                return null;
            var memory = new MemoryStream();
            using (var stream = new FileStream(file.Data.Resim, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "image/jpg", "RiskAnalizTablo" + file.Data.Resim);
        }


        [Route("DosyaSil")]
        public async Task<IActionResult> DeleteFileFromFileSystem(int id)
        {
            Guid guid = Guid.NewGuid();
            var result = await _risk_AnalizService.GetAsync(id);


            if (result != null)
            {
                var filePath = result.Data.Dosya;
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                result.Data.Dosya = "";
                var resultObject = await _risk_AnalizService.UpdateAsync(result.Data, 2);

                if (resultObject.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                    return RedirectToAction("EditFile", result.Data);
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = result.Message;
                }
            }
            return RedirectToAction("Index");
        }


        [Route("DosyaDuzenle")]
        public async Task<IActionResult> EditFile(int id)
        {
            ViewBag.RiskAnalizTabloList = (await _risk_Analiz_TabloService.GetAllAsync()).Data;
            ViewBag.TehlikeList = (await _tehlike_TanimService.GetAllAsync()).Data;
            ViewBag.RiskAnalizList = (await _risk_Analiz_RiskService.GetAllAsync()).Data;
            ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
            ViewBag.RiskAnalizId = TempData["RiskAnalizId"];
            TempData["RiskAnalizId"] = TempData["RiskAnalizId"];
            ViewBag.RiskAnalizSelect = (await _risk_AnalizService.GetAsync(Convert.ToInt64(TempData["RiskAnalizId"]))).Data.Risk_Yontem_Id;

            string DofNoString = Convert.ToString(TempData["RiskAnalizId"])+Convert.ToString(id);
            long DofNo = Convert.ToInt64(DofNoString);
            var resultDof = (await _dofService.GetDofNoAsync(DofNo));
            TempData["Dof"] = resultDof.Data.Dof_Acik;


            var result4 = await _BirimService.GetAllAsync();
            if (result4.ResultStatus == ResultStatus.Success)
                ViewBag.Birim_Id = new SelectList(result4.Data, "Id", "Birim_Ad");
            var result5 = await _tali_BirimService.GetAllAsyncTum();
            if (result5.ResultStatus == ResultStatus.Success)
                ViewBag.Tali_Birim_Id = new SelectList(result5.Data, "Id", "Tali_Birim_Ad");
            var result3 = await _personel_BilgiService.GetAllAsync(currentKurul);
            if (result3.ResultStatus == ResultStatus.Success)
                ViewBag.Personel_Id = new SelectList(result3.Data, "Id", "Ad_Soyad");


            var result = await _risk_Analiz_TabloService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }

            return View();
        }
 
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("DosyaDuzenle")]
        public async Task<IActionResult> EditFile(int id, IFormFile Dosya, Risk_Analiz_TabloDTO riskAnalizTablo)
        {

            var result4 = await _BirimService.GetAllAsync();
            if (result4.ResultStatus == ResultStatus.Success)
                ViewBag.Birim_Id = new SelectList(result4.Data, "Id", "Birim_Ad");
            var result5 = await _tehlike_TanimService.GetAllAsync();
            if (result5.ResultStatus == ResultStatus.Success)
                ViewBag.Tali_Birim_Id = new SelectList(result5.Data, "Id", "Tali_Birim_Ad");
            ViewBag.RiskAnalizTabloList = (await _risk_Analiz_TabloService.GetAllAsync()).Data;
            ViewBag.TehlikeList = (await _tehlike_TanimService.GetAllAsync()).Data;
            ViewBag.RiskAnalizList = (await _risk_Analiz_RiskService.GetAllAsync()).Data;
            ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
            ViewBag.RiskAnalizId = TempData["RiskAnalizId"];
            TempData["RiskAnalizId"] = TempData["RiskAnalizId"];
            Guid guid = Guid.NewGuid();


            var resultObject2 = await _risk_AnalizService.GetAsync(Convert.ToInt64(TempData["RiskAnalizIdd"]));

            if (resultObject2.Data.Risk_Yontem_Id == 1)
            {
                if (riskAnalizTablo.Olasilik1 == 0)
                {
                    riskAnalizTablo.Olasilik1 = 0;
                }
                else if (riskAnalizTablo.Olasilik1 == 1)
                {
                    riskAnalizTablo.Olasilik1 = 0.2f;
                }
                else if (riskAnalizTablo.Olasilik1 == 2)
                {
                    riskAnalizTablo.Olasilik1 = 0.5f;
                }
                else if (riskAnalizTablo.Olasilik1 == 3)
                {
                    riskAnalizTablo.Olasilik1 = 1f;
                }
                else if (riskAnalizTablo.Olasilik1 == 4)
                {
                    riskAnalizTablo.Olasilik1 = 3f;
                }
                else if (riskAnalizTablo.Olasilik1 == 5)
                {
                    riskAnalizTablo.Olasilik1 = 6f;
                }
                else if (riskAnalizTablo.Olasilik1 == 6)
                {
                    riskAnalizTablo.Olasilik1 = 10f;
                }

                if (riskAnalizTablo.Frekans1 == 0)
                {
                    riskAnalizTablo.Frekans1 = 0;
                }
                else if (riskAnalizTablo.Frekans1 == 1)
                {
                    riskAnalizTablo.Frekans1 = 0.5f;
                }
                else if (riskAnalizTablo.Frekans1 == 2)
                {
                    riskAnalizTablo.Frekans1 = 1f;
                }
                else if (riskAnalizTablo.Frekans1 == 3)
                {
                    riskAnalizTablo.Frekans1 = 2f;
                }
                else if (riskAnalizTablo.Frekans1 == 4)
                {
                    riskAnalizTablo.Frekans1 = 3f;
                }
                else if (riskAnalizTablo.Frekans1 == 5)
                {
                    riskAnalizTablo.Frekans1 = 6f;
                }
                else if (riskAnalizTablo.Frekans1 == 6)
                {
                    riskAnalizTablo.Frekans1 = 10f;
                }

                if (riskAnalizTablo.Siddet1 == 0)
                {
                    riskAnalizTablo.Siddet1 = 0;
                }
                else if (riskAnalizTablo.Siddet1 ==1)
                {
                    riskAnalizTablo.Siddet1 = 1f;
                }
                else if (riskAnalizTablo.Siddet1 == 2)
                {
                    riskAnalizTablo.Siddet1 = 3f;
                }
                else if (riskAnalizTablo.Siddet1 == 3)
                {
                    riskAnalizTablo.Siddet1 = 7f;
                }
                else if (riskAnalizTablo.Siddet1 == 4)
                {
                    riskAnalizTablo.Siddet1 = 15f;
                }
                else if (riskAnalizTablo.Siddet1 == 5)
                {
                    riskAnalizTablo.Siddet1 = 40f;
                }
                else if (riskAnalizTablo.Siddet1 == 6)
                {
                    riskAnalizTablo.Siddet1 = 100f;
                }

                riskAnalizTablo.Risk_Puan1 = riskAnalizTablo.Olasilik1 * riskAnalizTablo.Frekans1 * riskAnalizTablo.Siddet1;

                if (riskAnalizTablo.Olasilik2 == 0)
                {
                    riskAnalizTablo.Olasilik2 = 0;
                }
                else if (riskAnalizTablo.Olasilik2 == 1)
                {
                    riskAnalizTablo.Olasilik2 = 0.2f;
                }
                else if (riskAnalizTablo.Olasilik2 == 2)
                {
                    riskAnalizTablo.Olasilik2 = 0.5f;
                }
                else if (riskAnalizTablo.Olasilik2 == 3)
                {
                    riskAnalizTablo.Olasilik2 = 1f;
                }
                else if (riskAnalizTablo.Olasilik2 == 4)
                {
                    riskAnalizTablo.Olasilik2 = 3f;
                }
                else if (riskAnalizTablo.Olasilik2 == 5)
                {
                    riskAnalizTablo.Olasilik2 = 6f;
                }
                else if (riskAnalizTablo.Olasilik2 == 6)
                {
                    riskAnalizTablo.Olasilik2 = 10f;
                }

                if (riskAnalizTablo.Frekans2 == 0)
                {
                    riskAnalizTablo.Frekans2 = 0;
                }
                else if (riskAnalizTablo.Frekans2 == 1)
                {
                    riskAnalizTablo.Frekans2 = 0.5f;
                }
                else if (riskAnalizTablo.Frekans2 == 2)
                {
                    riskAnalizTablo.Frekans2 = 1f;
                }
                else if (riskAnalizTablo.Frekans2 == 3)
                {
                    riskAnalizTablo.Frekans2 = 2f;
                }
                else if (riskAnalizTablo.Frekans2 == 4)
                {
                    riskAnalizTablo.Frekans2 = 3f;
                }
                else if (riskAnalizTablo.Frekans2 == 5)
                {
                    riskAnalizTablo.Frekans2 = 6f;
                }
                else if (riskAnalizTablo.Frekans2 == 6)
                {
                    riskAnalizTablo.Frekans2 = 10f;
                }

                if (riskAnalizTablo.Siddet2 == 0)
                {
                    riskAnalizTablo.Siddet2 = 0;
                }
                else if (riskAnalizTablo.Siddet2 == 1)
                {
                    riskAnalizTablo.Siddet2 = 1f;
                }
                else if (riskAnalizTablo.Siddet2 == 2)
                {
                    riskAnalizTablo.Siddet2 = 3f;
                }
                else if (riskAnalizTablo.Siddet2 == 3)
                {
                    riskAnalizTablo.Siddet2 = 7f;
                }
                else if (riskAnalizTablo.Siddet2 == 4)
                {
                    riskAnalizTablo.Siddet2 = 15f;
                }
                else if (riskAnalizTablo.Siddet2 == 5)
                {
                    riskAnalizTablo.Siddet2 = 40f;
                }
                else if (riskAnalizTablo.Siddet2 == 6)
                {
                    riskAnalizTablo.Siddet2 = 100f;
                }

                riskAnalizTablo.Risk_Puan2 = riskAnalizTablo.Olasilik2 * riskAnalizTablo.Frekans2 * riskAnalizTablo.Siddet2;



                if (riskAnalizTablo.Risk_Puan1 <= 20)
                {
                    riskAnalizTablo.Risk_Seviye1 = "ÖNEMSİZ RİSK(Önlem öncelikli değildir)";
                }
                else if (riskAnalizTablo.Risk_Puan1 > 21 && riskAnalizTablo.Risk_Puan2 <= 70)
                {
                    riskAnalizTablo.Risk_Seviye1 = "OLASI RİSK(Gözetim altında uygulanmalıdır)";
                }
                else if (riskAnalizTablo.Risk_Puan1 > 70 && riskAnalizTablo.Risk_Puan1 <= 200)
                {
                    riskAnalizTablo.Risk_Seviye1 = "ÖNEMLİ RİSK(Uzun dönemde iyileştirilmelidir.Yıl içerisinde)";
                }
                else if (riskAnalizTablo.Risk_Puan1 > 200 && riskAnalizTablo.Risk_Puan1 <= 400)
                {
                    riskAnalizTablo.Risk_Seviye1 = "ÇOK ÖNEMLİ RİSK(Kısa dönemde iyileştirilmelidir.Birkaç ay içinde)";
                }
                else if (riskAnalizTablo.Risk_Puan1 > 400)
                {
                    riskAnalizTablo.Risk_Seviye1 = "TOLERANS  GÖSTERİLEMEZ RİSK.(Hemen gerekli önlemler alınmalı veya işin durdurulması düşünülmelidir.)";
                }


            }
            else
            {
                if (riskAnalizTablo.Olasilik1 == 0)
                {
                    riskAnalizTablo.Olasilik1 = 0;
                }
                if (riskAnalizTablo.Olasilik1 == 1)
                {
                    riskAnalizTablo.Olasilik1 = 1f;
                }
                else if (riskAnalizTablo.Olasilik1 == 2)
                {
                    riskAnalizTablo.Olasilik1 = 2f;
                }
                else if (riskAnalizTablo.Olasilik1 == 3)
                {
                    riskAnalizTablo.Olasilik1 = 3f;
                }
                else if (riskAnalizTablo.Olasilik1 == 4)
                {
                    riskAnalizTablo.Olasilik1 = 4f;
                }
                else if (riskAnalizTablo.Olasilik1 == 5)
                {
                    riskAnalizTablo.Olasilik1 = 5f;
                }

                if (riskAnalizTablo.Siddet1 == 0)
                {
                    riskAnalizTablo.Siddet1 = 0;
                }
                if (riskAnalizTablo.Siddet1 == 1)
                {
                    riskAnalizTablo.Siddet1 = 1f;
                }
                else if (riskAnalizTablo.Siddet1 == 2)
                {
                    riskAnalizTablo.Siddet1 = 2f;
                }
                else if (riskAnalizTablo.Siddet1 == 3)
                {
                    riskAnalizTablo.Siddet1 = 3f;
                }
                else if (riskAnalizTablo.Siddet1 == 4)
                {
                    riskAnalizTablo.Siddet1 = 4f;
                }
                else if (riskAnalizTablo.Siddet1 == 5)
                {
                    riskAnalizTablo.Siddet1 = 5f;
                }

                riskAnalizTablo.Risk_Puan1 = riskAnalizTablo.Olasilik1 * riskAnalizTablo.Siddet1;



                if (riskAnalizTablo.Olasilik2 == 0)
                {
                    riskAnalizTablo.Olasilik2 = 0;
                }
                if (riskAnalizTablo.Olasilik2 == 1)
                {
                    riskAnalizTablo.Olasilik2 = 1f;
                }
                else if (riskAnalizTablo.Olasilik2 == 2)
                {
                    riskAnalizTablo.Olasilik2 = 2f;
                }
                else if (riskAnalizTablo.Olasilik2 == 3)
                {
                    riskAnalizTablo.Olasilik2 = 3f;
                }
                else if (riskAnalizTablo.Olasilik2 == 4)
                {
                    riskAnalizTablo.Olasilik2 = 4f;
                }
                else if (riskAnalizTablo.Olasilik2 == 5)
                {
                    riskAnalizTablo.Olasilik2 = 5f;
                }

                if (riskAnalizTablo.Siddet2 == 0)
                {
                    riskAnalizTablo.Siddet2 = 0;
                }
                if (riskAnalizTablo.Siddet2 == 1)
                {
                    riskAnalizTablo.Siddet2 = 1f;
                }
                else if (riskAnalizTablo.Siddet2 == 2)
                {
                    riskAnalizTablo.Siddet2 = 2f;
                }
                else if (riskAnalizTablo.Siddet2 == 3)
                {
                    riskAnalizTablo.Siddet2 = 3f;
                }
                else if (riskAnalizTablo.Siddet2 == 4)
                {
                    riskAnalizTablo.Siddet2 = 4f;
                }
                else if (riskAnalizTablo.Siddet2 == 5)
                {
                    riskAnalizTablo.Siddet2 = 5f;
                }

                riskAnalizTablo.Risk_Puan2 = riskAnalizTablo.Olasilik2 * riskAnalizTablo.Siddet2;




                if (riskAnalizTablo.Risk_Puan2 <= 6)
                {
                    riskAnalizTablo.Risk_Seviye2 = "Düşük Risk Seviyesi";
                }
                else if (riskAnalizTablo.Risk_Puan2 > 6 && riskAnalizTablo.Risk_Puan2 <= 12)
                {
                    riskAnalizTablo.Risk_Seviye2 = "Orta Risk Seviyesi";
                }
                else if (riskAnalizTablo.Risk_Puan2 > 12)
                {
                    riskAnalizTablo.Risk_Seviye2 = "Yüksek Risk Seviyesi";
                }



            }


            var filePaths = new List<string>();
            var resultObject = await _risk_Analiz_TabloService.GetAsync(id);
            riskAnalizTablo.Risk_Analiz_Id = resultObject.Data.Risk_Analiz_Id;
            riskAnalizTablo.Risk_Id = resultObject.Data.Risk_Id;
            if (Dosya == null)
            {
                riskAnalizTablo.Resim = resultObject.Data.Resim;

            }
            else
            {
                var filePath = "/" + resultObject.Data.Resim;
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                resultObject.Data.Resim = Dosya.FileName;
                var path = Path.GetExtension(riskAnalizTablo.Resim);
                var type = guid.ToString() + path;
                filePath = "wwwroot/Dosya/RiskAnalizTablo/" + type;
                filePaths.Add(filePath);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Dosya.CopyToAsync(stream);
                }
                riskAnalizTablo.Resim = "Dosya/RiskAnalizTablo/" + type;
            }
            if (resultObject != null)
            {
                var birimResult = await _risk_Analiz_TabloService.UpdateAsync(riskAnalizTablo, 2);
                if (birimResult.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = birimResult.Message;
                    return RedirectToAction("Index");
                };
            }
            else
            {

            }
            return View();

        }

        [HttpPost]
        public async Task<JsonResult> GetUstGrup(int id)
        {
            var result = await _risk_ust_GrupService.GetAllUstGrup(id);
            return Json(new SelectList(result.Data.ToList(), "Id", "Risk_Ust_Grup_Adi"));
        }
        public async Task<JsonResult> GetKonuGrup(int id)
        {
            var result = await _risk_Konu_GrupService.GetAllKonuGrupAsync(id);
            return Json(new SelectList(result.Data.ToList(), "Id", "Risk_Konu_Grup_Adi"));
        }
        public async Task<JsonResult> GetKonu(int id)
        {
            var result = await _risk_KonuService.GetAllKonuAsync(id);
            var deneme = result.Data.ToList();
            return Json(deneme);
        }



        [Route("Yazdir")]
        public async Task<FileResult> ReportGenerate(int id)
        {
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            String path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\Risk_Analizi.frx";
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


    }
}
