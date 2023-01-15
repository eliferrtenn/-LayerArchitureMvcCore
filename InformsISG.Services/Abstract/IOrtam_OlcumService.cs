using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IOrtam_OlcumService
    {
        Task<IResult> AddAsync(Ortam_OlcumDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Ortam_OlcumDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Ortam_OlcumDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Ortam_OlcumDTO>>> GetAllAsync();
    }
}
