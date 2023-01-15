
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Kkd_Tur : EntityBase, IEntity
    {
        //Tablo alanları
        public string Kkd_Tur_Ad { get; set; }

        //Bire çok ilişkiler
        public virtual ICollection<Kkd_Tur_Alt> Kkd_Tur_Alt { get; set; }
        public virtual ICollection<Kkd> Kkd { get; set; }
    }
}
