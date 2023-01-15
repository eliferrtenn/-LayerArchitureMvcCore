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
    public class Kaza_Personel_DisiRepository : EntityRepositoryBase<Kaza_Personel_Disi> , IKaza_Personel_DisiRepository
    {
        public Kaza_Personel_DisiRepository(DbContext context) : base(context)
        {

        }
    }
}
