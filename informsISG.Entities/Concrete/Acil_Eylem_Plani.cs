using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Acil_Eylem_Plani : EntityBase , IEntity
    {
        //Tablo alanları
        public string Plan_Adi { get; set; }
        public string Dosya { get; set; }


        //FK
        [Required]
        public long Birim_Id { get; set; }
        [Required]
        public long Isveren_Id { get; set; }

        //FK Bağlantıları
        public virtual Birim Birim { get; set; }
        public virtual Isveren Isveren { get; set; }


    }
}
