using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IMakine_Test_DegerleriService
    {
        Task<IResult> AddAsync(Makine_Test_DegerleriDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Makine_Test_DegerleriDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Makine_Test_DegerleriDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Makine_Test_DegerleriDTO>>> GetAllAsync();
        Task<IDataResult<IList<Makine_Test_DegerleriDTO>>> GetAllMakineAsync(long Id);
    }
}


