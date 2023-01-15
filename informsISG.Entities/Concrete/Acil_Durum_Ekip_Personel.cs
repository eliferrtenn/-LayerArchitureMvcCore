using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Acil_Durum_Ekip_Personel : EntityBase , IEntity
    {
        public bool Ekip_Lideri { get; set; }
        public string Aciklama { get; set; }

        //FK
        public long Birim_Id { get; set; }
        public long Personel_Id { get; set; }
        [ForeignKey("Acil_Durum_Ekipleri")]
        public long Ekip_Id { get; set; }

        //FK Bağlantıları
        public virtual Birim Birim { get; set; }
        public virtual Personel_Bilgi Personel_Bilgi { get; set; }
        public virtual Acil_Durum_Ekipleri Acil_Durum_Ekipleri { get; set; }
    }
}
