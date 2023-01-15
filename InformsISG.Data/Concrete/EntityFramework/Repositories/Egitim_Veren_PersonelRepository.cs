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
    public class Egitim_Veren_PersonelRepository : EntityRepositoryBase<Egitim_Veren_Personel>, IEgitim_Veren_PersonelRepository
    {
        public Egitim_Veren_PersonelRepository(DbContext context) : base(context)
        {

        }
    }
}
