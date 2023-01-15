
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Risk_Analiz_Tablo : EntityBase, IEntity
    {
        //Tablo alanları
        public string Faaliyet { get; set; }
        public int Rutin_Durum { get; set; }
        public string Tehlike { get; set; }
        public string Risk { get; set; }
        public bool Uygun_Durum { get; set; }
        public string Yasal_Dayanak { get; set; }
        public DateTime? Termin_Tarih { get; set; }
        public string Sorumlular { get; set; }
        public DateTime? Etkinlik_Kontrol_Tarih { get; set; }
        public string Kontrol_Degerlendirme { get; set; }


        public float Olasilik1 { get; set; }
        public float Frekans1 { get; set; }
        public float Siddet1 { get; set; }
        public float Risk_Puan1 { get; set; } 
        public string Risk_Seviye1 { get; set; }
        public string Duzeltici_Faaliyet { get; set; }
        public float Olasilik2 { get; set; }
        public float Frekans2 { get; set; }
        public float Siddet2 { get; set; }
        public float Risk_Puan2 { get; set; }
        public string Risk_Seviye2 { get; set; }
        public string Resim { get; set; }

        //FK
        public long Birim_Id { get; set; }
        public long Tali_Birim_Id { get; set; }
        public long Risk_Id { get; set; }
        public long Risk_Analiz_Id { get; set; }
        public long Tehlike_Tanim_Id { get; set; }
        public long Personel_Id { get; set; }

        //FK BAĞLANTILARI
        public virtual Birim Birim { get; set; }
        public virtual Tali_Birim Tali_Birim { get; set; }
        public virtual Risk_Analiz Risk_Analiz { get; set; }
        public virtual Risk_Analiz_Risk Risk_Analiz_Risk { get; set; }
        public virtual Tehlike_Tanim Tehlike_Tanim { get; set; }
        public virtual Personel_Bilgi Personel_Bilgi { get; set; }

        //Bire Çok İlişkiler
        public ICollection<Yetkili_Gormedi> Yetkili_Gormedi { get; set; }


    }
}
