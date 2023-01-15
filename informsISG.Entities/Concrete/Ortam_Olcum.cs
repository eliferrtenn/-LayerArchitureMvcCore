
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Ortam_Olcum : EntityBase, IEntity
    {
        //Tablo alanları
        public string Olcum_Tur { get; set; }
        public DateTime Olcum_Tarih { get; set; }
        public bool Olcum_Sonuc { get; set; }
        public string Olcum_Birim { get; set; }
        public string Aciklama { get; set; }

        //FK
        public long Tali_Birim_Id { get; set; }
        public long Isveren_Id { get; set; }


        //FK Bağlantıları
        public virtual Tali_Birim Tali_Birim { get; set; }
        public virtual Isveren Isveren { get; set; }
    }
}
