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
    public class Yaralanan_Vucut_BolgesiRepository : EntityRepositoryBase<Yaralanan_Vucut_Bolgesi> , IYaralanan_Vucut_BolgesiRepository
    {
        public Yaralanan_Vucut_BolgesiRepository(DbContext context) : base(context)
        {

        }
    }
}
