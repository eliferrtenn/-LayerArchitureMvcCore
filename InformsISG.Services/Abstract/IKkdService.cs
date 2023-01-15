using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IKkdService
    {
        Task<IResult> AddAsync(KkdDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(KkdDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<KkdDTO>> GetAsync(long Id);
        Task<IDataResult<IList<KkdDTO>>> GetAllAsync();
    }
}
