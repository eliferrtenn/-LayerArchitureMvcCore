using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Asi_Tur: EntityBase , IEntity
    {
        //Tablo alanları
        public string Asi_Ad { get; set; }
        public string Aciklama { get; set; }

        //Bire çok ilişkiler
        public virtual ICollection<Asi_Sureleri> Asi_Sureleri { get; set; }
        public virtual ICollection<Asi_Personel> Asi_Personel { get; set; }
    }
}
