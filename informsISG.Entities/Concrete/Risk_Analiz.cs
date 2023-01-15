
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Risk_Analiz : EntityBase, IEntity
    {
        //Tablo alanları
        public string Analiz_No { get; set; }
        public string Analiz_Tanim { get; set; }
        public DateTime Analiz_Tarih { get; set; }
        public DateTime Bitis_Tarih { get; set; }
        public string Notlar { get; set; }
        public string Dosya { get; set; }




        //FK
        public long Birim_Id { get; set; }
        public long Tali_Birim_Id { get; set; }
        public long Isg_Kurul_Id { get; set; }
        public long Personel_Id { get; set; }
        public long Risk_Yontem_Id { get; set; }
        public long Risk_Kategori_Id { get; set; }
        public long Risk_Ust_Grup_Id{ get; set; }
        public long Risk_Konu_Grup_Id { get; set; }
        public long Risk_Konu_Id { get; set; }

        //FK Bağlantıları
        public virtual Birim Birim { get; set; }
        public virtual Tali_Birim Tali_Birim { get; set; }
        public virtual Isg_Kurul Isg_Kurul { get; set; }
        public virtual Personel_Bilgi Personel_Bilgi { get; set; }
        public virtual Risk_Yontem Risk_Yontem { get; set; }
        public virtual Risk_Kategori Risk_Kategori { get; set; }
        public virtual Risk_Ust_Grup Risk_Ust_Grup { get; set; }
        public virtual Risk_Konu_Grup Risk_Konu_Grup { get; set; }
        public virtual Risk_Konu Risk_Konu { get; set; }

        //Bire Çok İlişkiler
        public virtual ICollection<Risk_Analiz_Tablo> Risk_Analiz_Tablo { get; set; }
        public virtual ICollection<Risk_Kutuphane> Risk_Kutuphane { get; set; }


    }
}
