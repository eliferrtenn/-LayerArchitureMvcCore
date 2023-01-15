
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Yaralanma_Sekli : EntityBase, IEntity
    {
        //Tablo alanları
        public string Yaralanma_Sekli_Ad { get; set; }

        //Bire Çok İlişkiler
        public virtual ICollection<Kaza_Personel_Disi> Kaza_Personel_Disi { get; set; }
        public virtual ICollection<Kaza> Kaza { get; set; }
    }
}
