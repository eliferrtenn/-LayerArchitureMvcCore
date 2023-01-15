
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class RadyasyonDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("RADYASYON TARİHİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Radyasyon_Tarih { get; set; }

        [DisplayName("TEMAS ŞEKLİ 1"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Temas_Sekli1 { get; set; }

        [DisplayName("TEMAS ŞEKLİ 2"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Temas_Sekli2 { get; set; }

        [DisplayName("DİĞER TEMAS ŞEKLİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Temas_Sekli_Diger { get; set; }

        [DisplayName("LİMİT AŞIM"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Limit_Asim { get; set; }

        [DisplayName("LİMİT AŞIMI AÇIKLAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Limit_Asim_Aciklama { get; set; }

        [DisplayName("RADYASYON KAZASI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Radyasyon_Kaza { get; set; }

        [DisplayName("RADYASYON KAZASI AÇIKLAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Radyasyon_Kaza_Aciklama { get; set; }

        [DisplayName("RADYASYON MARUZU"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Radyasyon_Maruz { get; set; }

        [DisplayName("RADYASYON MARUZU AÇIKLAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Radyasyon_Maruz_Aciklama { get; set; }

        [DisplayName("CİLTTE SOLUKLUĞU"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Ciltte_Solukluk { get; set; }

        [DisplayName("CİLT SOLUKLUĞU AÇIKLAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Ciltte_Solukluk_Aciklama { get; set; }

        [DisplayName("GENEL YORGUNLUK"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Genel_Yorgunluk { get; set; }

        [DisplayName("GENEL YORGUNLUĞU AÇIKLAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Genel_Yorgunluk_Aciklama { get; set; }

        [DisplayName("BAŞ DÖNMESİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Bas_Donmesi { get; set; }

        [DisplayName("BAŞ DÖNMESİ AÇIKLAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Bas_Donmesi_Aciklama { get; set; }

        [DisplayName("ATEŞLİ HASTALIK"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Atesli_Hastalik { get; set; }

        [DisplayName("ATEŞLİ HASTALIĞI AÇIKLAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Atesli_Hastalik_Aciklama { get; set; }

        [DisplayName("UZUN SÜRELİ ENFEKSİYON"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Uzun_Sure_Enfeksiyon { get; set; }

        [DisplayName("UZUN SÜRELİ ENFEKSİYON AÇIKLAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Uzun_Sure_Enfeksiyon_Aciklama { get; set; }

        [DisplayName("UZUN SÜREN KANAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Uzun_Suren_Kanama { get; set; }

        [DisplayName("UZUN SÜREN KANAMA AÇIKLAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Uzun_Suren_Kanama_Aciklama { get; set; }

        [DisplayName("DİŞ ETİT KANAMASI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Dis_Eti_Kanama { get; set; }

        [DisplayName("DİŞ ETİ KANAMASI AÇIKLAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Dis_Eti_Kanama_Aciklama { get; set; }

        [DisplayName("CİLTTE MORLUKLAR"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Ciltte_Morluklar { get; set; }

        [DisplayName("CİLTTE MORLUKLAR AÇIKLAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Ciltte_Morluklar_Aciklama { get; set; }

        [DisplayName("KIL DÖNMESİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kil_Donmesi { get; set; }

        [DisplayName("UZUN SÜREN KANAMA AÇIKLAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kil_Donmesi_Aciklama  { get; set; }

        [DisplayName("CİLTTE BOZUKLUK"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Ciltte_Bozukluk { get; set; }

        [DisplayName("CİLTTE BOZUKLUK AÇIKLAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Ciltte_Bozukluk_Aciklama { get; set; }

        [DisplayName("GÖRMEDE BULANIKLIK"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Gorme_Bulaniklik { get; set; }

        [DisplayName("GÖRMEDE BULANIKLIK AÇIKLAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Gorme_Bulaniklik_Aciklama { get; set; }

        [DisplayName("LENF BÜYÜMESİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Lenf_Buyume { get; set; }

        [DisplayName("LENF BÜYÜMESİ AÇIKLAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Lenf_Buyume_Aciklama { get; set; }

        [DisplayName("TELENJİEKTAZİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Telenjiektazi { get; set; }

        [DisplayName("TELENJİEKTAZİ AÇIKLAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Telenjiektazi_Aciklama { get; set; }

        [DisplayName("HİPERKERATOZ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Hiperkeratoz { get; set; }

        [DisplayName("HİPERKERATOZ AÇIKLAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Hiperkeratoz_Aciklama { get; set; }

        [DisplayName("ATROFİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Atrofi { get; set; }

        [DisplayName("ATROFİ AÇIKLAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Atrofi_Aciklama { get; set; }

        [DisplayName("KIL DÖKÜLMESİ 2"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kil_Dokulmesi2 { get; set; }

        [DisplayName("KIL DÖKÜLMESİ 2 AÇIKLAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kil_Dokulmesi2_Aciklama { get; set; }

        [DisplayName("TIRNAK BOZUKLUĞU"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Tirnak_Bozukluk { get; set; }

        [DisplayName("TIRNAK BOZUKLUĞU AÇIKLAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Tirnak_Bozukluk_Aciklama { get; set; }

        [DisplayName("PERİFERİK LENFADENOPATİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Periferik_Lenfadenopatİ { get; set; }

        [DisplayName("PERİFERİK LENFADENOPATİ AÇIKLAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Periferik_Lenfadenopati_Aciklama { get; set; }

        [DisplayName("HEPATOSLENOMEGALİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Hepatosplenomegali { get; set; }

        [DisplayName("HEPATOSLENOMEGALİ AÇIKLAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Hepatosplenomegali_Aciklama { get; set; }

        [DisplayName("BEYAZ KÜRE"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Beyaz_Kure { get; set; }

        [DisplayName("TROMBOSİT"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Trombosit { get; set; }

        [DisplayName("HEMOGLOBİN"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Hemoglobin { get; set; }

        [DisplayName("KIRMIZI KÜRE"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kirmizi_Kure { get; set; }

        [DisplayName("LENFOSİT"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Lenfosit { get; set; }

        [DisplayName("NOTROFİL"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Notrofil { get; set; }

        [DisplayName("MONOSİT"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Monosit { get; set; }

        [DisplayName("EOZİNOFİL"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string  Eozinofil{ get; set; }

        [DisplayName("BAZOFİL"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Bazofil { get; set; }

        [DisplayName("NORMAL DIŞI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Normal_Disi { get; set; }

        [DisplayName("KATARAKT"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Katarakt { get; set; }

        [DisplayName("GÖZ UZMANI DEĞERLENDİRMESİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Goz_Uzman_Degerlendirme { get; set; }

        [DisplayName("AÇIKLAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Aciklama { get; set; }

        [DisplayName("DİĞER HUSUS"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Diger_Husus { get; set; }

        [DisplayName("AÇ GRAFİĞİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(300, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Ac_Grafisi { get; set; }

        [DisplayName("PERİFERİK YAYMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(300, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Periferik_Yayma { get; set; }

        [DisplayName("HASTALIK ÖYKÜSÜ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(300, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Hastalik_Oykusu { get; set; }

        [DisplayName("EK BİYOKİMYA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(300, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Ek_Biyokimya { get; set; }

        [DisplayName("KULLANDIĞI İLAÇLAR"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(300, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kullandigi_Ilaclar { get; set; }

        [DisplayName("PERSONEL"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Personel_Bilgi")]
        public long Personel_Id { get; set; }

        [DisplayName("İŞVEREN"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Isveren")]
        public long Isveren_Id { get; set; }
    }
}
