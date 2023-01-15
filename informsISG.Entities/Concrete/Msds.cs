
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Msds : EntityBase, IEntity
    {
        //Tablo alanları
        public string Urun_Ad { get; set; }

        //FK
        public long Isg_Kurul_Id { get; set; }
        public long Isveren_Id { get; set; }

        //FK BAĞLANTILARI
        public virtual Isg_Kurul Isg_Kurul { get; set; }
        public virtual Isveren Isveren { get; set; }

        //Bire Çok İlişkiler
        public virtual ICollection<Msds_Dosya> Msds_Dosya { get; set; }

    }
}
