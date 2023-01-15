
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Makine_EkipmanDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Ekipman Kodu"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Ekipman_Kodu { get; set; }

        [DisplayName("Firma Adı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Firma_Adi { get; set; }

        [DisplayName("Periyodik Kontrol Tarihi")]
        public DateTime Periyodik_Kontrol_Tarih { get; set; }

        [DisplayName("Bir Sonraki Kontrol Tarihi")]
        public DateTime Tekrar_Periyodik_Kontrol_Tarih { get; set; }

        [DisplayName("Periyodik Kontrol Adresi"),
            MaxLength(500, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Periyodik_Kontrol_Adres { get; set; }

        [DisplayName("Telefon No "),
            MaxLength(11, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Telefon_No { get; set; }

        [DisplayName("E-Posta"),
            MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string E_Posta { get; set; }

        [DisplayName("Takip Kontrol Tarihi "),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Takip_Kontrol_Tarih { get; set; }

        [DisplayName("Rapor Tarihi "),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Rapor_Tarih { get; set; }

        [DisplayName("Periyodik Kontrol Metodu"),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Periyodik_Kontrol_Method { get; set; }

        [DisplayName("MESKİ Kimlik No/Rapor No"),
            MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kimlik_Rapor_No { get; set; }

        [DisplayName("Kapsam")]
        public string Kapsam { get; set; }

        [DisplayName("QR Kodu")]
        public string QRCode { get; set; }

        [DisplayName("İncelemede Tespit Edilen Diğer Eksiklikler")]
        public string Inceleme_Tespit_Edilen_Diger_Eksiklikler { get; set; }

        [DisplayName("Onay")]
        public string Onay { get; set; }

        [DisplayName("Periyodik Kontrol Görevlisinin Adı Soyadı"),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Periyodik_Kontrol_Gorevlisi_Ad_Soyad { get; set; }

        [DisplayName("Periyodik Kontrol Görevlisinin Mesleği"),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Periyodik_Kontrol_Gorevlisi_Meslek { get; set; }

        [DisplayName("Periyodik Kontrol Görevlisinin Diploma Tarihi ve Numarası"),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Periyodik_Kontrol_Gorevlisi_Diploma_Tarihi_Numarasi { get; set; }
        
        [DisplayName("Periyodik Kontrol Görevlisinin Bakanlık Kayıt Numarası"),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Periyodik_Kontrol_Gorevlisi_Bakanlik_Numara { get; set; }

        [DisplayName("Birim Sorumlusunun Adı Soyadı"),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Birim_Sorumlusu_Ad_Soyad { get; set; }

        [DisplayName("Birim Sorumlusunun Mesleği"),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Birim_Sorumlusu_Meslek { get; set; }

        [DisplayName("Birim Sorumlusunun Diploma Tarihi ve Numarası"),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Birim_Sorumlusu_Diploma_Tarihi_Numarasi { get; set; }
        
        [DisplayName("Birim Sorumlusunun Bakanlık Kayıt Numarası"),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Birim_Sorumlusu_Bakanlik_Numara { get; set; }

        [DisplayName("Birim"), 
            ForeignKey("Birim")]
        public long Birim_Id { get; set; }

        [DisplayName("Makine"), 
            ForeignKey("Makine")]
        public long Makine_Id { get; set; }

        [DisplayName("Tali Birimi"), 
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Tali_Birim")]
        public long Tali_Birim_Id { get; set; }

    }
}
