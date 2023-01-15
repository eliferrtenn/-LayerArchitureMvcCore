using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Hareket : EntityBase, IEntity
    {
        //Tablo alanları
        public string Sayfa { get; set; }
        public string Hareket_Ad { get; set; }
    }
}
