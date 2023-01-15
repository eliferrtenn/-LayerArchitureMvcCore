using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
//Postre sql büyük harfe izin vermez
namespace InformsISG.Entities.Concrete
{
    public class Personel_Bilgi : EntityBase,IEntity
    {
        //Tablo alanları
        public string Fotograf { get; set; }
        public string Unvan { get; set; }
        public string Ad_Soyad { get; set; }
        public string Sicil_No { get; set; }


        public string Sgk_No { get; set; }

        public bool IsgUzmanMi { get; set; }

        public bool IsYeriHekimi { get; set; }

        public string SertifikaNo { get; set; }

        public string Tc_No { get; set; }

        public DateTime Dogum_Tarih { get; set; }

        public string Dogum_Yer { get; set; }

        public bool Cinsiyet { get; set; }

        public DateTime Is_Giris_Tarih { get; set; }

        public Int32 Medeni_Durum { get; set; }

        public string Telefon1 { get; set; }

        public string Telefon2 { get; set; }

        public string Adres { get; set; }

        public Int32 Egitim { get; set; }

        public Int32 Egitim_Meslek { get; set; }

        public string Eposta { get; set; }

        public DateTime Is_Cikis_Tarih { get; set; } =new DateTime(1900, 01, 01);

        public bool Kadro_Durumu { get; set; }

        public string Notlar { get; set; }
        public bool yerdegistiMi { get; set; }

        //FK
        public long Sgk_Meslek_Id { get; set; }
        public long Tali_Birim_Id { get; set; }
        public long Birim_Id { get; set; }

        //FK Bağlantıları
        public virtual Sgk_Meslek Sgk_Meslek { get; set; }
        public virtual Tali_Birim Tali_Birim { get; set; }
        public virtual Birim Birim { get; set; }

        //Bire çok ilişkiler
        public virtual ICollection<Acil_Durum_Ekip_Personel> Acil_Durum_Ekip_Personel { get; set; }
        public virtual ICollection<Asi_Personel> Asi_Personel { get; set; }
        public virtual ICollection<Egitim_Personel_Atama> Egitim_Personel_Atama { get; set; }
        public virtual ICollection<Egitim_Sinav_Not> Egitim_Sinav_Not { get; set; }
        public virtual ICollection<Kaza> Kaza { get; set; }
        public virtual ICollection<Radyasyon> Radyasyon { get; set; }
        public virtual ICollection<Muayene> Muayene { get; set; }
        public virtual ICollection<Personel_Ayrinti> Personel_Ayrinti { get; set; }
        public virtual ICollection<Egitim_Veren_Personel> Egitim_Veren_Personel { get; set; }
        public virtual ICollection<Risk_Analiz> Risk_Analiz { get; set; }
        public virtual ICollection<Risk_Analiz_Tablo> Risk_Analiz_Tablo { get; set; }
        public virtual ICollection<Kullanici> Kullanici { get; set; }
        public virtual ICollection<Isg_Kurul_Karar2> Isg_Kurul_Karar2 { get; set; }
        public virtual ICollection<Isg_Kurul_Eleman> Isg_Kurul_Eleman { get; set; }
        public virtual ICollection<Ramak_Kala> Ramak_Kala { get; set; }
        public virtual ICollection<Kkd_Personel_Atama> Kkd_Personel_Atama { get; set; }

    }
}
