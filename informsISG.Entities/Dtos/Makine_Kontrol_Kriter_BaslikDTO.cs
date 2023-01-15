using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Makine_Kontrol_Kriter_BaslikDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Kriter Başlık Adı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(300, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Baslik_Ad { get; set; }


        [DisplayName("Makine"),
            ForeignKey("Makine_Id")]
        public long Makine_Id { get; set; }
    }
}
