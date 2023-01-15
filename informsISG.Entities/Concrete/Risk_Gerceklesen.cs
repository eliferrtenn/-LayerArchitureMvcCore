
using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InformsISG.Entities.Concrete
{
    public class Risk_Gerceklesen : EntityBase, IEntity
    {
        //Tablo alanları
        public string Risk_Gerceklesen_Ad { get; set; }
    }
}
