using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Risk_Kategori : EntityBase, IEntity
    {
        public string Risk_Kategori_Ad { get; set; }

        //Bire Çok İlişkiler
        public virtual ICollection<Risk_Analiz> Risk_Analiz { get; set; }
        public virtual ICollection<Risk_Kutuphane> Risk_Kutuphane { get; set; }
        public virtual ICollection<Risk_Ust_Grup> Risk_Ust_Grup { get; set; }

    }
}
