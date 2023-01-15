
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Kullanici : EntityBase,IEntity
    {
        //Tablo alanları
        public string Mail { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        //FK
        public long Birim_Id { get; set; }
        public long Yetki_Id { get; set; }
        public long Personel_Id { get; set; }


        //FK Bağlantıları
        public virtual Birim Birim { get; set; }
        public virtual Yetki Yetki { get; set; }
        public virtual Personel_Bilgi Personel_Bilgi { get; set; }

    }
}
