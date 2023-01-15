using InformsISG.Entities.Concrete;
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
    public class Makine_Ekipman_Bakim_FotografDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Yapılan İşlem"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Dosya { get; set; }

        public long Makine_Ekipman_Bakim_Planlari_Id { get; set; }


        [ForeignKey("Makine_Ekipman_Bakim_Planlari_Id ")]
        public Makine_Ekipman_Bakim_Planlari Makine_Ekipman_Bakim_Planlari { get; set; }
    }
}
