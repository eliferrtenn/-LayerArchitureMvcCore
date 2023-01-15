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
    public class MakineEkipmanViewComponent : ViewComponent
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }

        private readonly IMakine_EkipmanService _makine_EkipmanService;


        public MakineEkipmanViewComponent(IMakine_EkipmanService makineEkipmanService)
        {
            _makine_EkipmanService = makineEkipmanService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var result = await _makine_EkipmanService.GetAsync(id);
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
