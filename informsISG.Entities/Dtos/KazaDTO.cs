using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class KazaDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Kaza/Olay No"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kaza_No { get; set; }

        [DisplayName("Kaza Tarihi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Kaza_Tarih { get; set; }

        [DisplayName("Kaza Saati"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(10, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kaza_Saat { get; set; }

        [DisplayName("Bildirim Tarihi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Bildirim_Tarih { get; set; }

        [DisplayName("İşe Başlama Saati"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(8, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Ise_Baslama_Saat { get; set; }

        [DisplayName("Kaza Hasar Tipi")]
        public int Kaza_Hasar_Tipi { get; set; }

        [DisplayName("Kaza Anındaki Faaliyet"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kaza_Anindaki_Faaliyet { get; set; }

        [DisplayName("Kaza Yeri"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kaza_Yer { get; set; }

        [DisplayName("Vucüt Kısımları"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public long Vucut_Kisimlari { get; set; }

        [DisplayName("Yaralanmaya Neden Olan Olay"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(200, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Yaralanmaya_Neden_Olan_Olay { get; set; }

        [DisplayName("Yaralanmaya Neden Olan Araç"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(200, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Yaralanmaya_Neden_Olan_Arac { get; set; }

        [DisplayName("Tıbbi Müdahale"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Tibbi_Mudahele{ get; set; }

        [DisplayName("Tıbbi Müdahale Açıklama"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Tibbi_Mudahele_Aciklama { get; set; }

        [DisplayName("İş Göremezlik"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Is_Gorememezlik { get; set; }

        [DisplayName("İş Göremezlik Gün Sayısı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Is_Gorememezlik_Gun_Sayi { get; set; }

        [DisplayName("Kaza Sonrası Çalışan Ne yaptı ?"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kaza_Sonrasi_Calisan_Ne_Yapti { get; set; }

        [DisplayName("Mesleki Eğitimi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Mesleki_Egitim { get; set; }

        [DisplayName("İsg Eğitimi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Isg_Egitim { get; set; }

        [DisplayName("Hasar Büyüklüğü/Şiddeti"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Hasar_Buyuklugu { get; set; }

        [DisplayName("Olayın Tekrarlanma Olasaılığı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Tekrarlanma_Olasiligi { get; set; }

        [DisplayName("Tehlikenin Gerçekleşme Frekansı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Gerceklesme_Frekansi { get; set; }

        [DisplayName("Maruz Kalan Çalışanın İfadesi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(1000, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Maruz_Kalan_Calisanin_Ifadesi { get; set; }

        [DisplayName("Görgü Tanığının İfadesi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(1000, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Gorgu_Ifadesi { get; set; }

        [DisplayName("Kazaya Yol Açan Sebepler"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(1000, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kaza_Yol_Acan_Sebepler { get; set; }

        [DisplayName("Bu Hareketlerin Var Olmasındaki Temel Sebepler"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(1000, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Varolmasinda_Temel_Nedenler { get; set; }

        [DisplayName("Birim Sorumlusunun Görüş Önerisi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(1000, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Birim_Sorumlu_Gorus_Oneri { get; set; }

        [DisplayName("İSG Uzmanı Değerlendirmesi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(1000, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Isg_Uzmani_Degerlendirme { get; set; }

        [DisplayName("Tanık TC Numarası 1"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(11, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Tanik_Tcno1 { get; set; }

        [DisplayName("Tanık Ad Soyad 1"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(75, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Tanik_Ad_Soyad1 { get; set; }

        [DisplayName("Tanık E-Posta 1"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Tanik_Eposta1 { get; set; }

        [DisplayName("Tanık Telefon Numarası 1"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Tanik_Telefon1 { get; set; }

        [DisplayName("Tanık Adresi 1"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(200, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Tanik_Adres1 { get; set; }

        [DisplayName("Tanık TC Numarası 2"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(11, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Tanik_Tcno2 { get; set; }

        [DisplayName("Tanık Ad Soyad 2"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(75, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Tanik_Ad_Soyad2 { get; set; }

        [DisplayName("Tanık E-Posta 2"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Tanik_Eposta2 { get; set; }

        [DisplayName("Tanık Telefon Numarası 2"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Tanik_Telefon2 { get; set; }

        [DisplayName("Tanık Adresi 2"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(200, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Tanik_Adres2 { get; set; }

        [DisplayName("Düzeltici Faaliyet 1"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(3000, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Dof1 { get; set; }

        [DisplayName("Sorumlu"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Sorumlu1 { get; set; }

        [DisplayName("Açılış Tarihi "),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Acilis_Tarih1 { get; set; }

        [DisplayName("Kapanış Tarihi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Kapanis_Tarih1 { get; set; }

        [DisplayName("Düzeltici Faaliyet 2"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(3000, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Dof2 { get; set; }

        [DisplayName("Sorumlu"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Sorumlu2 { get; set; }

        [DisplayName("Açılış Tarihi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Acilis_Tarih2 { get; set; }

        [DisplayName("Kapanış Tarihi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Kapanis_Tarih2 { get; set; }

        [DisplayName("DOF 3"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(3000, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Dof3 { get; set; }

        [DisplayName("Sorumlu"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Sorumlu3 { get; set; }

        [DisplayName("Açlış Tarihi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Acilis_Tarih3 { get; set; }

        [DisplayName("Kapanış Tarihi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Kapanis_Tarih3 { get; set; }

        [DisplayName("Personel"), 
            ForeignKey("Personel_Bilgi")]
        public long Personel_Id { get; set; }

        [DisplayName("İsg Kurul"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Isg_Kurul")]
        public long Isg_Kurul_Id { get; set; }

        [DisplayName("İşveren"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Isveren")]
        public long Isveren_Id { get; set; }

        [DisplayName("Yaralanan Vucüt Bölgesi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Yaralanan_Vucut_Bolgesi")]
        public long Yaralanan_Vucut_Bolgesi_Id { get; set; }

        [DisplayName("Yaralanma Şekli"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Yaralanan_Vucut_Bolgesi")]
        public long Yaralanma_Sekli_Id { get; set; }

        [DisplayName("Kazanın Olduğu Birim"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public long Tali_Birim_Id { get; set; }
    }
}
