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
    public class Acil_Durum_TatbikatDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Tatbikat Adı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Tatbikat_Ad { get; set; }

        [DisplayName("Tatbikat Tarihi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public DateTime Tatbikat_Tarih { get; set; }

        [DisplayName("Açıklama"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(300, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Aciklama { get; set; }

        [DisplayName("Yapılma Durumu"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Onay { get; set; }

        [DisplayName("Tali Birim"), 
            ForeignKey("Tali_Birim")]
        public long Tali_Birim_Id { get; set; }


    }
}
