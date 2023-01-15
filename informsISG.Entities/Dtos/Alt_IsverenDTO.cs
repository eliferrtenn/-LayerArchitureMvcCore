using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Alt_IsverenDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("İşveren Adı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Alt_Isveren_Ad { get; set; }

        [DisplayName("Notlar"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Notlar { get; set; }

        [DisplayName("Kontrol Durumu"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kontrol_Edildi { get; set; }

        [DisplayName("İsg Kurul"),
            ForeignKey("Isg_Kurul")]
        public long Isg_Kurul_Id { get; set; }

    }
}