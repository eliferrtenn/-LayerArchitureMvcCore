
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Risk_Analiz_TabloDTO
    {
        public long Id { get; set; } = 0;


        [DisplayName("Faaliyet")]
        public string Faaliyet { get; set; }

        [DisplayName("Rutin(R) / Rutin Olmayan(RO)")]
        public int Rutin_Durum { get; set; }

        [DisplayName("Tehlike")]
        public string Tehlike { get; set; }

        [DisplayName("Risk")]
        public string Risk { get; set; }

        [DisplayName("Mevcut/Uygunluk Durumu")]
        public bool Uygun_Durum { get; set; }

        [DisplayName("Yasal Dayanak")]
        public string Yasal_Dayanak { get; set; }

        [DisplayName("Yapılması Gereken Düzenleyici Önleyici Faaliyet")]
        public string Duzeltici_Faaliyet { get; set; }

        [DisplayName("Termin Tarih"), DataType(DataType.Date)]
        public DateTime? Termin_Tarih { get; set; }

        [DisplayName("Sorumlu")]
        public string Sorumlular { get; set; }

        [DisplayName("Etkinlik Kontrol Tarihi"), DataType(DataType.Date)]
        public DateTime? Etkinlik_Kontrol_Tarih { get; set; }

        [DisplayName("Kontrol/Gözlem Değerlendirmesi")]
        public string Kontrol_Degerlendirme { get; set; }

        [DisplayName("Olasılık ")]
        public float? Olasilik1 { get; set; }

        [DisplayName("Frekans ")]
        public float? Frekans1 { get; set; }

        [DisplayName("Şiddet ")]
        public float? Siddet1 { get; set; }

        [DisplayName("Risk Değeri ")]
        public float? Risk_Puan1 { get; set; } = 0.2f;

        [DisplayName("Riskin Tanımı"),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Risk_Seviye1 { get; set; }


        [DisplayName("Olasılık"),]
        public float? Olasilik2 { get; set; } = 1;

        [DisplayName("Frekans"),]
        public float? Frekans2 { get; set; } = 1;

        [DisplayName("Şiddet"),]
        public float? Siddet2 { get; set; } = 1;

        [DisplayName("Risk Değeri"),]
        public float? Risk_Puan2 { get; set; } = 1;

        [DisplayName("Risk Tanımı")]
        public string? Risk_Seviye2 { get; set; } = "Düşük";

        [DisplayName("Resim"),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Resim { get; set; }

        [DisplayName("Risk"),
            ForeignKey("Risk_Analiz")]
        public long Risk_Id { get; set; }

        [DisplayName("Risk Analiz"),
            ForeignKey("Risk_Analiz_Risk")]
        public long Risk_Analiz_Id { get; set; }

        [DisplayName("Tehlike Tanım"),
            ForeignKey("Tehlike_Tanim")]
        public long Tehlike_Tanim_Id { get; set; }

        [DisplayName("ETKİLENENLER"),
            ForeignKey("Personel")]
        public long Personel_Id { get; set; }

        [DisplayName("İlgili Birim"),
            ForeignKey("Birim")]
        public long Birim_Id { get; set; }

        [DisplayName("Faaliyet Alanı"),
            ForeignKey("Tali_Birim")]
        public long Tali_Birim_Id { get; set; }

    }
}
