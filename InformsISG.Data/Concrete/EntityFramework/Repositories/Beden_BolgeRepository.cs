using InformsISG.Core.Data.Concrete;
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
    public class Beden_BolgeRepository : EntityRepositoryBase<Beden_Bolge> , IBeden_BolgeRepository
    {
        public Beden_BolgeRepository(DbContext context) : base(context)
        {

        }
    }
}
