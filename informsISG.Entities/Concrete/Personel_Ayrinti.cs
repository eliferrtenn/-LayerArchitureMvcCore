using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Personel_Ayrinti : EntityBase, IEntity
    {
        //Tablo alanları
        public int Cocuk { get; set; }
        public int Kardes { get; set; }
        public int El_Kullanim { get; set; }
        public string Kilo { get; set; }
        public string Boy { get; set; }
        public string Kitle_Endeks { get; set; }
        public string Acil_Durum { get; set; }
        public string Kan_Grup { get; set; }
        public string Bagisiklik_Tetanoz { get; set; }
        public string Bagisiklik_Hepatit { get; set; }
        public string Bagisiklik_Diger { get; set; }
        public int Soy_Kalp { get; set; }
        public int Soy_Hipertansiyon { get; set; }
        public int Soy_Seker { get; set; }
        public bool Nefes_Darligi { get; set; }
        public bool Carpinti { get; set; }
        public bool Sirt_Agrisi { get; set; }
        public bool Ishal_Kabizlik { get; set; }
        public bool Eklem_Agri { get; set; }
        public bool Kalp_Hastalik { get; set; }
        public bool Seker_Hastalik { get; set; }
        public bool Bobrek_Rahatsizlik { get; set; }
        public bool Sarilik { get; set; }
        public bool Ulser { get; set; }
        public bool Isitme_Kayip { get; set; }
        public bool Gorme_Bozukluk { get; set; }
        public bool Sinir_Sistemi { get; set; }
        public bool Deri_Hastalik { get; set; }
        public bool Besin_Zehirlenme { get; set; }
        public string Hastane_Yatis { get; set; }
        public string Ameliyat { get; set; }
        public string Is_Kazasi { get; set; }
        public string Meslek_Hastalik { get; set; }
        public string Maluliyet { get; set; }
        public string Guncel_Tedavi { get; set; }
        public string Aliskanlik_Sigara { get; set; }
        public string Aliskanlik_Alkol { get; set; }
        public string Aliskanlik_Uyusturucu { get; set; }
        public string Aliskanlik_Diger { get; set; }
        public string Personel_Not { get; set; }
        public string Engelli { get; set; }
        public string Eski_Hukumlu { get; set; }
        public bool Agir_Tehlikeli { get; set; }
        public bool Yuksekte_Calisma { get; set; }
        public bool Gece_Vardiya { get; set; }
        public bool Uygunluk_Durumu { get; set; }

        //FK
        public long Personel_Id { get; set; }


        //FK Bağlantıları
        public virtual Personel_Bilgi Personel_Bilgi { get; set; }

    }
}
