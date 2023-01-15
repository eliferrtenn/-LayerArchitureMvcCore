using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Kaza_Personel_DisiDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Kaza No"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kaza_No { get; set; }

        [DisplayName("Kazanın Kategorisi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Kaza_Kategori { get; set; }

        [DisplayName("Kaza Tarihi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Kaza_Tarih { get; set; }

        [DisplayName("Kaza Saati"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(10, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kaza_Saat { get; set; }

        [DisplayName("Personel Dışı TC Numarası"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(11, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Personel_Disi_Tc_No { get; set; }

        [DisplayName("Personel Dışı Ad Soyad"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(75, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Personel_Disi_Ad_Soyad { get; set; }

        [DisplayName("Kaza Yeri"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(1000, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kaza_Yer { get; set; }

        [DisplayName("Kazanın Oluş Şekli(Ayrıntılı Yazınız)"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(1000, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kaza_Olus_Sekil { get; set; }

        [DisplayName("Kazaya Neden Olan Faktörler"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(1000, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kaza_Faktor { get; set; }

        [DisplayName("Sonuç"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(1000, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Sonuc { get; set; }

        [DisplayName("Ana Neden"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(1000, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kok_Neden { get; set; }

        [DisplayName("Yapılan İşlem"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Yapilan_Islem { get; set; }

        [DisplayName("DOF 1"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(3000, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Dof1 { get; set; }

        [DisplayName("Sorumlu 1"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Sorumlu1 { get; set; }

        [DisplayName("Açılış Tarihi 1"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Acilis_Tarih1 { get; set; }

        [DisplayName("DOF 2"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(3000, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Dof2 { get; set; }

        [DisplayName("Sorumlu 2"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Sorumlu2 { get; set; }

        [DisplayName("Açılış tarihi 2"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Acilis_Tarih2 { get; set; }

        [DisplayName("DOF 3"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(3000, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Dof3 { get; set; }

        [DisplayName("Sorumlu 3"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Sorumlu3 { get; set; }

        [DisplayName("Açlışı Tarihi 3"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Acilis_Tarih3 { get; set; }


        //FK
        [DisplayName("Yaralanma Şekli"), 
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Yaralanma_Sekli")]
        public long Yaralanma_Sekli_Id { get; set; }   
        
        [DisplayName("Yaralanan Vucüt Bölgesi"), 
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Yaralanan_Vucut_Bolgesi")]
        public long Yaralanan_Vucut_Bolgesi_Id { get; set; }

        [DisplayName("Risk"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public long Risk_Analiz_Risk_Id { get; set; }

        [DisplayName("İsg Kurul"),
         Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Isg_Kurul")]
        public long Isg_Kurul_Id { get; set; }

        [DisplayName("İşveren"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Isveren")]
        public long Isveren_Id { get; set; }
    }
}
