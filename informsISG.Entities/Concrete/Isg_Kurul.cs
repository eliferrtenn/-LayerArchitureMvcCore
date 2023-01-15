using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Isg_Kurul : EntityBase , IEntity
    {
        //Tablo alanları
        public string Kurul_Ad { get; set; }
        public string Aciklama { get; set; }
        public int Tehlike_Tip { get; set; }

        //Bire çok ilişkiler
        public virtual ICollection<Birim> Birim { get; set; }
        public virtual ICollection<Alt_Isveren> Alt_Isveren { get; set; }
        public virtual ICollection<Kaza> Kaza { get; set; }
        public virtual ICollection<Isg_Kurul_Karar> Isg_Kurul_Karar { get; set; }
        public virtual ICollection<Egitim_Sinav> Egitim_Sinav { get; set; }
        public virtual ICollection<Egitim_Tanimla> Egitim_Tanimla { get; set; }
        public virtual ICollection<Risk_Analiz> Risk_Analiz { get; set; }
        public virtual ICollection<Dof> Dof { get; set; }
        public virtual ICollection<Kaza_Personel_Disi> Kaza_Personel_Disi { get; set; }
        public virtual ICollection<Msds> Msds { get; set; }
        public virtual ICollection<Ramak_Kala> Ramak_Kala { get; set; }
        public virtual ICollection<Kkd> Kkd { get; set; }
    }
}
