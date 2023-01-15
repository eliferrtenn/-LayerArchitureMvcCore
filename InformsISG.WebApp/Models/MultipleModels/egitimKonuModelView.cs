using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformsISG.WebApp.Models.MultipleModels
{
    public class egitimKonuModelView
    {
        public IEnumerable<Egitim_KonuDTO> Egitim_KonuDTOS { get; set; }
        public Egitim_KonuDTO Egitim_KonuDTO { get; set; }
    }
}
