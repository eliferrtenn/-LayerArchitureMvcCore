using InformsISG.Core.Entities.Abstract;
using InformsISG.Entities.Concrete;
using InformsISG.Entities.Dtos.Validation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.RegularExpressions;

namespace InformsISG.Entities.Dtos
{
    public class KullaniciDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Şifre"),
            Required(ErrorMessage = "Lütfen {0} alanını boş m."),
            MaxLength(32, ErrorMessage = "{0} en fazla {1} karakter olabilir"),]
        public string Password { get; set; }

        [DisplayName("Mail"),
             Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
             MaxLength(80, ErrorMessage = "{0} en fazla {1} karakter olabilir"),
            EmailAddress(ErrorMessage = "Lütfen  alana uygun {0} giriniz")]
        public string Mail { get; set; }

        [DisplayName("Yetki"),
             Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public long Yetki_Id { get; set; }

        [DisplayName("Birim"),
            ForeignKey("Isg_Kurul")]
        public long Birim_Id { get; set; }


        [DisplayName("Personel")]
        public long Personel_Id { get; set; }

        public object Personel { get; set; }

        public Yetki Yetki { get; set; }



    }
}
