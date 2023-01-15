using InformsISG.Core.Utilities.Results;
using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformsISG.WebApp.ViewComponents
{
    public class EgitimTanimPersonelListeViewComponent : ViewComponent
    {

        private readonly IEgitim_TanimlaService _egitim_TanimlaService;
        private readonly IPersonel_BilgiService _personel_BilgiService;

        public EgitimTanimPersonelListeViewComponent(IEgitim_TanimlaService egitimTanimlaService,IPersonel_BilgiService personelBilgiService)
        {
            _egitim_TanimlaService = egitimTanimlaService;
            _personel_BilgiService = personelBilgiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(long id)
        {
            //var values = await _egitim_TanimlaService.GetAllAsync();
            //var values2 = await _personel_BilgiService.GetAllAsync();
            var values2 = await _personel_BilgiService.GetAsync(id);
            if (values2.ResultStatus == ResultStatus.Success)
            {
                return View(values2.Data);
            }

            return View();
        }
    }
}
