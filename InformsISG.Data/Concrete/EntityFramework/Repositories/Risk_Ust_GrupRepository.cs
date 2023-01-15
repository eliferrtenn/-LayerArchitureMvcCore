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
    public class Risk_Ust_GrupRepository : EntityRepositoryBase<Risk_Ust_Grup>, IRisk_Ust_GrupRepository
    {
        public Risk_Ust_GrupRepository(DbContext context) : base(context)
        {

        }
    }
}
