using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IEgitim_Tanim_KonuService
    {
        Task<IResult> AddAsync(Egitim_Tanim_KonuDTO addObject, long createdByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IDataResult<IList<Egitim_Tanim_KonuDTO>>> GetAllAsync(long Id);
        Task<IDataResult<IList<Egitim_Tanim_KonuDTO>>> GetEgitimAsync(long Id);
        Task<IDataResult<IList<Egitim_Tanim_KonuDTO>>> GetKonuAltAsync(long Id);
    }
}
