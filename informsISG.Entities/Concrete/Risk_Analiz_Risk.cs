
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Risk_Analiz_Risk : EntityBase, IEntity
    {
        //Tablo alanları
        public string Risk { get; set; }
        public bool Aktif { get; set; }

        //Bire Çok İlişkiler
        public virtual ICollection<Risk_Analiz_Tablo> Risk_Analiz_Tablo { get; set; }
        public virtual ICollection<Kaza_Personel_Disi> Kaza_Personel_Disi { get; set; }

    }
}
