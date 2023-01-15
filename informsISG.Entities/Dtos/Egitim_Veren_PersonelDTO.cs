using InformsISG.Entities.Concrete;
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
    public class Egitim_Veren_PersonelDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Eğitim Tanımı"),
            ForeignKey("Egitim_Tanimla")]
        public long Egitim_Tanimla_Id { get; set; }

        [DisplayName("Personel"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Personel_Bilgi")]
        public long Personel_Id { get; set; }

        [DisplayName("İşveren"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Isveren")]
        public long Isveren_Id { get; set; }

        public virtual Personel_Bilgi Personel_Bilgi { get; set; }
        public virtual Isveren Isveren { get; set; }
        public virtual Egitim_Tanimla Egitim_Tanimla { get; set; }
    }
}
