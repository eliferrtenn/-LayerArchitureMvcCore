using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Egitim_Tanim_Konu : EntityBase, IEntity
    {

        //FK
        [ForeignKey("Egitim_Tanimla")]
        public long Egitim_Tanimla_Id { get; set; }
        [ForeignKey("Egitim_Konu_Alt_Baslik")]
        public long Egitim_Konu_Alt_Baslik_Id { get; set; }

        //FK Bağlantıları
        public virtual Egitim_Tanimla Egitim_Tanimla { get; set; }
        public virtual Egitim_Konu_Alt_Baslik Egitim_Konu_Alt_Baslik { get; set; }

    }
}
