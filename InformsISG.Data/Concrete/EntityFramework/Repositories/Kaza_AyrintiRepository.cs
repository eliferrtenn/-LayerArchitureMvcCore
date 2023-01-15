﻿using InformsISG.Core.Data.Concrete;
using InformsISG.Data.Abstract;
using InformsISG.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace InformsISG.Data.Concrete.EntityFramework.Repositories
{
    public class Kaza_AyrintiRepository : EntityRepositoryBase<Kaza_Ayrinti> , IKaza_AyrintiRepository
    {
        public Kaza_AyrintiRepository(DbContext context) : base(context)
        {

        }
    }
}
