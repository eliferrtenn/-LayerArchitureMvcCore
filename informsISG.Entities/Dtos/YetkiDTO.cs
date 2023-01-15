using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos

{
    public class YetkiDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Yetki Adı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(80, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Yetki_Ad { get; set; }

 
    }
}
