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
    public class Egitim_Tanim_KonuDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Eğitim Tanımla"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Egitim_Tanimla")]
        public long Egitim_Tanimla_Id { get; set; }

        [DisplayName("Eğitim Konusu"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Egitim_Konu_Alt_Baslik")]
        public long Egitim_Konu_Alt_Baslik_Id { get; set; }
    }
}
