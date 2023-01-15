using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Isg_Kurul_ElemanDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("İsg Kurul Toplantısı"),
           Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
           ForeignKey("Isg_Kurul_Karar")]
        public long Isg_Kurul_Karar_Id { get; set; }

        [DisplayName("Personel"),
           Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
           ForeignKey("Personel_Bilgi")]
        public long Personel_Id { get; set; }
    }
}
