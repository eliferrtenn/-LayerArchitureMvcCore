using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IEgitim_SinavService
    {
        Task<IResult> AddAsync(Egitim_SinavDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Egitim_SinavDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Egitim_SinavDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Egitim_SinavDTO>>> GetAllAsync();
    }
}
