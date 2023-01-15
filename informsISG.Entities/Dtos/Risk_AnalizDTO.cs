
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Risk_AnalizDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Analiz No"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Analiz_No { get; set; }

        [DisplayName("Analiz Tanımı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Analiz_Tanim { get; set; }

        [DisplayName("Analiz Tarihi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Analiz_Tarih { get; set; }

        [DisplayName("Bitiş Tarihi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Bitis_Tarih { get; set; }

        [DisplayName("Notlar"),
            MaxLength(500, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Notlar { get; set; }


        [DisplayName("Dosya"),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Dosya { get; set; }

        [DisplayName("Birim"), 
            ForeignKey("Birim")]
        public long Birim_Id { get; set; }

        [DisplayName("Tali Birim"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Tali_Birim")]
        public long Tali_Birim_Id { get; set; }

        [DisplayName("İSG Kurul"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Isg_Kurul")]
        public long Isg_Kurul_Id { get; set; }

        [DisplayName("Risk Yöntem")]
        public long Risk_Yontem_Id { get; set; }

        [DisplayName("Analiz Yapan")]
        public long Personel_Id { get; set; }

        [DisplayName("Konu")]
        public long Risk_Konu_Id { get; set; }

        [DisplayName("Konu Grubu")]
        public long Risk_Konu_Grup_Id { get; set; }

        [DisplayName("Üst Grubu")]
        public long Risk_Ust_Grup_Id { get; set; }

        [DisplayName("Risk Kategori")]
        public long Risk_Kategori_Id { get; set; }
    }
}
