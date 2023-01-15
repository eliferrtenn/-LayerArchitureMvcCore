using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Acil_Durum_Ekipleri: EntityBase , IEntity
    {
        //Tablo Alanları
        public string Ekip_Ad { get; set; }

        //Bire çok ilişkiler
        public virtual ICollection<Acil_Durum_Ekip_Personel> Acil_Durum_Ekip_Personel { get; set; }
    }
}
