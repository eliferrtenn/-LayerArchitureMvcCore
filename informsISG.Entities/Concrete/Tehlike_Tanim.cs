using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Tehlike_Tanim : EntityBase, IEntity
    {
        //Tablo alanları
        public string Tehlike_Tanim_Ad { get; set; }


        //Bire Çok İlişkiler
        public ICollection<Risk_Analiz_Tablo> Risk_Analiz_Tablo { get; set; }

    
}
}
