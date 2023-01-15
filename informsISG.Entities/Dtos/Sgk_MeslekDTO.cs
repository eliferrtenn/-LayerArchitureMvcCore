
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Sgk_MeslekDTO
    {
        public long Id { get; set; } = 0;

        [MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Isco08 { get; set; }

        [DisplayName("MESLEK ADI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Meslek_Ad { get; set; }
    }
}
