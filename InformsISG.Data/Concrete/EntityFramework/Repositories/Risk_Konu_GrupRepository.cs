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
    public class Risk_Konu_GrupRepository : EntityRepositoryBase<Risk_Konu_Grup>, IRisk_Konu_GrupRepository
    {
        public Risk_Konu_GrupRepository(DbContext context) : base(context)
        {

        }
    }
}
