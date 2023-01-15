using InformsISG.Core.Entities.Abstract;
using InformsISG.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Makine_Ekipman_Bakim_Planlari : EntityBase, IEntity
    {
        //Tablo alanları
        public DateTime Servis_Tarih { get; set; }
        public int Bakim_Tip { get; set; }
        public string Yapilan_Islem { get; set; }
        public string Aciklama { get; set; }
        public DateTime Diger_Servis_Tarih { get; set; }
        public int Durum { get; set; }
        public int OnayBirimSorumlu { get; set; }
        public int OnayIsgUzman { get; set; }



        //FK
        public long Makine_Ekipman_Id { get; set; }


        //FK Bağlantıları
        public virtual Makine_Ekipman Makine_Ekipman { get; set; }


        //Bire Çok İlişkiler
        public virtual ICollection<Makine_Ekipman_Bakim_Fotograf> Makine_Ekipman_Bakim_Fotograf{ get; set; }
    }
}
