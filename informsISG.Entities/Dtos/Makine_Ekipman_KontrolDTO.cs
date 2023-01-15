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
    public class Makine_Ekipman_KontrolDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("KONTROL"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Kontrol_Ad { get; set; }


        [DisplayName("Makine Ekipman"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Makine_Ekipman")]
        public long Makine_Ekipman_Id { get; set; }

    }
}
