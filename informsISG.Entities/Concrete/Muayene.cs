
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Muayene : EntityBase, IEntity
    {
        //Tablo alanları
        public DateTime Muayene_Tarih { get; set; }
        public int Muayene_Tur { get; set; }
        public string Kan_Grup { get; set; }
        public int El_Kullanim { get; set; }
        public int Kilo { get; set; }
        public int Boy { get; set; }
        public string Kitle_Endeks { get; set; }
        public string Kronik_Hastalik { get; set; }
        public string Is_Kolu1 { get; set; }
        public string Yaptigi_Is1 { get; set; }
        public string Giris_Cikis1 { get; set; }
        public string Is_Kolu2 { get; set; }
        public string Yaptigi_Is2 { get; set; }
        public string Giris_Cikis2 { get; set; }
        public string Is_Kolu3 { get; set; }
        public string Yaptigi_Is3 { get; set; }
        public string Giris_Cikis3 { get; set; }
        public bool Bagisiklik_Tetanoz { get; set; }
        public bool Bagisiklik_Hepatit { get; set; }
        public string Bagisiklik_Diger { get; set; }
        public string Soygecmis_Anne { get; set; }
        public string Soygecmis_Baba { get; set; }
        public string Kardes { get; set; }
        public string Cocuk { get; set; }
        public bool Nefes_Darligi{ get; set; }
        public bool Balgamli_Oksuruk { get; set; }
        public bool Gogus_Agrisi { get; set; }
        public bool Carpinti { get; set; }
        public bool Sirt_Agrisi { get; set; }
        public bool Ishal_Kabizlik { get; set; }
        public bool Eklem_Agri { get; set; }
        public bool Kalp_Hastalik { get; set; }
        public bool Seker_Hastalik { get; set; }
        public bool Bobrek_Rahatsizlik { get; set; }
        public bool Sarilik { get; set; }
        public bool Mide_Ulser { get; set; }
        public bool Isitme_Kayip { get; set; }
        public bool Gorme_Bozukluk { get; set; }
        public bool Sinir_Sistemi { get; set; }
        public bool Deri_Hastalik { get; set; }
        public bool Besin_Zehirlenme { get; set; }
        public bool Kanser { get; set; }
        public bool Kas_Iskelet { get; set; }
        public bool Akciger_Solunum { get; set; }
        public string Hastane_Yatis { get; set; }
        public string Ameliyat { get; set; }
        public string Is_Kazasi { get; set; }
        public string Meslek_Hastalik { get; set; }
        public string Maluliyet { get; set; }
        public string Guncel_Tedavi { get; set; }
        public string Aliskanlik_Sigara { get; set; }
        public string Aliskanlik_Alkol { get; set; }
        public string Aliskanlik_Uyusturucu { get; set; }
        public string Fizik_Goz { get; set; }
        public string Fizik_Kbb { get; set; }
        public string Fizik_Deri { get; set; }
        public string Fizik_Kardiyovaskuler { get; set; }
        public string Fizik_Solunum_Sistemi { get; set; }
        public string Fizik_Sindirim_Sistemi { get; set; }
        public string Fizik_Urogenital { get; set; }
        public string Fizik_Kas_Iskelet { get; set; }
        public string Fizik_Norolojik { get; set; }
        public string Fizik_Psikiyatri { get; set; }
        public string Tansiyon { get; set; }
        public string Nabiz { get; set; }
        public string Lab_Biyolojik_Kan { get; set; }
        public string Lab_Biyolojik_Idrar { get; set; }
        public string Lab_Radyolojik { get; set; }
        public string Lab_Fizyolojik_Odyometre { get; set; }
        public string Lab_Fizyolojik_Sft { get; set; }
        public string Lab_Psikolojik { get; set; }
        public string Kanaat1 { get; set; }
        public string Kanaat2 { get; set; }
        public bool Yuksekte_Calisma { get; set; }
        public bool Vardiyali_Calisma { get; set; }
        public bool Konsultasyon { get; set; }

        //FK
        public long Personel_Id { get; set; }
        public long Isveren_Id { get; set; }


        //FK Bağlantıları
        public virtual Personel_Bilgi Personel_Bilgi { get; set; }
        public virtual Isveren Isveren { get; set; }


    }
}
