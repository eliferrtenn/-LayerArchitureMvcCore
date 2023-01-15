using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IKaza_AyrintiService
    {
        Task<IResult> AddAsync(Kaza_AyrintiDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Kaza_AyrintiDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Kaza_AyrintiDTO>> GetAsync(long Id);
        Task<IDataResult<Kaza_AyrintiDTO>> GetKazaAsync(long Id);
        Task<IDataResult<IList<Kaza_AyrintiDTO>>> GetAllAsync();
    }
}
