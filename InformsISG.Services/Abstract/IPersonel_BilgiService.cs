using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IPersonel_BilgiService
    {
        Task<IResult> AddAsync(Personel_BilgiDTO addObject,long createdByUserId);
        Task<IResult> UpdateAsync(Personel_BilgiDTO updateObj, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Personel_BilgiDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Personel_BilgiDTO>>> GetAllAsync(long Id);

        Task<IDataResult<IList<Personel_BilgiDTO>>> YerDegisenAllAsync();
        Task<IDataResult<Personel_BilgiDTO>> AddAndGetAsync(Personel_BilgiDTO addObject, long createdByUserId);

    }
}
