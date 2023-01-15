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
    public class Egitim_TanimlaDTO
    {
        public long Id { get; set; }

        [DisplayName("Eğitim Adı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(90, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Egitim_Ad { get; set; }

        [DisplayName("Eğitim Sebebi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Egitim_Sebep { get; set; }

        [DisplayName("Eğitim Tarihi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            DataType(DataType.Date)]
        public DateTime Egitim_Tarih { get; set; }

        [DisplayName("Eğitim Türü"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public int Egitim_Tur { get; set; }

        [DisplayName("Eğitim Yeri"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(1, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Egitim_Yer { get; set; }

        [DisplayName("Eğitim Yer Adı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Egitim_Yer_Ad { get; set; }

        [DisplayName("Tekrar Tarihi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            DataType(DataType.Date)]
        public DateTime Tekrar_Tarih { get; set; }

        [DisplayName("Açıklama"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Aciklama { get; set; }

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
