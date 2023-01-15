using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IAsi_SureleriService
    {
        Task<IResult> AddAsync(Asi_SureleriDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Asi_SureleriDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Asi_SureleriDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Asi_SureleriDTO>>> GetAllAsync();
    }
}
