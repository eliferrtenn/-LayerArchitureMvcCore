using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IRisk_GerceklesenService
    {
        Task<IResult> AddAsync(Risk_GerceklesenDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Risk_GerceklesenDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Risk_GerceklesenDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Risk_GerceklesenDTO>>> GetAllAsync();
    }
}
