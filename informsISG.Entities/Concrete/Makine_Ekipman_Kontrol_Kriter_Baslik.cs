using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InformsISG.Entities.Concrete
{
    public class Makine_Ekipman_Kontrol_Kriter_Baslik : EntityBase, IEntity
    {
        public string Madde_Ad { get; set; }
        public string Notlar { get; set; }

        //FK
        public long Makine_Ekipman_Id { get; set; }

        //FK Bağlantıları
        public virtual Makine_Ekipman Makine_Ekipman { get; set; }

        //Bire Çok İlişkiler
        public virtual ICollection<Makine_Ekipman_Kontrol_Kriter> Makine_Ekipman_Kontrol_Kriter { get; set; }
    }
}
