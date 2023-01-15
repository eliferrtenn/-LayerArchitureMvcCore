using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IPersonel_AyrintiService
    {
        Task<IResult> AddAsync(Personel_AyrintiDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Personel_AyrintiDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Personel_AyrintiDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Personel_AyrintiDTO>>> GetAllAsync();
   
    }
}
