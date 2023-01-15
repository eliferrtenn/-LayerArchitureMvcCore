using InformsISG.Core.Utilities.Results;
using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformsISG.WebApp.ViewComponents
{
    public class KazaDosyaViewComponent : ViewComponent
    {

        private readonly IKaza_DosyaService _kaza_DosyaService;

        public KazaDosyaViewComponent(IKaza_DosyaService kazaDosyaService)
        {
            _kaza_DosyaService = kazaDosyaService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var result = await _kaza_DosyaService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
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
