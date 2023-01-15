using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IBeden_BolgeService
    {
        Task<IResult> AddAsync(Beden_BolgeDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Beden_BolgeDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Beden_BolgeDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Beden_BolgeDTO>>> GetAllAsync();
    }
}
