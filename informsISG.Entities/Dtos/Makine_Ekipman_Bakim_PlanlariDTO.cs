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
    public class Makine_Ekipman_Bakim_PlanlariDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Servis Tarihi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Servis_Tarih { get; set; }

        [DisplayName("Bakım Tipi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Bakim_Tip { get; set; }

        [DisplayName("Yapılan İşlem"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Yapilan_Islem { get; set; }

        [DisplayName("Açıklama"),
            MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Aciklama { get; set; }

        [DisplayName("Diğer Servis Tarihi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Diger_Servis_Tarih { get; set; }

        [DisplayName("Durum"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Durum { get; set; }

        [DisplayName("Onay Birimi Sorumlusu"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int OnayBirimSorumlu { get; set; }

        [DisplayName("OnaY Isg Uzmanı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int OnayIsgUzman { get; set; }

        [DisplayName("Makine Ekipman"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Makine_Ekipman")]
        public long Makine_Ekipman_Id { get; set; }
    }
}
