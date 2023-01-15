using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Entities.Dtos
{
    public class Risk_KategoriDTO
    {
        public long Id { get; set; } = 0;


        [DisplayName("Kategori Adı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public string Risk_Kategori_Ad { get; set; }

    }
}
