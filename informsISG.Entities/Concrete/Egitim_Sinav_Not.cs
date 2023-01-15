 using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Egitim_Sinav_Not : EntityBase, IEntity
    {
        //Tablo alanları
        public int Sinav_Not { get; set; }
        public string Aciklama { get; set; }

        //FK
        public long Personel_Id { get; set; }
        public long Egitim_Sinav_Id { get; set; }

        //FK Bağlantıları
        public virtual Personel_Bilgi Personel_Bilgi { get; set; }
        public virtual Egitim_Sinav Egitim_Sinav { get; set; }
    }
}
