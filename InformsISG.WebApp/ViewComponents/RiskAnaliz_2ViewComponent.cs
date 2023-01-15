using InformsISG.Core.Utilities.Results;
using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InformsISG.WebApp.ViewComponents
{
    public class RiskAnaliz_2ViewComponent : ViewComponent
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }

        private readonly IRisk_AnalizService _risk_AnalizService;
        private readonly IBirimService _BirimService;
        private readonly ITali_BirimService _tali_BirimService;
        private readonly IRisk_YontemService _risk_YontemService;
        private readonly IPersonel_BilgiService _personel_BilgiService;


        public RiskAnaliz_2ViewComponent(IRisk_AnalizService riskAnalizService, IBirimService birimService, ITali_BirimService taliBirimService, IRisk_YontemService riskYontemService, IPersonel_BilgiService personelBilgiService)
        {
            _risk_AnalizService = riskAnalizService;
            _BirimService = birimService;
            _tali_BirimService = taliBirimService;
            _risk_YontemService = riskYontemService;
            _personel_BilgiService = personelBilgiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var result = await _risk_AnalizService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                var result1 = await _BirimService.GetAllAsync();
                if (result1.ResultStatus == ResultStatus.Success)
                    ViewBag.Birim_Id = new SelectList(result1.Data, "Id", "Birim_Ad");
                var result2 = await _tali_BirimService.GetAllAsync(currentKurul);
                if (result2.ResultStatus == ResultStatus.Success)
                    ViewBag.Tali_Birim_Id = new SelectList(result2.Data, "Id", "Tali_Birim_Ad");
                var result3 = await _risk_YontemService.GetAllAsync();
                if (result3.ResultStatus == ResultStatus.Success)
                    ViewBag.Risk_Yontem_Id = new SelectList(result3.Data, "Id", "Risk_Yontem_Ad");
                var result4 = await _personel_BilgiService.GetAllAsync(currentKurul);
                if (result4.ResultStatus == ResultStatus.Success)
                    ViewBag.Personel_Id = new SelectList(result4.Data, "Id", "Ad_Soyad");
                return View(result.Data);
            }
            else
            {
                TempData["MessageIcon"] = "error";
                TempData["MessageText"] = result.Message;
            }
            return View("Index");
        }
    }
}
