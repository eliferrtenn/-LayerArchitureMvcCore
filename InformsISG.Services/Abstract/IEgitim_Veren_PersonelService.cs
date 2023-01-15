using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IEgitim_Veren_PersonelService
    {
        Task<IResult> AddAsync(Egitim_Veren_PersonelDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Egitim_Veren_PersonelDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Egitim_Veren_PersonelDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Egitim_Veren_PersonelDTO>>> GetAllAsync();
        Task<IDataResult<IList<Egitim_Veren_PersonelDTO>>> GetAllEgitimVeren(long Id);
    }
}
