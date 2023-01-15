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
    public class EgitimPersonelAtamaViewComponent : ViewComponent
    {
        private readonly IEgitim_Personel_AtamaService _egitim_personel_AtamaService;
        private readonly IEgitim_KonuService _egitim_KonuService;


        public EgitimPersonelAtamaViewComponent(IEgitim_Personel_AtamaService egitimPersonelAtamaService, IEgitim_KonuService egitim_KonuService)
        {
            _egitim_personel_AtamaService = egitimPersonelAtamaService;
            _egitim_KonuService = egitim_KonuService;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _egitim_personel_AtamaService.GetAllAsync();

            if (values.ResultStatus == ResultStatus.Success)
            {
                return View(values.Data);
            }

            return View(values.Data);
        }
    }
}
