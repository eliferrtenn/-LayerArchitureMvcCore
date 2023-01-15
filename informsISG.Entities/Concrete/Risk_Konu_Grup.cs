using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Risk_Konu_Grup : EntityBase, IEntity
    {
        public string Risk_Konu_Grup_Adi { get; set; }

        //FK
        public long Risk_Ust_Grup_Id { get; set; }

        //FK Bağlantıları
        public virtual Risk_Ust_Grup Risk_Ust_Grup { get; set; }

        //Bire Çok İlişkiler
        public virtual ICollection<Risk_Konu> Risk_Konu { get; set; }
        public virtual ICollection<Risk_Kutuphane> Risk_Kutuphane { get; set; }
        public virtual ICollection<Risk_Analiz> Risk_Analiz { get; set; }


    }
}
