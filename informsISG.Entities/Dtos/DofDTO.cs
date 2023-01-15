using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class DofDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("D/Ö Faaliyet No"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Dof_No { get; set; }

        [DisplayName("D/Ö Faaliyet Tipi")]
        public int Tip { get; set; }

        [DisplayName("D/Ö Faailyetinin Geldiği Kaynak")]
        public int Geldigi_Kaynak { get; set; }

        [DisplayName("Uygunsuzluk Tanımı"),
            MaxLength(1500, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Uygunsuzluk_Tanim { get; set; }

        [DisplayName("Tespit Eden"),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Tespit_Eden { get; set; }

        [DisplayName("Sorumlu"),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Sorumlular { get; set; }

        [DisplayName("Açılış Tarihi")]
        public DateTime? Acilis_Tarih { get; set; }

        [DisplayName("Cevap Süresi")]
        public int? Cevap_Sure { get; set; }

        [DisplayName("Cevap Beklenen Tarih")]
        public DateTime? Cevap_Sonlanma_Tarih { get; set; }

        [DisplayName("Sonlanma Tarihi")]
        public DateTime? Sonlanma_Tarih { get; set; }

        [DisplayName("Döf Durumu")]
        public bool Dof_Acik { get; set; }

        [DisplayName("Düzenleyici Önleyici Faaliyetler"),
            MaxLength(3000, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Dof_Ad { get; set; }

        [DisplayName("Birim"), 
            ForeignKey("Birim")]
        public long Birim_Id { get; set; }

        [DisplayName("Tali Birim"), 
            ForeignKey("Tali_Birim")]
        public long Tali_Birim_Id { get; set; }

        [DisplayName("İsg Kurul"),
            ForeignKey("Isg_Kurul")]
        public long Isg_Kurul_Id { get; set; }

        [DisplayName("İşveren"),
            ForeignKey("Isveren")]
        public long? Isveren_Id { get; set; }
    }
}
