
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Yetkili_GormediDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("TABLO ADI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(200, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Tablo_Adi { get; set; }

        [DisplayName("TABLO BİRİMİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Risk_Analiz_Tablo")]
        public long Tablo_Id { get; set; }
    }
}
