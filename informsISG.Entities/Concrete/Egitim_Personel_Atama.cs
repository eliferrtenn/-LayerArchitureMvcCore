using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Egitim_Personel_Atama : EntityBase , IEntity
    {
        //Tablo alanları
        public int Egitime_Katilim { get; set; }
        public bool Sertifika_Basildi { get; set; }

        //FK
        public long Egitim_Tanimla_Id { get; set; }
        public long Personel_Id { get; set; }

        //FK Bağlantıları
        public virtual Egitim_Tanimla Egitim_Tanimla { get; set; }
        public virtual Personel_Bilgi Personel_Bilgi { get; set; }
    }
}
