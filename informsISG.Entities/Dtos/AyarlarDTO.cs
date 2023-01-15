using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class AyarlarDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("TEHLİKE TİP"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Tehlike_Tip { get; set; }

        [DisplayName("EĞİTİM SÜRESİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Egitim_Sure { get; set; }

        [DisplayName("EĞİTİM SÜRESİ SIKLIĞI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
             MaxLength(25, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Egitim_Sure_Periyot { get; set; }

        [DisplayName("RİSK SÜRESİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Risk_Sure { get; set; }

        [DisplayName("RİSK SÜRESİ SIKLIĞI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
             MaxLength(25, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Risk_Sure_Periyot { get; set; }

        [DisplayName("SAĞLIK KONTROL"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Saglik_Kontrol { get; set; }

        [DisplayName("SAĞLIK KONTROL SIKLIĞI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
             MaxLength(25, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Saglik_Kontrol_Periyot { get; set; }

        [DisplayName("İGU SÜRE"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Igu_Sure { get; set; }

        [DisplayName("İGU SÜRE SIKLIĞI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
             MaxLength(25, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Igu_Sure_Periyot { get; set; }
    }
}
