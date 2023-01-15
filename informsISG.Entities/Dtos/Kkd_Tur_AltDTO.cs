
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Kkd_Tur_AltDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("KKD Tür Alt Adı"),
            Required(ErrorMessage  = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kkd_Tur_Alt_Ad { get; set; }

        [DisplayName("KKD Tür Adı"), 
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Kkd_Tur")]
        public long Kkd_Tur_Id { get; set; }

         
    }
}