using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IRamak_KalaService
    {
        Task<IResult> AddAsync(Ramak_KalaDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Ramak_KalaDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Ramak_KalaDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Ramak_KalaDTO>>> GetAllAsync();
    }
}
