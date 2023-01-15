using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Entities.Dtos
{
    public class Makine_Ekipman_BilgilerDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Madde Adı"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Madde_Ad { get; set; }

        [DisplayName("Madde Ad ")]
        public string Madde_Ad_Karsilik { get; set; }

        [DisplayName("Makine Ekipman Bilgi Başlığı"),
            ForeignKey("Makine_Ekipman_Bilgi_Baslik")]
        public long Makine_Ekipman_Bilgi_Baslik_Id { get; set; }
    }
}
