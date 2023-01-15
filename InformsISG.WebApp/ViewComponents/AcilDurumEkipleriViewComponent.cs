using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformsISG.WebApp.ViewComponents
{
    public class AcilDurumEkipleriViewComponent : ViewComponent
    {

        private readonly IAcil_Durum_EkipleriService _acil_Durum_EkipleriService;


        public AcilDurumEkipleriViewComponent(IAcil_Durum_EkipleriService acilDurumEkipleriService)
        {
            _acil_Durum_EkipleriService = acilDurumEkipleriService;
        }

        public async Task<IViewComponentResult> InvokeAsync(long id)
        {
            var result = await _acil_Durum_EkipleriService.GetAsync(id);

            if (result.ResultStatus == Core.Utilities.Results.ResultStatus.Success)
            {
                return View(result.Data);

            }
            return View();
        }
    }
}
