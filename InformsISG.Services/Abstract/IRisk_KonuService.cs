using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IRisk_KonuService
    {
        Task<IResult> AddAsync(Risk_KonuDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Risk_KonuDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Risk_KonuDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Risk_KonuDTO>>> GetAllAsync();
        Task<IDataResult<IList<Risk_KonuDTO>>> GetSelectAsync(long Id);
        Task<IDataResult<IList<Risk_KonuDTO>>> GetAllKonuAsync(long id);
    }
}
