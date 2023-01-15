using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete

{
    public class Isveren : EntityBase, IEntity
    {
        //Tablo alanları
        public string Isveren_Ad { get; set; }

        //Bire çok ilişkiler
        public virtual ICollection<Birim> Birim { get; set; }
        public virtual ICollection<Tali_Birim> Tali_Birim { get; set; }
        public virtual ICollection<Acil_Eylem_Plani> Acil_Eylem_Plani { get; set; }
        public virtual ICollection<Isg_Kurul_Karar> Isg_Kurul_Karar { get; set; }
        public virtual ICollection<Egitim_Sinav> Egitim_Sinav { get; set; }
        public virtual ICollection<Egitim_Tanimla> Egitim_Tanimla { get; set; }
        public virtual ICollection<Kkd_Dosya> Kkd_Dosya { get; set; }
        public virtual ICollection<Dof> Dof { get; set; }
        public virtual ICollection<Dof_Dosya> Dof_Dosya { get; set; }
        public virtual ICollection<Kaza> Kaza { get; set; }
        public virtual ICollection<Kaza_Dosya> Kaza_Dosya { get; set; }
        public virtual ICollection<Kaza_Personel_Disi> Kaza_Personel_Disi { get; set; }
        public virtual ICollection<Kaza_Personel_Disi_Dosya> Kaza_Personel_Disi_Dosya { get; set; }
        public virtual ICollection<Msds> Msds { get; set; }
        public virtual ICollection<Msds_Dosya> Msds_Dosya { get; set; }
        public virtual ICollection<Radyasyon> Radyasyon { get; set; }
        public virtual ICollection<Ramak_Kala> Ramak_Kala { get; set; }
        public virtual ICollection<Isg_Kurul_Karar_Dosya> Isg_Kurul_Karar_Dosya { get; set; }
        public virtual ICollection<Kkd> Kkd { get; set; }
        public virtual ICollection<Muayene> Muayene { get; set; }
        public virtual ICollection<Ortam_Olcum> Ortam_Olcum { get; set; }
        public virtual ICollection<Egitim_Veren_Personel> Egitim_Veren_Personel { get; set; }

    }
}
