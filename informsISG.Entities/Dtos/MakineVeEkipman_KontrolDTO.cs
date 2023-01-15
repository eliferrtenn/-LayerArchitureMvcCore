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
    public class MakineVeEkipman_KontrolDTO
    {
        public long Id { get; set; } = 0;

        [DisplayName("Uygunluk Durumu")]
        public bool Uygun { get; set; }

        [DisplayName("Değerlendirme")]
        public int Degerlendirme { get; set; }

        [DisplayName("Makine Ekipman"),
            ForeignKey("Makine_Ekipman")]
        public string Makine_Ekipman_Id { get; set; }

        [DisplayName("Makine"),
            ForeignKey("Makine")]
        public string Makine_Id { get; set; }

        [DisplayName("Makine Kontrol Kriter Başlık"),
            ForeignKey("Makine_Kontrol_Kriter_Baslik")]
        public string Makine_Kontrol_Kriter_Baslik_Id { get; set; }

        [DisplayName("Makine Kontrol Kriter"),
            ForeignKey("Makine_Kontrol_Kriter_Id")]
        public string Makine_Kontrol_Kriter_Id { get; set; }
    }
}
