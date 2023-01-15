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
    public class Isg_Kurul_Karar2DTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Karar No"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Karar_No { get; set; }

        [DisplayName("Alınan Kararlar"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(1000, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Alinan_Kararlar { get; set; }

        [DisplayName("Tamalandı Durumu")]
        public bool? TamamlandiMi { get; set; }


        [DisplayName("Başlangıç Tarihi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Baslangic_Tarih { get; set; }

        [DisplayName("Bitiş Tarihi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Bitis_Tarih { get; set; }

        [DisplayName("Isg Kurulu"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Isg_Kurul_Karar_Id")]
        public long Isg_Kurul_Karar_Id { get; set; }

        [DisplayName("Personel"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Personel_Id")]
        public long Personel_Id { get; set; }
    }
}
