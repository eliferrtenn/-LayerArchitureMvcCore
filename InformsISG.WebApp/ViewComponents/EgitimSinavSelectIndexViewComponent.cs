using InformsISG.Core.Utilities.Results;
using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformsISG.WebApp.ViewComponents
{
    public class EgitimSinavSelectIndexViewComponent : ViewComponent
    {

        private readonly IEgitim_Sinav_NotService _egitim_SinavService;

        public EgitimSinavSelectIndexViewComponent(IEgitim_Sinav_NotService egitimSinavService)
        {
            _egitim_SinavService = egitimSinavService;
        }

        public async Task<IViewComponentResult> InvokeAsync(long id)
        {
            var result = await _egitim_SinavService.GetAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }

            return View();
        }
    }
}
