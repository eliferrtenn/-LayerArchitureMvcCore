using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformsISG.WebApp.ViewComponents
{
    public class KazaPersonelDisiViewComponent : ViewComponent
    {

        private readonly IKaza_Personel_DisiService _kaza_Personel_DisiService;


        public KazaPersonelDisiViewComponent(IKaza_Personel_DisiService kazaPersonelDisiService)
        {
            _kaza_Personel_DisiService = kazaPersonelDisiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(long id)
        {

            var result = await _kaza_Personel_DisiService.GetAsync(id);

            return View(result.Data);
        }
    }
}
