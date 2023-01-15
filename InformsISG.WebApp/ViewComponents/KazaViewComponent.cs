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
    public class KazaViewComponent : ViewComponent
    {

        private readonly IKazaService _kazaService;

        public KazaViewComponent(IKazaService kazaService)
        {
            _kazaService = kazaService;
        }

        public async Task<IViewComponentResult> InvokeAsync(long id)
        {
            var result = await _kazaService.GetAsync(id);
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
