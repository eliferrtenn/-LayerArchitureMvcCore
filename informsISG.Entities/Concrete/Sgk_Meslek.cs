
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Sgk_Meslek : EntityBase, IEntity
    {
        //Tablo alanları
        public string Isco08 { get; set; }
        public string Meslek_Ad { get; set; }

        //Bire çok ilişkiler
        public virtual ICollection<Personel_Bilgi> Personel_Bilgi { get; set; }
    }
}
