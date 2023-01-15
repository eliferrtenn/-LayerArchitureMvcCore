using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Asi_SureleriDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("YAŞ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Yas { get; set; }

        [DisplayName("PERİYOT BİRİMİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(5, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Periyot_Birim { get; set; }

        [DisplayName("SÜREKLİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Surekli { get; set; }

        [DisplayName("PERİYOT1 1"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Periyot1_1 { get; set; }

        [DisplayName("PERİYOT1 2"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Periyot1_2 { get; set; }

        [DisplayName("PERİYOT2 1 "),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Periyot2_1 { get; set; }

        [DisplayName("PERİYOT2 2"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Periyot2_2{ get; set; }

        [DisplayName("PERİYOT3 1"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Periyot3_1 { get; set; }

        [DisplayName("PERİYOT3 2"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Periyot3_2 { get; set; }

        [DisplayName("PERİYOT4 1"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Periyot4_1 { get; set; }

        [DisplayName("PERİYOT4 2"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Periyot4_2 { get; set; }

        [DisplayName("PERİYOT5 1"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Periyot5_1 { get; set; }

        [DisplayName("PERİYOT5 2"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Periyot5_2 { get; set; }

        [Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
           ForeignKey("Asi_Tur")]
        public long Asi_Tur_Id { get; set; }
    }
}
