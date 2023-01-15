
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Ortam_OlcumDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Ölçüm Türü"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Olcum_Tur { get; set; }

        [DisplayName("Ölçüm Tarihi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Olcum_Tarih { get; set; }

        [DisplayName("Ölçüm Sonucu"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Olcum_Sonuc { get; set; }

        [DisplayName("Ölçüm Birimi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(10, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Olcum_Birim { get; set; }

        [DisplayName("Açıklama"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Aciklama { get; set; }

        [DisplayName("Tali Birimi"), 
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Tali_Birim")]
        public long Tali_Birim_Id { get; set; }

        [DisplayName("İşveren"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Isveren")]
        public long Isveren_Id { get; set; }

    }
}
