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
    public class Risk_Analiz_TehlikeRepository : EntityRepositoryBase<Risk_Analiz_Tehlike> , IRisk_Analiz_TehlikeRepository
    {
        public Risk_Analiz_TehlikeRepository(DbContext context) : base(context)
        {

        }
    }
}
