using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Entities.Concrete
{
    public class Isg_Kurul_Karar_Gundem : EntityBase, IEntity
    {
        //Tablo alanları
        public string Maddeler { get; set; }

        //FK
        public long Isg_Kurul_Karar_Id { get; set; }

        //FK Bağlantıları
        public virtual Isg_Kurul_Karar Isg_Kurul_Karar { get; set; }
    }
}
