using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IKaza_DosyaService
    {
        Task<IResult> AddAsync(Kaza_DosyaDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Kaza_DosyaDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Kaza_DosyaDTO>> GetAsync(long Id);
        Task<IDataResult<Kaza_DosyaDTO>> GetKazaAsync(long Id);
        Task<IDataResult<IList<Kaza_DosyaDTO>>> GetAllAsync();
    }
}
