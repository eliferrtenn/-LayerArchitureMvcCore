using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Ayarlar : EntityBase , IEntity
    {
        //Tablo alanları
        public int Tehlike_Tip { get; set; }

        public int Egitim_Sure { get; set; }

        public string Egitim_Sure_Periyot { get; set; }

        public int Risk_Sure { get; set; }

        public string Risk_Sure_Periyot { get; set; }

        public int Saglik_Kontrol { get; set; }

        public string Saglik_Kontrol_Periyot { get; set; }

        public int Igu_Sure { get; set; }

        public string Igu_Sure_Periyot { get; set; }
    }
}
