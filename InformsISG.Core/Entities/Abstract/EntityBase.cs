using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Core.Entities.Abstract
{
    public abstract class EntityBase//abstract hepsini miras almak zorunda
    {
        public virtual long Id { get; set; }//virtual yeniden override olabilir
       
        [DisplayName("YARATILMA TARİHİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.mm.yyyy}")]
        public virtual DateTime Yaratilma_Tarihi { get; set; }

        [DisplayName("DEĞİŞTİRİLME TARİHİ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.mm.yyyy}")]
        public virtual DateTime Degistirilme_Tarihi { get; set; }

        [DisplayName("SİLİNMİŞ"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public virtual bool isDeleted { get; set; } = false;

        [DisplayName("AKTİF"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public virtual bool isActive { get; set; } = true;

        public virtual long Kullanici_Id { get; set; }
    }
}
