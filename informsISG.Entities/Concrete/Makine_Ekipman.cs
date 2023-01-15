
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Makine_Ekipman : EntityBase, IEntity
    {
        //Tablo alanları
        public string Ekipman_Kodu { get; set; }
        public string Firma_Adi { get; set; }
        public DateTime Periyodik_Kontrol_Tarih { get; set; }
        public DateTime Tekrar_Periyodik_Kontrol_Tarih { get; set; }
        public string Periyodik_Kontrol_Adres { get; set; }
        public string Telefon_No { get; set; }
        public string E_Posta { get; set; }
        public DateTime Takip_Kontrol_Tarih { get; set; }
        public DateTime Rapor_Tarih { get; set; }
        public string Periyodik_Kontrol_Method { get; set; }
        public string Kimlik_Rapor_No { get; set; }
        public string Kapsam { get; set; }
        public string QRCode { get; set; }

        public string Inceleme_Tespit_Edilen_Diger_Eksiklikler { get; set; }
        public string Onay { get; set; }
        public string Periyodik_Kontrol_Gorevlisi_Ad_Soyad { get; set; }
        public string Periyodik_Kontrol_Gorevlisi_Meslek { get; set; }
        public string Periyodik_Kontrol_Gorevlisi_Diploma_Tarihi_Numarasi { get; set; }
        public string Periyodik_Kontrol_Gorevlisi_Bakanlik_Numara { get; set; }   
        public string Birim_Sorumlusu_Ad_Soyad { get; set; }
        public string Birim_Sorumlusu_Meslek { get; set; }
        public string Birim_Sorumlusu_Diploma_Tarihi_Numarasi { get; set; }
        public string Birim_Sorumlusu_Bakanlik_Numara { get; set; }

        //FK
        public long Birim_Id { get; set; }
        public long Tali_Birim_Id { get; set; }
        public long Makine_Id { get; set; }

        //FK Bağlantıları
        public virtual Birim Birim { get; set; }
        public virtual Tali_Birim Tali_Birim { get; set; }
        public virtual Makine Makine { get; set; }


        //Bire Çok İlişkiler
        public virtual ICollection<Makine_Ekipman_Bakim_Planlari> Makine_Ekipman_Bakim_Planlari { get; set; }
        public virtual ICollection<Makine_Ekipman_Kontrol> Makine_Ekipman_Kontrol { get; set; }
        public virtual ICollection<MakineVeEkipman_Kontrol> MakineVeEkipman_KontrolKriter { get; set; }
        public virtual ICollection<Makine_Ekipman_Kontrol_Kriter_Baslik> Makine_Ekipman_Kontrol_Kriter_Baslik { get; set; }
        public virtual ICollection<Makine_Ekipman_Bilgi_Baslik> Makine_Ekipman_Bilgi_Baslik { get; set; }
        public virtual ICollection<Makine_Ekipman_Olcum_Aleti_Bilgiler> Makine_Ekipman_Olcum_Aleti_Bilgiler { get; set; }
        public virtual ICollection<Makine_Ekipman_Test_Degerleri> Makine_Ekipman_Test_Degerleri { get; set; }


    }
}
