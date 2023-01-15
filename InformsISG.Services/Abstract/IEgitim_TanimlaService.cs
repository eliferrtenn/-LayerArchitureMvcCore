using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IEgitim_TanimlaService
    {
        Task<IResult> AddAsync(Egitim_TanimlaDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Egitim_TanimlaDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Egitim_TanimlaDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Egitim_TanimlaDTO>>> GetAllAsync();

        Task<IDataResult<Egitim_TanimlaDTO>> AddAndGetAsync(Egitim_TanimlaDTO addObject, long createdByUserId);

    }
}
