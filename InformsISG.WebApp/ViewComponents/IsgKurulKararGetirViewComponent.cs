using InformsISG.Core.Utilities.Results;
using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformsISG.WebApp.ViewComponents
{
    public class IsgKurulKararGetirViewComponent : ViewComponent
    {

        private readonly IISg_Kurul_KararService _isg_Kurul_KararService;

        public IsgKurulKararGetirViewComponent(IISg_Kurul_KararService isgKurulKararService)
        {
            _isg_Kurul_KararService = isgKurulKararService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var values = await _isg_Kurul_KararService.GetAsync(id);

            if (values.ResultStatus == ResultStatus.Success)
            {
                return View(values.Data);
            }

            return View();
        }
    }
}
