using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Entities.Dtos
{
    public class Acil_Durum_EkipleriDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Ekip Adı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Ekip_Ad { get; set; }

    }
}
