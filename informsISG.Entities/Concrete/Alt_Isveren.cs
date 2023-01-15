using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Alt_Isveren : EntityBase ,IEntity
    {

        [DisplayName("İŞVEREN ADI"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Alt_Isveren_Ad { get; set; }


        [DisplayName("NOTLAR"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız."),
            MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string Notlar { get; set; }

        [DisplayName("KONTROL DURUMU"),
            Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public bool Kontrol_Edildi { get; set; }

        //FK
        public long Isg_Kurul_Id { get; set; }

        //FK Bağlantıları
        public virtual Isg_Kurul Isg_Kurul { get; set; }


        //Bire çok ilişkiler
        public virtual ICollection<Birim> Birim { get; set; }
        public virtual ICollection<Tali_Birim> Tali_Birim { get; set; }
    }
}