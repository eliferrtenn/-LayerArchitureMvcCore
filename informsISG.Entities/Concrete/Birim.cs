using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Birim : EntityBase , IEntity
    {
        //Tablo alanları
        public string Birim_Ad { get; set; }
        public string Sgk_No { get; set; }
        public string Aciklama { get; set; }
        public string Nace_Kod { get; set; }

        //FK
        public long Isg_Kurul_Id { get; set; }
        public long Isveren_Id { get; set; }

        //FK Bağlantıları
        public virtual Isg_Kurul Isg_Kurul { get; set; }
        public virtual Isveren Isveren { get; set; }


        //Bire çok ilişkiler
        public virtual ICollection<Kullanici> Kullanici { get; set; }
        public virtual ICollection<Personel_Bilgi> Personel_Bilgi { get; set; }
        public virtual ICollection<Tali_Birim> Tali_Birim { get; set; }
        public virtual ICollection<Acil_Eylem_Plani> Acil_Eylem_Plani { get; set; }
        public virtual ICollection<Acil_Durum_Ekip_Personel> Acil_Durum_Ekip_Personel { get; set; }
        public virtual ICollection<Makine_Ekipman> Makine_Ekipman { get; set; }
        public virtual ICollection<Risk_Analiz> Risk_Analiz { get; set; }
        public virtual ICollection<Dof> Dof { get; set; }
        public virtual ICollection<Ramak_Kala> Ramak_Kala { get; set; }
        public virtual ICollection<Risk_Analiz_Tablo> Risk_Analiz_Tablo { get; set; }
    }
}
