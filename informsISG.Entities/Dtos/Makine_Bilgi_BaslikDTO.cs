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
    public class Makine_Bilgi_BaslikDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Madde Adı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Madde_Ad { get; set; }

        [DisplayName("Makine"),
            ForeignKey("Makine")]
        public long Makine_Id { get; set; }
    }
}
