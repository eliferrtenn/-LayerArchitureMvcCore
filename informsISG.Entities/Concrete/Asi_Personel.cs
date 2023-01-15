using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Asi_Personel : EntityBase , IEntity
    {
        //Tablo alanları
        public DateTime Islem_Tarih { get; set; }
        public string Uygulayan_Ad { get; set; }
        public string Asi_Doz { get; set; }
        public string Uygulama_Yer { get; set; }
        public string Uygulama_Sekil { get; set; }
        public bool Uygulandi { get; set; }
        public string Aciklama { get; set; }

        //FK 
        public long Asi_Tur_Id { get; set; }
        public long Personel_Id { get; set; }


        //FK BAĞLANTILARI
        public virtual Asi_Tur Asi_Tur { get; set; }
        public virtual Personel_Bilgi Personel_Bilgi { get; set; }
    }
}
