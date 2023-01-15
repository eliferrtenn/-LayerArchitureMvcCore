
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Risk_YontemDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Risk Analz Yöntemi"),
            MaxLength(50, ErrorMessage = "{0} en fazla {1} karakter olabilir"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public string Risk_Yontem_Ad { get; set; }

    }
}
