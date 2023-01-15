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
    public class Egitim_Personel_AtamaRepository : EntityRepositoryBase<Egitim_Personel_Atama> , IEgitim_Personel_AtamaRepository
    {
        public Egitim_Personel_AtamaRepository(DbContext context) : base(context)
        {

        }
    }
}
