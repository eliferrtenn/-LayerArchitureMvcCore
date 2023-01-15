using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Egitim_Konu : EntityBase , IEntity
    {
        //Tablo alanları
        public string Egitim_Ad { get; set; }

        //Bire Çok İlişkiler
        public virtual ICollection<Egitim_Konu_Alt_Baslik> Egitim_Konu_Alt_Baslik { get; set; }
    }
}
