using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Asi_TurDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("AD"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Asi_Ad { get; set; }

        [DisplayName("AÇIKLAMA"),
           Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
           MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Aciklama { get; set; }
    }
}
