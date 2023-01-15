using InformsISG.Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Entities.Concrete
{
    public class Makine_Ekipman_Kontrol_Kriter : EntityBase, IEntity
    {
        public string Madde_Ad { get; set; }
        public bool Uygun { get; set; }
        public int? Degerlendirme { get; set; }

        //FK
        [ForeignKey("Makine_Ekipman_Kontrol_Kriter_Baslik")]
        public long Makine_Ekipman_Kontrol_Kriter_Baslik_Id { get; set; }

        //FK Bağlantıları
        public virtual Makine_Ekipman_Kontrol_Kriter_Baslik Makine_Ekipman_Kontrol_Kriter_Baslik { get; set; }


    }
}
