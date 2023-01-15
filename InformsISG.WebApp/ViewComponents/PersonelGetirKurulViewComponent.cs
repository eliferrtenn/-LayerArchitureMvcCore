﻿using InformsISG.Core.Utilities.Results;
using InformsISG.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InformsISG.WebApp.ViewComponents
{
    public class PersonelGetirKurulViewComponent : ViewComponent
    {
        public int currentKurul { get => int.Parse(HttpContext.Request.Cookies["Birim"]); }


        private readonly IPersonel_BilgiService _personel_BilgiService;
        private readonly ITali_BirimService _tali_BirimService;


        public PersonelGetirKurulViewComponent(IPersonel_BilgiService personelBilgiService, ITali_BirimService taliBirimService)
        {
            _personel_BilgiService = personelBilgiService;
            _tali_BirimService = taliBirimService;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var talibirimResult = await _tali_BirimService.GetAllAsync(currentKurul);
            var ss = await _personel_BilgiService.GetAsync(2);
            if (talibirimResult.ResultStatus == ResultStatus.Success)
            {
                ViewBag.Tali_Birim_Id = new SelectList(talibirimResult.Data.ToList(), "Id", "Tali_Birim_Ad");
            }

            return View(ss.Data);
        }
    }
}
