
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Dtos
{
    public class Yaralanan_Vucut_BolgesiDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Yarlanana Vucüt Bölgesi"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(200, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Yaralanan_Vucut_Bolgesi_Ad { get; set; }
    }
}
