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
    public class Msds_DosyaRepository : EntityRepositoryBase<Msds_Dosya> , IMsds_DosyaRepository
    {
        public Msds_DosyaRepository(DbContext context) : base(context)
        {

        }
    }
}
