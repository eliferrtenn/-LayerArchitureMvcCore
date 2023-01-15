using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Beden_Bolge : EntityBase , IEntity
    {
        //Tablo alanları
        public string Beden_Bolge_Ad { get; set; }
    }
}
