using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Entities.Dtos
{
    public class Risk_Ust_GrupDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Üst Grup Adı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public string Risk_Ust_Grup_Adi { get; set; }

        [DisplayName("Kategori"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public long Risk_Kategori_Id { get; set; }


    }
}
