using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Entities.Concrete
{
    public class Acil_Durum_Tatbikat : EntityBase, IEntity
    {
        public string Tatbikat_Ad { get; set; }
        public DateTime Tatbikat_Tarih { get; set; }
        public string Aciklama { get; set; }
        public bool Onay { get; set; } = false;


        //FK
        [ForeignKey("Tali_Birim")]
        public long Tali_Birim_Id { get; set; }

        //FK Bağlantıları
        public virtual Tali_Birim Tali_Birim { get; set; }
    }
}
