using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Isg_KurulDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Kurul Adı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kurul_Ad { get; set; }

        [DisplayName("Açıklama"),
            MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Aciklama { get; set; }

        [DisplayName("Tehlike Tipi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Tehlike_Tip { get; set; }
    }
}
