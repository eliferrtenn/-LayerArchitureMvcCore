using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace InformsISG.Entities.Concrete
{
    public class MakineVeEkipman_Kontrol : EntityBase, IEntity
    {
        public bool? Uygun { get; set; }
        public int? Degerlendirme { get; set; }

        //FK  
        [ForeignKey("Makine_Ekipman")]
        public long Makine_Ekipman_Id { get; set; }
        [ForeignKey("Makine")]
        public long Makine_Id { get; set; }
        [ForeignKey("Makine_Kontrol_Kriter_Baslik")]
        public long Makine_Kontrol_Kriter_Baslik_Id { get; set; }
        [ForeignKey("Makine_Kontrol_Kriter")]
        public long Makine_Kontrol_Kriter_Id { get; set; }

        //FK Bağlantıları
        public virtual Makine_Ekipman Makine_Ekipman { get; set; }
        public virtual Makine Makine { get; set; }
        public virtual Makine_Kontrol_Kriter_Baslik Makine_Kontrol_Kriter_Baslik { get; set; }
        public virtual Makine_Kontrol_Kriter Makine_Kontrol_Kriter { get; set; }
    }
}
