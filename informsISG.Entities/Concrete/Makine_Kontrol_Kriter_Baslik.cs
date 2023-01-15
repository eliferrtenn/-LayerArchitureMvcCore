using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InformsISG.Entities.Concrete
{
    public class Makine_Kontrol_Kriter_Baslik : EntityBase, IEntity
    {
        public string Baslik_Ad { get; set; }

        //FK
        public long Makine_Id { get; set; }

        //FK Bağlantıları
        public virtual Makine Makine { get; set; }

        //Bire Çok İlişkiler
        public virtual ICollection<Makine_Kontrol_Kriter> Makine_Kontrol_Kriter { get; set; }
        public virtual ICollection<MakineVeEkipman_Kontrol> MakineVeEkipman_KontrolKriter { get; set; }
    }
}
