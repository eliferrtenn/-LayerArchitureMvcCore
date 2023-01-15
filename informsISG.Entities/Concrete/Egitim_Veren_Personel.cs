using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Entities.Concrete
{
    public class Egitim_Veren_Personel : EntityBase, IEntity
    {
        //FK
        public long Egitim_Tanimla_Id { get; set; }
        public long Personel_Id { get; set; }
        public long Isveren_Id { get; set; }

        //FK Bağlantıları
        public virtual Egitim_Tanimla Egitim_Tanimla { get; set; }
        public virtual Personel_Bilgi Personel_Bilgi { get; set; }
        public virtual Isveren Isveren { get; set; }
    }
}
