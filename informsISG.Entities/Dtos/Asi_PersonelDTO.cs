using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Asi_PersonelDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("İŞLEM TARİHİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Islem_Tarih { get; set; }

        [DisplayName("UYGULAYANIN ADI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(75, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Uygulayan_Ad { get; set; }

        [DisplayName("AŞI DOZ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(10, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Asi_Doz { get; set; }

        [DisplayName("UYGULANAN YER"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Uygulama_Yer { get; set; }

        [DisplayName("UYGULANMA ŞEKLİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(75, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Uygulama_Sekil { get; set; }

        [DisplayName("UYGULAANMA DURUMU"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Uygulandi { get; set; }

        [DisplayName("AÇIKLAMA"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Aciklama { get; set; }

        [Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
          ForeignKey("Asi_Tur")]
        public long Asi_Tur_Id { get; set; }

        [Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
          ForeignKey("Personel_Bilgi")]
        public long Personel_Id { get; set; }
    }
}
