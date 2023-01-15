using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Entities.Dtos
{
    public class Risk_KonuDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Konu Adı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(800, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Risk_Konu_Adi { get; set; }

        [DisplayName("Konu Grup"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public long Risk_Konu_Grup_Id { get; set; }
    }
}
