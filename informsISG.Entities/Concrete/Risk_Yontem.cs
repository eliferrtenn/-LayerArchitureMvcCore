using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Risk_Yontem : EntityBase, IEntity
    {
        //Tablo alanları
        public string Risk_Yontem_Ad { get; set; }

        //Bire Çok İlişkiler
        public virtual ICollection<Risk_Analiz> Risk_Analiz { get; set; }
    }
}
