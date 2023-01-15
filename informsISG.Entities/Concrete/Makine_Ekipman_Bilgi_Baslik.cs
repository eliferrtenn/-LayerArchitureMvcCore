using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Entities.Concrete
{
    public class Makine_Ekipman_Bilgi_Baslik : EntityBase, IEntity
    {
        public string Madde_Ad { get; set; }

        //FK
        [ForeignKey("Makine_Ekipman")]
        public long Makine_Ekipman_Id { get; set; }

        //FK Bağlantıları
        public virtual Makine_Ekipman Makine_Ekipman { get; set; }

        //Bire Çok İlişkiler
        public virtual ICollection<Makine_Ekipman_Bilgiler> Makine_Ekipman_Bilgiler { get; set; }
    }
}
