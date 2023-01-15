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
    public class DofRepository : EntityRepositoryBase<Dof> , IDofRepository
    {
        public DofRepository(DbContext context) : base(context)
        {

        }
    }
}
