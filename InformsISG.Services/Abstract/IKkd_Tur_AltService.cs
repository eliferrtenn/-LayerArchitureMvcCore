using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IKkd_Tur_AltService
    {
        Task<IResult> AddAsync(Kkd_Tur_AltDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Kkd_Tur_AltDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Kkd_Tur_AltDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Kkd_Tur_AltDTO>>> GetAllAsync();

        Task<IDataResult<IList<Kkd_Tur_AltDTO>>> GetAllKkd(int Id);
    }
}
