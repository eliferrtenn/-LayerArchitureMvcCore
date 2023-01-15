using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Entities.Concrete
{
    public class Makine_Ekipman_Olcum_Aleti_Bilgiler : EntityBase, IEntity
    {
        public string Madde_Ad { get; set; }
        public string Madde_Ad_Karsilik { get; set; }

        //FK
        [ForeignKey("Makine_Ekipman")]
        public long Makine_Ekipman_Id { get; set; }

        //FK Bağlantıları
        public virtual Makine_Ekipman Makine_Ekipman { get; set; }

    }
}
