using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Makine_Ekipman_Kontrol_Kriter_BaslikDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Kriter Başlık Adı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(300, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Madde_Ad { get; set; }

        [DisplayName("Not"),
            MaxLength(3500, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Notlar { get; set; }


        [DisplayName("Makine Ekipman"),
            ForeignKey("Makine_Ekipman")]
        public long Makine_Ekipman_Id { get; set; }
    }
}
