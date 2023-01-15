using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Kkd : EntityBase, IEntity
    {
        //Tablo alanları
        public string Kkd_No { get; set; }
        public string Kkd_Tanim { get; set; }
        public string Uretici { get; set; }
        public string Parca_No { get; set; }
        public string Standart { get; set; }
        public string Notlar { get; set; }
        public bool Kullanilma_Durumu { get; set; }

        //FK
        public long Kkd_Tur_Id { get; set; }
        public long Kkd_Tur_Alt_Id { get; set; }
        public long Isg_Kurul_Id { get; set; }
        public long Isveren_Id { get; set; }

        //FK Bağlantıları
        public virtual Kkd_Tur Kkd_Tur { get; set; }
        public virtual Kkd_Tur_Alt Kkd_Tur_Alt { get; set; }
        public virtual Isg_Kurul Isg_Kurul { get; set; }
        public virtual Isveren Isveren { get; set; }

        //Bire çok ilişkiler
        public virtual ICollection<Kkd_Dosya> Kkd_Dosya { get; set; }
        public virtual ICollection<Kkd_Personel_Atama> Kkd_Personel_Atama { get; set; }
    }
}
