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
    public class Risk_Analiz_RiskRepository : EntityRepositoryBase<Risk_Analiz_Risk> , IRisk_Analiz_RiskRepository
    {
        public Risk_Analiz_RiskRepository(DbContext context): base(context)
        {

        }
    }
}
