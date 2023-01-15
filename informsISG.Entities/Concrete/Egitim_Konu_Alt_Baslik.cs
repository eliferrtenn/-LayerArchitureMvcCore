 using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Egitim_Konu_Alt_Baslik : EntityBase , IEntity
    {
        //Tablo alanları
        public string Alt_Baslik_No { get; set; }
        public string Alt_Baslik_Ad { get; set; }
        public int Tehlike_Tip { get; set; }
        public string Sure { get; set; }

        //FK
        public long Egitim_Konu_Id { get; set; }

        //FK Bağlantıları
        public virtual Egitim_Konu Egitim_Konu { get; set; }

        //Bire çok ilişkiler
        public virtual ICollection<Egitim_Tanim_Konu> Egitim_Tanim_Konu { get; set; }
    }
}
