using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Entities.Concrete
{
    public class Isg_Kurul_Karar2 : EntityBase, IEntity
    {
        //Tablo alanları
        public string Karar_No { get; set; }
        public string Alinan_Kararlar { get; set; }
        public bool? TamamlandiMi { get; set; }
        public DateTime Baslangic_Tarih { get; set; }
        public DateTime Bitis_Tarih { get; set; }

        //FK
        public long Isg_Kurul_Karar_Id { get; set; }
        public long Personel_Id { get; set; }

        //FK Bağlantıları
        public virtual Isg_Kurul_Karar Isg_Kurul_Karar { get; set; }
        public virtual Personel_Bilgi Personel_Bilgi { get; set; }
    }
}
