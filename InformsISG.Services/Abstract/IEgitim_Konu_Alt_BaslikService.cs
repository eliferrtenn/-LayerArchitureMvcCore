using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IEgitim_Konu_Alt_BaslikService
    {
        Task<IResult> AddAsync(Egitim_Konu_Alt_BaslikDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Egitim_Konu_Alt_BaslikDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Egitim_Konu_Alt_BaslikDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Egitim_Konu_Alt_BaslikDTO>>> GetAllAsync();
        Task<IDataResult<IList<Egitim_Konu_Alt_BaslikDTO>>> GetSelected(long Id);
        Task<IDataResult<IList<Egitim_Konu_Alt_BaslikDTO>>> GetAllEgitimKonuAsync(long Id);

        
    }
}
