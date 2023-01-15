using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class BirimDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Birim Adı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Birim_Ad { get; set; }

        [DisplayName("Nace Kodu"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Nace_Kod { get; set; }

        [DisplayName("Sgk No"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Sgk_No { get; set; }

        [DisplayName("Açıklama"),
           Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
           MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Aciklama { get; set; }

        [DisplayName("İsg Kurul"),
            ForeignKey("Isg_Kurul")]
        public long Isg_Kurul_Id { get; set; }

        [DisplayName("İşveren"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Isveren")]
        public long Isveren_Id { get; set; }
    }
}
