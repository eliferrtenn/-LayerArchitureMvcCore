using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Egitim_Sinav : EntityBase, IEntity
    {
        //Tablo alanları
        public string Sinav_Ad { get; set; }
        public DateTime Sinav_Tarih { get; set; }
        public string Sinav_Saat { get; set; }

        //FK
        public long Egitim_Tanimla_Id { get; set; }
        public long Isg_Kurul_Id { get; set; }
        public long Isveren_Id { get; set; }

        //FK Bağlantıları
        public virtual Egitim_Tanimla Egitim_Tanimla { get; set; }
        public virtual Isg_Kurul Isg_Kurul { get; set; }
        public virtual Isveren Isveren { get; set; }

        //Bire Çok İlişkiler
        public virtual ICollection<Egitim_Sinav_Not> Egitim_Sinav_Not { get; set; }
    }
}
