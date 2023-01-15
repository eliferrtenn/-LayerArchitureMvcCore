
using InformsISG.Core.Entities.Abstract;
using InformsISG.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Kkd_TurDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("KKD Tür Adı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kkd_Tur_Ad { get; set; }

        public virtual ICollection<Kkd_Tur_Alt> Kkd_Tur_Alt { get; set; }

    }
}
