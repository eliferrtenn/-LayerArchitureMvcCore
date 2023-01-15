using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IRamak_Kala_DosyaService
    {
        Task<IResult> AddAsync(Ramak_Kala_DosyaDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Ramak_Kala_DosyaDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Ramak_Kala_DosyaDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Ramak_Kala_DosyaDTO>>> GetAllAsync();
        Task<IDataResult<IList<Ramak_Kala_DosyaDTO>>> GetAllRamakKalaAsync(long Id);
    }
}
