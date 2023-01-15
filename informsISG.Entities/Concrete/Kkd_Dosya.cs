
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Kkd_Dosya : EntityBase,IEntity
    {
        //Tablo alanları
        public string Dosya { get; set; }
        public string Aciklama { get; set; }

        //FK
        public long Kkd_Id { get; set; }
        public long Isveren_Id { get; set; }

        //FK BAĞLANTILARI
        public virtual Kkd Kkd { get; set; }
        public virtual Isveren Isveren { get; set; }


    }
}
