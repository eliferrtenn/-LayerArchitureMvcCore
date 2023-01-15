using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformsISG.WebApp.ViewComponents
{
    public class DofSelectIndexViewComponent : ViewComponent
    {

        private readonly IDofService _dofService;


        public DofSelectIndexViewComponent(IDofService dofService)
        {
            _dofService = dofService;
        }

        public async Task<IViewComponentResult> InvokeAsync(long id)
        {

            var result = await _dofService.GetAsync(id);
            return View(result.Data);
        }
    }
}
