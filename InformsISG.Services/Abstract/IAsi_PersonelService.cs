using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IAsi_PersonelService
    {
        Task<IResult> AddAsync(Asi_PersonelDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Asi_PersonelDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Asi_PersonelDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Asi_PersonelDTO>>> GetAllAsync();
    }
}
