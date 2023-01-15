using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace InformsISG.Entities.Dtos
{
    public class Makine_Ekipman_Kontrol_KriterDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Madde Adı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(500, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Madde_Ad { get; set; }

        [DisplayName("Uygun")]
        public bool Uygun { get; set; } = false;

        [DisplayName("Degerlendirme")]
        public int? Degerlendirme { get; set; }

        [DisplayName("Makine Ekipman Kontrol Kriter Başlık"),
            ForeignKey("Makine_Ekipman_Kontrol_Kriter_Baslik")]
        public long Makine_Ekipman_Kontrol_Kriter_Baslik_Id { get; set; }
    }
}
