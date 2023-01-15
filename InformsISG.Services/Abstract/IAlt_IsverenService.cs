using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IAlt_IsverenService
    {
        Task<IResult> AddAsync(Alt_IsverenDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Alt_IsverenDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Alt_IsverenDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Alt_IsverenDTO>>> GetAllAsync();
    }
}
