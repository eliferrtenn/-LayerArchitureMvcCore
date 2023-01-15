
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Ramak_KalaDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Ramak Kala No"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Ramak_Kala_No { get; set; }

        [DisplayName("Tarih"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Tarih { get; set; }

        [DisplayName("Saat"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Saat { get; set; }

        [DisplayName("Görev"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Gorev { get; set; }

        [DisplayName("Olay"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(400, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Olay { get; set; }

        [DisplayName("Olay Tam Yeri"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(400, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Olay_Tam_Yer { get; set; }

        [DisplayName("Öneri"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(400, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Oneri { get; set; }

        [DisplayName("Amir Görüşü"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(400, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Amir_Gorus { get; set; }

        [DisplayName("İGU Görüşü"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(400, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Igu_Gorus { get; set; }

        [DisplayName("İGU Görüş Tarihi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Igu_Gorus_Tarih { get; set; }

        [DisplayName("Süre"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Termin_Sure { get; set; }

        [DisplayName("İş Tanımı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(400, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Is_Tanim { get; set; }

        [DisplayName("Tamamlanma Onayı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Tamamlandi { get; set; }

        [DisplayName("Tamamlanma Tarihi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Tamamlandi_Tarih { get; set; }

        [ForeignKey("Birim")]
        public long Birim_Id { get; set; }

        [DisplayName("Tali Birim "), 
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Tali_birim")]
        public long Tali_Birim_Id { get; set; }

        [DisplayName("İSG Kurul"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Isg_Kurul")]
        public long Isg_Kurul_Id { get; set; }

        [DisplayName("İşveren"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Isveren")]
        public long Isveren_Id { get; set; }

        [DisplayName("Ad Soyad"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Personel_Bilgi")]
        public long Personel_Id { get; set; }
    }
}
