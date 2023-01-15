using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformsISG.WebApp.ViewComponents
{
    public class MsdsSelectIndexViewComponent : ViewComponent
    {

        private readonly IMsdsService _msdsService;


        public MsdsSelectIndexViewComponent(IMsdsService msdsService)
        {
            _msdsService = msdsService;
        }

        public async Task<IViewComponentResult> InvokeAsync(long id)
        {

            var result = await _msdsService.GetAsync(id);


            return View(result.Data);
        }
    }
}
