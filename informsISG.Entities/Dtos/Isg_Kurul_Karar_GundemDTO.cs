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
    public class Isg_Kurul_Karar_GundemDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Gündem Maddesi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(300, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Maddeler { get; set; }


        [DisplayName("İsg Kurul Kararı"),
           Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
           ForeignKey("Isg_Kurul")]
        public long Isg_Kurul_Karar_Id { get; set; }
    }
}
