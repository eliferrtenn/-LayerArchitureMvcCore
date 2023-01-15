
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class MuayeneDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Muayene Tarihi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Muayene_Tarih { get; set; }

        [DisplayName("Muayene Türü"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Muayene_Tur { get; set; }

        [DisplayName("Kan Grubu"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kan_Grup { get; set; }

        [DisplayName("El Kullanımı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int El_Kullanim { get; set; }

        [DisplayName("Kilo"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Kilo { get; set; }

        [DisplayName("Boy"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Boy { get; set; }

        [DisplayName("Kitle Endeksi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kitle_Endeks { get; set; }

        [DisplayName("Kronik Hastalık"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kronik_Hastalik { get; set; }

        [DisplayName("İş Kolu"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Is_Kolu1 { get; set; }

        [DisplayName("Yaptığı İş"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Yaptigi_Is1 { get; set; }

        [DisplayName("Giriş Çıkış Tarihi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Giris_Cikis1 { get; set; }


        [DisplayName("İş Kolu 2"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Is_Kolu2 { get; set; }

        [DisplayName("Yaptığı İş 2"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Yaptigi_Is2 { get; set; }

        [DisplayName("Giriş Çıkış 2"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Giris_Cikis2 { get; set; }

        [DisplayName("İş Kolu 3"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Is_Kolu3 { get; set; }

        [DisplayName("Yaptığı İş 3"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Yaptigi_Is3 { get; set; }

        [DisplayName("Giriş Çıkış 3"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(050, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Giris_Cikis3 { get; set; }


        [DisplayName("Tetanoz"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Bagisiklik_Tetanoz { get; set; }

        [DisplayName("Bağışıklık Hepatit"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Bagisiklik_Hepatit { get; set; }


        [DisplayName("Diğer Bağışıklıklar"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Bagisiklik_Diger { get; set; }

        [DisplayName("Annesi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Soygecmis_Anne { get; set; }

        [DisplayName("Babası"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Soygecmis_Baba { get; set; }

        [DisplayName("Kardeşi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kardes { get; set; }

        [DisplayName("Çocuğu"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Cocuk { get; set; }

        [DisplayName("Nefes Darlığı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Nefes_Darligi{ get; set; }

        [DisplayName("Balgamlı Öksürük"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Balgamli_Oksuruk { get; set; }

        [DisplayName("Göğüs Ağrısı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Gogus_Agrisi { get; set; }

        [DisplayName("Çarpıntı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Carpinti { get; set; }

        [DisplayName("Sırt Ağrısı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Sirt_Agrisi { get; set; }

        [DisplayName("İshal Kabızlık"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Ishal_Kabizlik { get; set; }

        [DisplayName("Eklem Ağrısı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Eklem_Agri { get; set; }

        [DisplayName("Kalp Hastalığı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kalp_Hastalik { get; set; }

        [DisplayName("Şeker Hastalığı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Seker_Hastalik { get; set; }

        [DisplayName("Böbrek Rahatszlığı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Bobrek_Rahatsizlik { get; set; }

        [DisplayName("Sarılık"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Sarilik { get; set; }

        [DisplayName("Mide Ülseri"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Mide_Ulser { get; set; }

        [DisplayName("İşitme Kaybı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Isitme_Kayip { get; set; }

        [DisplayName("Görmede Bozukluk"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Gorme_Bozukluk { get; set; }

        [DisplayName("Sinir Sistemi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Sinir_Sistemi { get; set; }

        [DisplayName("Deri Hastalığı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Deri_Hastalik { get; set; }

        [DisplayName("Besin Zehirlenmesi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Besin_Zehirlenme { get; set; }

        [DisplayName("Kanser"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kanser { get; set; }

        [DisplayName("Kas İskelet"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kas_Iskelet { get; set; }

        [DisplayName("Akciğer Solunumu"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Akciger_Solunum { get; set; }

        [DisplayName("Hastaneye Yatışı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Hastane_Yatis { get; set; }

        [DisplayName("Ameliuyat"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Ameliyat { get; set; }

        [DisplayName("İş Kazası"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Is_Kazasi { get; set; }

        [DisplayName("Meslek Hastalığı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Meslek_Hastalik { get; set; }

        [DisplayName("Maluliyet"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Maluliyet { get; set; }

        [DisplayName("Güncel Tedavi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Guncel_Tedavi { get; set; }

        [DisplayName("Sigara Alışkanlığı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Aliskanlik_Sigara { get; set; }

        [DisplayName("Alkol Alışkanlığı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Aliskanlik_Alkol { get; set; }

        [DisplayName("Uyuşturucu Alışkanlığı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Aliskanlik_Uyusturucu { get; set; }

        [DisplayName("Göz"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Fizik_Goz { get; set; }

        [DisplayName("Kulak Burn Boğaz"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Fizik_Kbb { get; set; }

        [DisplayName("Deri"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Fizik_Deri { get; set; }

        [DisplayName("Kardiyovasküler Sistem Muayenesi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Fizik_Kardiyovaskuler { get; set; }

        [DisplayName("Solunum Sistemi Muayenesi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Fizik_Solunum_Sistemi { get; set; }

        [DisplayName("Sindirim Sistemi Muayenesi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Fizik_Sindirim_Sistemi { get; set; }

        [DisplayName("Urogenital Sistem Muayenesi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Fizik_Urogenital { get; set; }

        [DisplayName("Kas-İskelet Muayenesi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Fizik_Kas_Iskelet { get; set; }

        [DisplayName("Nörolojik Muayenesi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Fizik_Norolojik { get; set; }

        [DisplayName("Psikiyatri Muayenesi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Fizik_Psikiyatri { get; set; }

        [DisplayName("Tansiyon"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Tansiyon { get; set; }

        [DisplayName("Nabız"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Nabiz { get; set; }

        [DisplayName("Kan"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Lab_Biyolojik_Kan { get; set; }

        [DisplayName("İdrar"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Lab_Biyolojik_Idrar { get; set; }

        [DisplayName("Radyolojil Bulgular"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Lab_Radyolojik { get; set; }

        [DisplayName("Odyometre"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Lab_Fizyolojik_Odyometre { get; set; }

        [DisplayName("SFT"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Lab_Fizyolojik_Sft { get; set; }

        [DisplayName("Psikolojik"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Lab_Psikolojik { get; set; }

        [DisplayName("Kanaat Ve Sonuç 1"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kanaat1 { get; set; }

        [DisplayName("Kanaat Ve Sonuç 2"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kanaat2 { get; set; }

        [DisplayName("Yüksekte Çalışma"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Yuksekte_Calisma { get; set; }

        [DisplayName("Vardiyalı Çalışma"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Vardiyali_Calisma { get; set; }

        [DisplayName("Konsültasyon Sonuç Durumu"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Konsultasyon { get; set; }

        [DisplayName("Personel"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Personel_Bilgi")]
        public long Personel_Id { get; set; }

        [DisplayName("İşveren"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Isveren")]
        public long Isveren_Id { get; set; }
    }
}
