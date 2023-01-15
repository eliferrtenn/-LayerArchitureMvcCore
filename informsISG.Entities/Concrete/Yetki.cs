using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Yetki : EntityBase, IEntity
    {
        public string Yetki_Ad { get; set; }

        //Bire Çok İlişkiler
        public virtual ICollection<Kullanici> Kullanici { get; set; }
    }
}
