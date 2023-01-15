using InformsISG.Core.Entities.Abstract;
using InformsISG.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Egitim_Personel_AtamaDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Eğitime Katılımı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Egitime_Katilim { get; set; }

        [DisplayName("Sertifika Basıldı Mı ?"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Sertifika_Basildi { get; set; }

        [DisplayName("Eğitim Tanımı"), 
            ForeignKey("Egitim_Tanimla")]
        public long Egitim_Tanimla_Id { get; set; }

        [DisplayName("Personel"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Personel_Bilgi")]
        public long Personel_Id { get; set; }

        public virtual Personel_Bilgi Personel_Bilgi { get; set; }
    }
}
