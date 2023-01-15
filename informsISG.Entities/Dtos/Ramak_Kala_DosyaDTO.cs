using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Entities.Dtos
{
    public class Ramak_Kala_DosyaDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Dosya"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Dosya { get; set; }

        [DisplayName("Ramak Kala"),
            ForeignKey("Ramak_Kala")]
        public long Ramak_Kala_Id { get; set; }

    }
}
