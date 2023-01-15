using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IYetkili_GormediService
    {
        Task<IResult> AddAsync(Yetkili_GormediDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Yetkili_GormediDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Yetkili_GormediDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Yetkili_GormediDTO>>> GetAllAsync();
    }
}
