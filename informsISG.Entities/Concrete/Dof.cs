using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Dof : EntityBase, IEntity
    {
        //Tablo alanları
        public string Dof_No { get; set; }
        public int Tip { get; set; }
        public int Geldigi_Kaynak { get; set; }
        public string Uygunsuzluk_Tanim { get; set; }
        public string Tespit_Eden { get; set; }
        public string Sorumlular { get; set; }
        public DateTime? Acilis_Tarih { get; set; } = new DateTime(1900, 01, 01);
        public int? Cevap_Sure { get; set; }
        public DateTime? Cevap_Sonlanma_Tarih { get; set; } = new DateTime(1900, 01, 01);
        public DateTime? Sonlanma_Tarih { get; set; } = new DateTime(1900, 01, 01);
        public bool Dof_Acik { get; set; }
        public string Dof_Ad { get; set; }//dof

        //FK
        public long Birim_Id { get; set; }
        public long Tali_Birim_Id { get; set; }
        public long Isg_Kurul_Id { get; set; }
        public long Isveren_Id { get; set; }

        //FK Bağlantıları
        public virtual Birim Birim { get; set; }
        public virtual Tali_Birim Tali_Birim { get; set; }
        public virtual Isg_Kurul Isg_Kurul { get; set; }
        public virtual Isveren Isveren { get; set; }

        //Bire Çok İlişki
        public virtual ICollection<Dof_Dosya> Dof_Dosya { get; set; }
    }
}
