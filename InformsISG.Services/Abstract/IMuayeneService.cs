using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IMuayeneService
    {
        Task<IResult> AddAsync(MuayeneDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(MuayeneDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<MuayeneDTO>> GetAsync(long Id);
        Task<IDataResult<IList<MuayeneDTO>>> GetAllAsync();
        Task<IDataResult<IList<MuayeneDTO>>> GetAllChoosePersonelAsync(long Id);
    }
}
