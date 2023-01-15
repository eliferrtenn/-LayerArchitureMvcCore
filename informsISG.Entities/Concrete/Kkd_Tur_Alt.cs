
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Kkd_Tur_Alt: EntityBase, IEntity
    {
        //Tablo alanları
        public string Kkd_Tur_Alt_Ad { get; set; }

        //FK
        public long Kkd_Tur_Id { get; set; }

        //FK Bağlantıları
        public virtual Kkd_Tur Kkd_Tur { get; set; }

        //Bire Çok İlişkiler
        public virtual ICollection<Kkd> Kkd { get; set; }
    }
}
