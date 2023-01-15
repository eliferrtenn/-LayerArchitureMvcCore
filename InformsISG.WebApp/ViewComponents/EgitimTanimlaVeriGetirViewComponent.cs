using InformsISG.Core.Utilities.Results;
using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformsISG.WebApp.ViewComponents
{
    public class EgitimTanimlaVeriGetirViewComponent : ViewComponent
    {

        private readonly IEgitim_TanimlaService _egitim_TanimlaService;

        public EgitimTanimlaVeriGetirViewComponent(IEgitim_TanimlaService egitimTanimlaService)
        {
            _egitim_TanimlaService = egitimTanimlaService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var values = await _egitim_TanimlaService.GetAsync(id);

            if (values.ResultStatus == ResultStatus.Success)
            {
                return View(values.Data);
            }

            return View();
        }
    }
}
