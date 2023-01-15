using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IKkd_DosyaService
    {
        Task<IResult> AddAsync(Kkd_DosyaDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Kkd_DosyaDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Kkd_DosyaDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Kkd_DosyaDTO>>> GetAllAsync();
    }
}
