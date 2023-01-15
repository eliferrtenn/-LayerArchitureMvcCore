using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Egitim_SinavDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Sınavın Adı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Sinav_Ad { get; set; }

        [DisplayName("Sınavın Tarihi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Sinav_Tarih { get; set; }

        [DisplayName("Sınavın  Süresi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(10, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Sinav_Saat { get; set; }

        [DisplayName("Eğitimin Tanımı"),
            ForeignKey("Egitim_Tanimla")]
        public long Egitim_Tanimla_Id { get; set; }

        [DisplayName("Isg Kurulu"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Isg_Kurul")]
        public long Isg_Kurul_Id { get; set; }

        [DisplayName("İşveren"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Isveren")]
        public long Isveren_Id { get; set; }
    }
}
