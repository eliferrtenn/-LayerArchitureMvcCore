using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Kaza_Ayrinti : EntityBase,IEntity
    {
        //Tablo alanları
        public bool Hareketler1 { get; set; }
        public bool Hareketler2 { get; set; }
        public bool Hareketler3 { get; set; }
        public bool Hareketler4 { get; set; }
        public bool Hareketler5 { get; set; }
        public bool Hareketler6 { get; set; }
        public bool Hareketler7 { get; set; }
        public bool Hareketler8 { get; set; }
        public bool Hareketler9 { get; set; }
        public bool Hareketler10 { get; set; }
        public bool Hareketler11 { get; set; }
        public bool Hareketler12 { get; set; }
        public bool Hareketler13 { get; set; }
        public bool Hareketler14 { get; set; }
        public bool Hareketler15 { get; set; }
        public bool Hareketler16 { get; set; }
        public bool Hareketler17 { get; set; }
        public bool Hareketler18 { get; set; }
        public bool Kisisel_Faktorler1 { get; set; }
        public bool Kisisel_Faktorler2 { get; set; }
        public bool Kisisel_Faktorler3 { get; set; }
        public bool Kisisel_Faktorler4 { get; set; }
        public bool Kisisel_Faktorler5 { get; set; }
        public bool Kisisel_Faktorler6 { get; set; }
        public bool Kisisel_Faktorler7 { get; set; }
        public bool Kisisel_Faktorler8 { get; set; }
        public bool Kisisel_Faktorler9 { get; set; }
        public bool Kisisel_Faktorler10 { get; set;}
        public bool Kisisel_Faktorler11 { get; set;}
        public bool Kisisel_Faktorler12 { get; set;}
        public bool Kisisel_Faktorler13 { get; set;}
        public bool Kisisel_Faktorler14 { get; set;}
        public bool Kisisel_Faktorler15 { get; set;}
        public bool Kisisel_Faktorler16 { get; set;}
        public bool Kisisel_Faktorler17 { get; set;}
        public bool Kisisel_Faktorler18 { get; set;}
        public bool Calisma_Kosullari1 { get; set;}
        public bool Calisma_Kosullari2 { get; set;}
        public bool Calisma_Kosullari3 { get; set;}
        public bool Calisma_Kosullari4 { get; set;}
        public bool Calisma_Kosullari5 { get; set; }
        public bool Calisma_Kosullari6 { get; set; }
        public bool Calisma_Kosullari7 { get; set; }
        public bool Calisma_Kosullari8 { get; set; }
        public bool Calisma_Kosullari9 { get; set; }
        public bool Calisma_Kosullari10 { get; set; }
        public bool Calisma_Kosullari11 { get; set; }
        public bool Calisma_Kosullari12 { get; set; }
        public bool Calisma_Kosullari13 { get; set; }
        public bool Calisma_Kosullari14 { get; set; }
        public bool Calisma_Kosullari15 { get; set; }
        public bool Calisma_Kosullari16 { get; set; }
        public bool Calisma_Kosullari17 { get; set; }
        public bool Calisma_Kosullari18 { get; set; }
        public bool Calisma_Kosullari19 { get; set; }
        public bool Is_Faktorleri1 { get; set; }
        public bool Is_Faktorleri2 { get; set; }
        public bool Is_Faktorleri3 { get; set; }
        public bool Is_Faktorleri4 { get; set; }
        public bool Is_Faktorleri5 { get; set; }
        public bool Is_Faktorleri6 { get; set; }
        public bool Is_Faktorleri7 { get; set; }
        public bool Is_Faktorleri8 { get; set; }
        public bool Is_Faktorleri9 { get; set; }
        public bool Is_Faktorleri10 { get; set; }
        public bool Is_Faktorleri11 { get; set; }
        public bool Is_Faktorleri12 { get; set; }
        public bool Is_Faktorleri13 { get; set; }
        public bool Is_Faktorleri14 { get; set; }
        public bool Is_Faktorleri15 { get; set; }
        public bool Is_Faktorleri16 { get; set; }
        public bool Is_Faktorleri17 { get; set; }
        public bool Is_Faktorleri18 { get; set; }
        public bool Is_Faktorleri19 { get; set; }
        public bool Kaza_Turu1 { get; set; }
        public bool Kaza_Turu2 { get; set; }
        public bool Kaza_Turu3 { get; set; }
        public bool Kaza_Turu4 { get; set; }
        public bool Kaza_Turu5 { get; set; }
        public bool Kaza_Turu6 { get; set; }
        public bool Kaza_Turu7 { get; set; }
        public bool Kaza_Turu8 { get; set; }
        public bool Kaza_Turu9 { get; set; }
        public bool Kaza_Turu10 { get; set; }
        public bool Kaza_Turu11 { get; set; }
        public bool Kaza_Turu12 { get; set; }
        public bool Yaralanan_Uzuvlar1 { get; set; }
        public bool Yaralanan_Uzuvlar2 { get; set; }
        public bool Yaralanan_Uzuvlar3 { get; set; }
        public bool Yaralanan_Uzuvlar4 { get; set; }
        public bool Yaralanan_Uzuvlar5 { get; set; }
        public bool Yaralanan_Uzuvlar6 { get; set; }
        public bool Yaralanan_Uzuvlar7 { get; set; }
        public bool Yaralanan_Uzuvlar8 { get; set; }
        public bool Yaralanan_Uzuvlar9 { get; set; }
        public bool Yaralanan_Uzuvlar10 { get; set; }
        public bool Yaralanan_Uzuvlar11 { get; set; }
        public bool Yaralanan_Uzuvlar12 { get; set; }

        //FK
        public long Kaza_Id { get; set; }

        //FK Bağlantıları
        public virtual Kaza Kaza { get; set; }

    }
}
