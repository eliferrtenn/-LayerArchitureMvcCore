 using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Egitim_Konu_Alt_BaslikDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Alt Başlık No"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(5, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Alt_Baslik_No { get; set; }

        [DisplayName("Alt Başlık Adı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(200, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Alt_Baslik_Ad { get; set; }

        [DisplayName("Tehlike Tipi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Tehlike_Tip { get; set; }

        [DisplayName("Süresi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(5, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Sure { get; set; }

        [DisplayName("Eğitim Konusu"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Egitim_Konu")]
        public long Egitim_Konu_Id { get; set; }
    }
}
