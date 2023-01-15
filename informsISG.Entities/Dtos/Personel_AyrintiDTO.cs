using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Personel_AyrintiDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("ÇOCUK"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Cocuk { get; set; }

        [DisplayName("KARDEŞ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Kardes { get; set; }

        [DisplayName("EL KULLANIMI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int El_Kullanim { get; set; }

        [DisplayName("KİLO"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(10, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kilo { get; set; }

        [DisplayName("BOY"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(10, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Boy { get; set; }

        [DisplayName("KİTLE ENDEKSİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(10, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kitle_Endeks { get; set; }

        [DisplayName("ACİL DURUM"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Acil_Durum { get; set; }

        [DisplayName("KAN GRUBU"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(10, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kan_Grup { get; set; }

        [DisplayName("TETANOZ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Bagisiklik_Tetanoz { get; set; }

        [DisplayName("HEPATİT"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Bagisiklik_Hepatit { get; set; }

        [DisplayName("DİĞER BAĞIŞIKLIKLAR"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Bagisiklik_Diger { get; set; }

        [DisplayName("KALP"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Soy_Kalp { get; set; }

        [DisplayName("HİPERTANSİYON"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Soy_Hipertansiyon { get; set; }

        [DisplayName("ŞEKER"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Soy_Seker { get; set; }

        [DisplayName("NEFES DARLIĞI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Nefes_Darligi { get; set; }

        [DisplayName("ÇARPINTI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Carpinti { get; set; }

        [DisplayName("SIRT AĞRISI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Sirt_Agrisi { get; set; }

        [DisplayName("İSHAL KABIZLIK"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Ishal_Kabizlik { get; set; }

        [DisplayName("EKLEM AĞRISI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Eklem_Agri { get; set; }

        [DisplayName("KALP HASTALIĞI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kalp_Hastalik { get; set; }

        [DisplayName("ŞEKER HASTALIĞI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Seker_Hastalik { get; set; }

        [DisplayName("BÖBREK RAHATSIZLIĞI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Bobrek_Rahatsizlik { get; set; }

        [DisplayName("SARILIK"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Sarilik { get; set; }

        [DisplayName("ÜLSER"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Ulser { get; set; }

        [DisplayName("İŞİTME KAYBI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Isitme_Kayip { get; set; }

        [DisplayName("GÖRMEDE BOZUKLUK"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Gorme_Bozukluk { get; set; }

        [DisplayName("SİNİR SİSTEMİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Sinir_Sistemi { get; set; }

        [DisplayName("DERİ HASTALIĞI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Deri_Hastalik { get; set; }

        [DisplayName("BESİN ZEHİRLENMESİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Besin_Zehirlenme { get; set; }

        [DisplayName("HASTANEYE YATIŞ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Hastane_Yatis { get; set; }

        [DisplayName("AMELİYAT"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Ameliyat { get; set; }

        [DisplayName("İŞ KAZASI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Is_Kazasi { get; set; }

        [DisplayName("MESLEK HASTALIĞI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Meslek_Hastalik { get; set; }

        [DisplayName("MALULİYET"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Maluliyet { get; set; }

        [DisplayName("GÜNCEL TEDAVİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Guncel_Tedavi { get; set; }

        [DisplayName("SİGARA ALIŞKANLIĞI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Aliskanlik_Sigara { get; set; }

        [DisplayName("ALKOL ALIIŞKANLIĞI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Aliskanlik_Alkol { get; set; }

        [DisplayName("UYUŞTURUCU ALIŞKANLIĞI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Aliskanlik_Uyusturucu { get; set; }

        [DisplayName("DİĞER ALIŞKANLIKLAR"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Aliskanlik_Diger { get; set; }

        [DisplayName("PERSONEL NOTU"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Personel_Not { get; set; }

        [DisplayName("ENGELLİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Engelli { get; set; }

        [DisplayName("ESKİ HÜKÜMLÜ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Eski_Hukumlu { get; set; }

        [DisplayName("AĞIR TEHLİKELİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Agir_Tehlikeli { get; set; }

        [DisplayName("YÜKSEKTE ÇALIŞMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Yuksekte_Calisma { get; set; }

        [DisplayName("GECE VARDİYASI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Gece_Vardiya { get; set; }

        [DisplayName("UYGUNLUK DURUMU"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Uygunluk_Durumu { get; set; }

        [DisplayName("PERSONEL BİRİMİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Personel_Bilgi")]
        public long Personel_Id { get; set; }

    }
}
