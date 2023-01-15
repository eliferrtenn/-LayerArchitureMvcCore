
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Yaralanma_SekliDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Yaralanma Şekli"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(200, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Yaralanma_Sekli_Ad { get; set; }
    }
}
