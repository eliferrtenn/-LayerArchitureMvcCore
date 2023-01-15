using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Entities.Concrete
{
    public class Kkd_Personel_Atama : EntityBase,IEntity
    {

        //FK
        public long Kkd_Id { get; set; }
        public long Personel_Id { get; set; }


        //FK Bağlantıları
        public virtual Kkd Kkd { get; set; }
        public virtual Personel_Bilgi Personel_Bilgi { get; set; }
    }
}
