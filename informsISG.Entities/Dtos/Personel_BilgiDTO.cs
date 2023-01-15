using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
//Postre sql büyük harfe izin vermez
namespace InformsISG.Entities.Dtos
{
    public class Personel_BilgiDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("İş Güvenliği Uzmanı Mı?")]
        public bool IsgUzmanMi { get; set; }

        [DisplayName("İş Yeri Hekimi Mi?")]
        public bool IsYeriHekimi { get; set; }

        [DisplayName("Sertifika No"),
          MaxLength(70, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string SertifikaNo { get; set; }

        [DisplayName("Fotoğraf"),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Fotograf { get; set; }

        [DisplayName("Ünvan"),
            MaxLength(75, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Unvan { get; set; }

        [DisplayName("Ad Soyad"),
        Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
        MaxLength(75, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Ad_Soyad { get; set; }

        [DisplayName("Sicil No"),
          Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
          MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Sicil_No { get; set; }

        [DisplayName("SGK No"),
           MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Sgk_No { get; set; }

        [DisplayName("Kimlik No"),
          Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
          MaxLength(11, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Tc_No { get; set; }

        [DisplayName("Doğum Tarihi"),
           Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Dogum_Tarih { get; set; }

        [DisplayName("Doğum Yeri"),
           MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Dogum_Yer { get; set; }

        [DisplayName("Cinsiyet")]
        public bool Cinsiyet { get; set; }

        [DisplayName("İşe Giriş Tarihi"),
           Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Is_Giris_Tarih { get; set; }


        [DisplayName("Medeni Durum"),
           Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public Int32 Medeni_Durum { get; set; }

        [DisplayName("Telefon"),
           MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Telefon1 { get; set; }

        [DisplayName("Telefon")]
        public string Telefon2 { get; set; }

        [DisplayName("Adres"),
           MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Adres { get; set; }

        [DisplayName("Eğitim Durumu")]
        public Int32 Egitim { get; set; }

        [DisplayName("Mesleki Eğitim Durumu")]
        public Int32 Egitim_Meslek { get; set; }

        [DisplayName("E-Posta"),
           MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir"),
           EmailAddress(ErrorMessage = "Lütfen  alana uygun {0} giriniz")]
        public string Eposta { get; set; }

        [DisplayName("İşten Çıkış Tarihi"),
           Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Is_Cikis_Tarih { get; set; }

        [DisplayName("Kadro Durumu")]
        public bool Kadro_Durumu { get; set; }

        [DisplayName("Personel Hakkında Bilgi"),
           MaxLength(2000, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Notlar { get; set; }


        [DisplayName("Personel Yer Değişikliği")]
        public bool yerdegistiMi { get; set; } = false;
 
        [DisplayName("İş/Görev"),
            ForeignKey("Sgk_Meslek")]
        public long Sgk_Meslek_Id { get; set; }

        [DisplayName("Tali Birimi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Tali_Birim")]
        public long Tali_Birim_Id { get; set; }

        [DisplayName("Birim"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Birim")]
        public long Birim_Id { get; set; }

    }
}
