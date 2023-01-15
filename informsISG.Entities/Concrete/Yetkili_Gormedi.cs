
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Yetkili_Gormedi : EntityBase, IEntity
    {
        //Tablo alanları
        public string Tablo_Adi { get; set; }

        //FK
        public long Tablo_Id { get; set; }


        //FK Bağlantıları
        public virtual Risk_Analiz_Tablo Risk_Analiz_Tablo { get; set; }

    }
}
