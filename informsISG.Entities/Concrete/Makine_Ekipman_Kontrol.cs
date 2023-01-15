using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Makine_Ekipman_Kontrol : EntityBase, IEntity
    {
        public string Kontrol_Ad { get; set; }

        //FK  
        [ForeignKey("Makine_Ekipman")]
        public long Makine_Ekipman_Id { get; set; }

        //FK Bağlantıları
        public virtual Makine_Ekipman Makine_Ekipman { get; set; }

        //Bire Çok İlişkiler
        public virtual ICollection<MakineVeEkipman_Kontrol> MakineVeEkipmanKontrolKriter { get; set; }

    }
}
