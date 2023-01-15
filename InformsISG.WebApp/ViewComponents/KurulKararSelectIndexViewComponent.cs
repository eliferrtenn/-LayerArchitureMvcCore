using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformsISG.WebApp.ViewComponents
{
    public class KurulKararSelectIndexViewComponent : ViewComponent
    {

        private readonly IISg_Kurul_KararService _isg_kurul_kararService;


        public KurulKararSelectIndexViewComponent(IISg_Kurul_KararService isgkurulKararService)
        {
            _isg_kurul_kararService = isgkurulKararService;
        }

        public async Task<IViewComponentResult> InvokeAsync(long id)
        {

            var result = await _isg_kurul_kararService.GetAsync(id);
            return View(result.Data);
        }
    }
}
