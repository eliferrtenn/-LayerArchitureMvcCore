using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete 
{
    public class Egitim_Tanimla : EntityBase , IEntity
    {
        //Tablo alanları
        public string Egitim_Ad { get; set; }
        public int Egitim_Sebep { get; set; }
        public DateTime Egitim_Tarih { get; set; }
        public int Egitim_Tur { get; set; }
        public string Egitim_Yer { get; set; }
        public string Egitim_Yer_Ad { get; set; }
        public DateTime Tekrar_Tarih { get; set; }
        public string Aciklama { get; set; }

        //FK
        public long Isg_Kurul_Id { get; set; }
        public long Isveren_Id { get; set; }

        //FK Bağlantıları
        public virtual Isg_Kurul Isg_Kurul { get; set; }
        public virtual Isveren Isveren { get; set; }

        //Bire çok ilişkiler
        public virtual ICollection<Egitim_Sinav> Egitim_Sinav { get; set; }
        public virtual ICollection<Egitim_Personel_Atama> Egitim_Personel_Atama { get; set; }
        public virtual ICollection<Egitim_Veren_Personel> Egitim_Veren_Personel { get; set; }
        public virtual ICollection<Egitim_Tanim_Konu> Egitim_Tanim_Konu { get; set; }

    }

}
