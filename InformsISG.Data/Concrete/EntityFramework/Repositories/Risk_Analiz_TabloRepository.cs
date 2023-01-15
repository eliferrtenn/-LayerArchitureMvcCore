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
    public class Risk_Analiz_TabloRepository : EntityRepositoryBase<Risk_Analiz_Tablo> , IRisk_Analiz_TabloRepository
    {
        public Risk_Analiz_TabloRepository(DbContext context) : base(context)
        {

        }
    }
}
