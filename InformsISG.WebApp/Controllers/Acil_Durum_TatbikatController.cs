using InformsISG.Core.Utilities.Results;
using InformsISG.Entities.Dtos;
using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace InformsISG.WebApp.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,IsgUzman,IsYeriHekim,BirimSorumlusu", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("AcilDurumTatbikat/")]
    public class Acil_Durum_TatbikatController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }
        private readonly IAcil_Durum_TatbikatService _acil_Durum_TatbikatService;
        private readonly ITali_BirimService _tali_BirimService;


        public Acil_Durum_TatbikatController(IAcil_Durum_TatbikatService acilDurumTatbikatService, ITali_BirimService taliBirimService)
        {
            _acil_Durum_TatbikatService = acilDurumTatbikatService;
            _tali_BirimService = taliBirimService;
        }



        [Route("Liste")]
        // GET: Acil_Durum_Ekip_PersonelController
        public async Task<IActionResult> Index()
        {
            var result = await _acil_Durum_TatbikatService.GetAllAsync();

            ViewBag.TaliBirim = (await _tali_BirimService.GetAllAsync(currentKurul)).Data;
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // GET: Acil_Durum_TatbikatController/Details/5
        [HttpGet]
        [Route("Detaylar")]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _acil_Durum_TatbikatService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                ViewBag.TaliBirim = (await _tali_BirimService.GetAllAsync(currentKurul)).Data;
                return View(result.Data);
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("Index");
        }

        // GET: BirimController/Create
        [Route("Olustur")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var result1 = await _tali_BirimService.GetAllAsync(currentKurul);
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Tali_Birim_Id = new SelectList(result1.Data, "Id", "Tali_Birim_Ad");

            return View();
        }

        // POST: Acil_Durum_TatbikatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        public async Task<IActionResult> Create(Acil_Durum_TatbikatDTO acil_Durum_TatbikatDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _acil_Durum_TatbikatService.AddAsync(acil_Durum_TatbikatDTO, 1);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = result.Message;
                    var result1 = await _tali_BirimService.GetAllAsync(currentKurul);
                    if (result1.ResultStatus == ResultStatus.Success)
                        ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Tali_Birim_Ad");
                    return View();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Acil_Durum_TatbikatController/Edit/5
        [Route("Duzenle")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _acil_Durum_TatbikatService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _tali_BirimService.GetAllAsync(currentKurul);
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

        // POST: Acil_Durum_TatbikatController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id, Acil_Durum_TatbikatDTO acil_Durum_TatbikatDTO)
        {
            var result1 = await _tali_BirimService.GetAllAsync(currentKurul);
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Tali_Birim_Id = new SelectList(result1.Data, "Id", "Tali_Birim_Ad");
            var result = await _acil_Durum_TatbikatService.GetAsync(id);
            if (result != null)
            {
                var birimResult = await _acil_Durum_TatbikatService.UpdateAsync(acil_Durum_TatbikatDTO, 2);

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


        // GET: Acil_Durum_TatbikatController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Sil")]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _acil_Durum_TatbikatService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }
    }
}
