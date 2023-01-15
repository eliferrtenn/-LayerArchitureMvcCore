using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Isg_Kurul_Karar : EntityBase, IEntity
    {
        //Tablo alanları
        public string Toplanti_No { get; set; }
        public DateTime Tarih{ get; set; }
        public string Aciklama { get; set; }
        public string Saat { get; set; }
        public string Yer { get; set; }
        public string Toplanti_Baskan { get; set; }
        public string Raportor { get; set; }

        //FK
        public long Isg_Kurul_Id { get; set; }
        public long Isveren_Id  { get; set; }


        //FK Bağlantıları
        public virtual Isg_Kurul Isg_Kurul { get; set; }
        public virtual Isveren Isveren { get; set; }

        //Bire Çok İlişikiler
        public virtual ICollection<Isg_Kurul_Eleman> Isg_Kurul_Eleman { get; set; }
        public virtual ICollection<Isg_Kurul_Karar_Dosya> Isg_Kurul_Karar_Dosya { get; set; }
        public virtual ICollection<Isg_Kurul_Karar_Gundem> Isg_Kurul_Karar_Gundem { get; set; }
        public virtual ICollection<Isg_Kurul_Karar2> Isg_Kurul_Karar2 { get; set; }

    }
}
