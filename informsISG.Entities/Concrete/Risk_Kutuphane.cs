using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Risk_Kutuphane : EntityBase, IEntity
    {

        //FK
        [ForeignKey("Risk_Analiz")]
        public long Risk_Analiz_Id { get; set; }
        [ForeignKey("Risk_Kategori")]
        public long Risk_Kategori_Id { get; set; }
        [ForeignKey("Risk_Ust_Grup")]
        public long Risk_Ust_Grup_Id { get; set; }
        [ForeignKey("Risk_Konu_Grup")]
        public long Risk_Konu_Grup_Id { get; set; }
        [ForeignKey("Risk_Konu")]
        public long Risk_Konu_Id { get; set; }

        //FK Bağlantıları
        public virtual Risk_Analiz Risk_Analiz { get; set; }
        public virtual Risk_Kategori Risk_Kategori { get; set; }
        public virtual Risk_Ust_Grup Risk_Ust_Grup { get; set; }
        public virtual Risk_Konu_Grup Risk_Konu_Grup { get; set; }
        public virtual Risk_Konu Risk_Konu { get; set; }

    }
}
