using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace InformsISG.Entities.Dtos
{
    public class Makine_Kontrol_KriterDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Madde Adı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(500, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Madde_Ad { get; set; }

        [DisplayName("Makine Kontrol Kriter Başlık"),
            ForeignKey("Makine_Kontrol_Kriter_Baslik")]
        public long Makine_Kontrol_Kriter_Baslik_Id { get; set; }
    }
}
