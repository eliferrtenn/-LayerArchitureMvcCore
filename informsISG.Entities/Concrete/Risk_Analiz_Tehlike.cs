
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Risk_Analiz_Tehlike : EntityBase, IEntity
    {
        //Tablo alanları
        public string Tehlike { get; set; }
        public bool Aktif { get; set; }
    }
}
