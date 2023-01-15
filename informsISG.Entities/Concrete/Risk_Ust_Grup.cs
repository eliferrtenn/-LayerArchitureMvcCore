using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Risk_Ust_Grup : EntityBase, IEntity
    {
        public string Risk_Ust_Grup_Adi { get; set; }

        //FK
        public long Risk_Kategori_Id { get; set; }

        //FK Bağlantıları
        public virtual Risk_Kategori Risk_Kategori { get; set; }

        //Bire çok ilişkiler
        public virtual ICollection<Risk_Konu_Grup> Risk_Konu_Grup { get; set; }
        public virtual ICollection<Risk_Kutuphane> Risk_Kutuphane { get; set; }
        public virtual ICollection<Risk_Analiz> Risk_Analiz { get; set; }

    }
}
