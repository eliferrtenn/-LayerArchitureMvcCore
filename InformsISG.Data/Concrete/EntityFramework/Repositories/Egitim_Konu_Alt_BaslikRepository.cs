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
    public class Egitim_Konu_Alt_BaslikRepository : EntityRepositoryBase<Egitim_Konu_Alt_Baslik>, IEgitim_Konu_Alt_BaslikRepository
    {
        public Egitim_Konu_Alt_BaslikRepository(DbContext context) : base(context)
        {

        }
    }
}
