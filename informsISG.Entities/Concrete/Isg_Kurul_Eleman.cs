using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Isg_Kurul_Eleman : EntityBase, IEntity
    {

        //FK
        public long Isg_Kurul_Karar_Id { get; set; }
        public long Personel_Id { get; set; }


        //FK Bağlantıları
        public virtual Isg_Kurul_Karar Isg_Kurul_Karar { get; set; }
        public virtual Personel_Bilgi Personel_Bilgi { get; set; }
    }
}
