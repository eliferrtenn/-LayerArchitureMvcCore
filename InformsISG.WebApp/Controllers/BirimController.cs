using InformsISG.Core.Utilities.Results;
using InformsISG.Entities.Dtos;
using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InformsISG.WebApp.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("Birim/")]
    public class BirimController : Controller
    {
        public int currentKurul { get => int.Parse(HttpContext.User.Claims.First(x => x.Type == ClaimTypes.OtherPhone).Value); }
        private readonly IBirimService _birimService;
        private readonly IISg_KurulService _isgKurulService;
        private readonly IIsverenService _isverenService;

        public BirimController(IBirimService birimService, IISg_KurulService isgKurulService, IIsverenService isverenService)
        {
            _birimService = birimService;
            _isgKurulService = isgKurulService;
            _isverenService = isverenService;
        }
        [Route("Liste")]
        // GET: BirimController
        public async Task<IActionResult> Index()
        {
            var result = await _birimService.GetAllAsync();
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

        [Route("Detaylar")]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _birimService.GetAsync(id);
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


        // GET: BirimController/Create
        [Route("Olustur")]
        public async Task<IActionResult> Create()
        {
            var result1 = await _isgKurulService.GetAllAsync();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");

            var result2 = await _isverenService.GetAllAsync();
            if (result2.ResultStatus == ResultStatus.Success)
                ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");

            return View();
        }

        // POST: BirimController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Olustur")]
        public async Task<IActionResult> Create(BirimDTO birim)
        {
            var resultObject = (await _birimService.GetAsync(currentKurul)).Data.Isg_Kurul_Id;
            if (ModelState.IsValid)
            {
                birim.Isg_Kurul_Id = resultObject;
                var result = await _birimService.AddAsync(birim, 1);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    TempData["MessageIcon"] = "success";
                    TempData["MessageText"] = result.Message;
                }
                else
                {
                    TempData["MessageIcon"] = "error";
                    TempData["MessageText"] = result.Message;
                    var result1 = await _isgKurulService.GetAllAsync();
                    if (result1.ResultStatus == ResultStatus.Success)
                        ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");
                    var result2 = await _isverenService.GetAllAsync();
                    if (result2.ResultStatus == ResultStatus.Success)
                        ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
                    return View();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: BirimController/Edit/5
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _birimService.GetAsync(id);
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
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return RedirectToAction("Index");
        }

        // POST: BirimController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Duzenle")]
        public async Task<IActionResult> Edit(int id, BirimDTO birim)
        {
            var result1 = await _isgKurulService.GetAllAsync();
            if (result1.ResultStatus == ResultStatus.Success)
                ViewBag.Isg_Kurul_Id = new SelectList(result1.Data, "Id", "Kurul_Ad");

            var result2 = await _isverenService.GetAllAsync();
            if (result2.ResultStatus == ResultStatus.Success)
                ViewBag.Isveren_Id = new SelectList(result2.Data, "Id", "Isveren_Ad");
            var result = await _birimService.GetAsync(id);
            if (result != null)
            {
                birim.Isg_Kurul_Id = result.Data.Isg_Kurul_Id;
                var birimResult = await _birimService.UpdateAsync(birim, 2);

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


        // GET: BirimController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Sil")]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _birimService.DeleteAsync(id, 1);
            var ajaxResult = JsonConvert.SerializeObject(result);
            return Json(ajaxResult);
        }
    }
}
