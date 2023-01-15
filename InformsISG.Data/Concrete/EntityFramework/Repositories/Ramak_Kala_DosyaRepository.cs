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
    public class Ramak_Kala_DosyaRepository : EntityRepositoryBase<Ramak_Kala_Dosya>, IRamak_Kala_DosyaRepository
    {
        public Ramak_Kala_DosyaRepository(DbContext context) : base(context)
        {

        }
    }
}
