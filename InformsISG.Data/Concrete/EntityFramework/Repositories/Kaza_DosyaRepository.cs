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
    public class Kaza_DosyaRepository : EntityRepositoryBase<Kaza_Dosya> ,IKaza_DosyaRepository
    {
        public Kaza_DosyaRepository(DbContext context) : base(context)
        {

        }
    }
}
