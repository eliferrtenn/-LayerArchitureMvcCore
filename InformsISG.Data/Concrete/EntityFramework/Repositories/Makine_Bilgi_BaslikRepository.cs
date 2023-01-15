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
    public class Makine_Bilgi_BaslikRepository : EntityRepositoryBase<Makine_Bilgi_Baslik>, IMakine_Bilgi_BaslikRepository
    {
        public Makine_Bilgi_BaslikRepository(DbContext context) : base(context)
        {

        }
    }
}
