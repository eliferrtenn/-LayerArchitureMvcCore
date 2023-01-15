using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IMsdsService
    {
        Task<IResult> AddAsync(MsdsDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(MsdsDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<MsdsDTO>> GetAsync(long Id);
        Task<IDataResult<IList<MsdsDTO>>> GetAllAsync();
    }
}
