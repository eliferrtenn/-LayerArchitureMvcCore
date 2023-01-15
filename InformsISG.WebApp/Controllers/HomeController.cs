using InformsISG.Core.Utilities.Results;
using InformsISG.Services.Abstract;
using InformsISG.WebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace InformsISG.WebApp.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,IsgUzman,IsYeriHekim,BirimSorumlusu", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class HomeController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        ClaimsIdentity identity = new(CookieAuthenticationDefaults.AuthenticationScheme);
        private static string _mail;
        private static string _sifre;
        private readonly ILogger<HomeController> _logger;
        private readonly IKullaniciService _kullaniciService;
        private readonly IPersonel_BilgiService _personel_BilgiService;
        private readonly IYetkiService _yetkiService;

        private readonly IRisk_Analiz_TabloService _risk_analiz_TabloService;
        private readonly IISg_KurulService _kurulService;
        private readonly IISg_Kurul_KararService _kurul_KararService;
        private readonly IISg_Kurul_Karar_DosyaService _kurul_karar_DosyaService;
        private readonly IAlt_IsverenService _alt_IsverenService;
        private readonly IBirimService _birimService;
        private readonly IMakine_Ekipman_Bakim_PlanlariService _makine_Ekipman_Bakim_PlanlariService;
        private readonly IEgitim_TanimlaService _egitim_TanimlaService;

        public HomeController(ILogger<HomeController> logger,IKullaniciService kullaniciService,IPersonel_BilgiService personelBilgiService,IYetkiService yetkiService,IRisk_Analiz_TabloService riskAnalizTabloService,IISg_KurulService kurulService,IISg_Kurul_KararService kurulKararService,IISg_Kurul_Karar_DosyaService kurulKararDosyaService,IAlt_IsverenService altIsverenService,IBirimService birimService,IMakine_Ekipman_Bakim_PlanlariService makine_Ekipman_Bakim_PlanlariService,IEgitim_TanimlaService egitimTanimlaService)
        {
            _logger = logger;
            _kurulService = kurulService;
            _kullaniciService = kullaniciService;
            _personel_BilgiService = personelBilgiService;
            _yetkiService = yetkiService;
            _risk_analiz_TabloService = riskAnalizTabloService;
            _kurul_KararService = kurulKararService;
            _kurul_karar_DosyaService = kurulKararDosyaService;
            _alt_IsverenService = altIsverenService;
            _birimService = birimService;
            _makine_Ekipman_Bakim_PlanlariService = makine_Ekipman_Bakim_PlanlariService;
            _egitim_TanimlaService = egitimTanimlaService;
        }

        //[AllowAnonymous]
        public async Task<IActionResult> Index(long Id)
        {
            ViewBag.RiskYuksekTablo = (await _risk_analiz_TabloService.GetYuksekRisk()).Data;
            ViewBag.PersonelList = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data;
            ViewBag.PersonelCount = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data.Count;
            ViewBag.PersonelCountEksi = (await _personel_BilgiService.GetAllAsync(currentKurul)).Data.Count-9;

            ViewBag.KurulKararListe = ((await _kurul_KararService.GetAllAsync()).Data).OrderByDescending(x => x.Tarih);
            ViewBag.KurulKararDosyaListe = (await _kurul_karar_DosyaService.GetAllAsync()).Data;
            ViewBag.KurulKararCount = (await _kurul_KararService.GetAllAsync()).Data.Count;

            ViewBag.Birim = (await _birimService.GetAsync(currentKurul)).Data.Birim_Ad;

            ViewBag.BakimPlan= (await _makine_Ekipman_Bakim_PlanlariService.GetBeklemeAsync()).Data.OrderByDescending(x=>x.Servis_Tarih);

            ViewBag.BakimPlan2 = (await _makine_Ekipman_Bakim_PlanlariService.GetAllAsync()).Data.OrderByDescending(x => x.Servis_Tarih);

            ViewBag.EgitimList = (await _egitim_TanimlaService.GetAllAsync()).Data.OrderByDescending(x => x.Egitim_Tarih);


            var result1 = await _birimService.GetAllAsync();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");



            return View();
        }

        //[ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult GirisYap()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> GirisYap(string Mail,string Password)
        {
            _mail = Mail;
            _sifre = Password;
            if (ModelState.IsValid)
            {
                var result = await _kullaniciService.GetKullanci(Mail, Password);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var resultObject = await _yetkiService.GetAsync(result.Data.Yetki_Id);
                    var resultObject2 = await _personel_BilgiService.GetAsync(result.Data.Personel_Id);

                    identity.AddClaim(new Claim(ClaimTypes.Name, Mail));
                    identity.AddClaim(new Claim(ClaimTypes.Role, resultObject.Data.Yetki_Ad));
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.OtherPhone,result.Data.Birim_Id.ToString()));
                    Response.Cookies.Append("PersonelAd", resultObject2.Data.Ad_Soyad);
                    Response.Cookies.Append("YetkiAd", resultObject.Data.Yetki_Ad);
                    Response.Cookies.Append("Birim", result.Data.Birim_Id.ToString());
                    String birimAd = (await _birimService.GetAsync(result.Data.Birim_Id)).Data.Birim_Ad;
                    Response.Cookies.Append("BirimAd", birimAd);
                    ClaimsPrincipal principal = new(identity);
                    Thread.CurrentPrincipal = principal;
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    
                    return RedirectToAction("Index", "Home",new { Id = result.Data.Birim_Id});;
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = "Girdiğiniz veriler hatalıdır. Lütfen tekrar deneyiniz.";
                    return View();
                }
            }

            return View();
        }

        public async Task<IActionResult> CikisYap()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("GirisYap");
        }
        [HttpPost]
        public async Task <IActionResult> deneme(int Id)
        {
            Response.Cookies.Append("Birim", Id.ToString());

            String birimAd = (await _birimService.GetAsync(Id)).Data.Birim_Ad;

            Response.Cookies.Append("BirimAd",birimAd);


            return RedirectToAction("Index", "Home", new { Id = Id });

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
