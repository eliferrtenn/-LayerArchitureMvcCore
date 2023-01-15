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
    public class KazaAyrintiViewComponent : ViewComponent
    {

        private readonly IKaza_AyrintiService _kaza_AyrintiService;

        public KazaAyrintiViewComponent(IKaza_AyrintiService kazaAyrintiService)
        {
            _kaza_AyrintiService = kazaAyrintiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var result = await _kaza_AyrintiService.GetKazaAsync(id);
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
