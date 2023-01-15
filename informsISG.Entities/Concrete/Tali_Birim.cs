
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Tali_Birim : EntityBase, IEntity
    {
        //Tablo alanları
        public string Tali_Birim_Ad { get; set; }
        public string Aciklama { get; set; }

        //FK
        [DisplayName("BİRİMİ"),
            ForeignKey("Birim")]
        public long Birim_Id { get; set; }

        [DisplayName("İŞVEREN BİRİMİ"), 
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            ForeignKey("Isveren")]
        public long Isveren_Id { get; set; }


        //FK Bağlantıları
        public virtual Birim Birim { get; set; }
        public virtual Isveren Isveren { get; set; }

        //Bire Çok İlişkiler
        public virtual ICollection<Personel_Bilgi> Personel_Bilgi { get; set; }
        public virtual ICollection<Makine_Ekipman> Makine_Ekipman { get; set; }
        public virtual ICollection<Risk_Analiz> Risk_Analiz { get; set; }
        public virtual ICollection<Risk_Analiz_Tablo> Risk_Analiz_Tablo { get; set; }
        public virtual ICollection<Dof> Dof { get; set; }
        public virtual ICollection<Ramak_Kala> Ramak_Kala { get; set; }
        public virtual ICollection<Ortam_Olcum> Ortam_Olcum { get; set; }
        public virtual ICollection<Kaza> Kaza { get; set; }
        public virtual ICollection<Acil_Durum_Tatbikat> Acil_Durum_Tatbikat { get; set; }

    }
}
