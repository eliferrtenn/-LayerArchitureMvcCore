using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IIsverenService 
    {
        Task<IResult> AddAsync(IsverenDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(IsverenDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<IsverenDTO>> GetAsync(long Id);
        Task<IDataResult<IList<IsverenDTO>>> GetAllAsync();
    }
}
