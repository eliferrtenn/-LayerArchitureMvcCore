using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IKkd_TurService
    {
        Task<IResult> AddAsync(Kkd_TurDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Kkd_TurDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Kkd_TurDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Kkd_TurDTO>>> GetAllAsync();
    }
}
