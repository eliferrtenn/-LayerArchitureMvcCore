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
    public class Risk_KonuRepository : EntityRepositoryBase<Risk_Konu>, IRisk_KonuRepository
    {
        public Risk_KonuRepository(DbContext context) : base(context)
        {

        }
    }
}
