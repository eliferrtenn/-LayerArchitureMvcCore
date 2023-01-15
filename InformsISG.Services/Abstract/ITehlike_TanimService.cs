using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface ITehlike_TanimService
    {
        Task<IResult> AddAsync(Tehlike_TanimDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Tehlike_TanimDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Tehlike_TanimDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Tehlike_TanimDTO>>> GetAllAsync();
    }
}
