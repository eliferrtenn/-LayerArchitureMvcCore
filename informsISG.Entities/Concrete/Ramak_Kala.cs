
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Ramak_Kala : EntityBase, IEntity
    {
        //Tablo alanları
        public string Ramak_Kala_No { get; set; }
        public DateTime Tarih { get; set; }
        public string Saat { get; set; }
        public string Gorev { get; set; }
        public string Olay { get; set; }
        public string Olay_Tam_Yer { get; set; }
        public string Oneri { get; set; }
        public string Amir_Gorus { get; set; }
        public string Igu_Gorus { get; set; }
        public DateTime Igu_Gorus_Tarih { get; set; }
        public int Termin_Sure { get; set; }
        public string Is_Tanim { get; set; }
        public bool Tamamlandi { get; set; }
        public DateTime Tamamlandi_Tarih { get; set; }


        //FK
        [ForeignKey("Personel_Bilgi")]
        public long Personel_Id { get; set; }
        public long Birim_Id { get; set; }
        public long Tali_Birim_Id { get; set; }
        public long Isg_Kurul_Id { get; set; }
        public long Isveren_Id { get; set; }

        //FK Bağlantıları
        public virtual Birim Birim { get; set; }
        public virtual Personel_Bilgi Personel_Bilgi { get; set; }
        public virtual Tali_Birim Tali_Birim { get; set; }
        public virtual Isg_Kurul Isg_Kurul { get; set; }
        public virtual Isveren Isveren { get; set; }


        //Bire Çok İlişkiler
        public virtual ICollection<Ramak_Kala_Dosya> Ramak_Kala_Dosya { get; set; }
    }
}
