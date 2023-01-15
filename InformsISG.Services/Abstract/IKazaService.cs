using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IKazaService
    {
        Task<IResult> AddAsync(KazaDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(KazaDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<KazaDTO>> GetAsync(long Id);
        Task<IDataResult<IList<KazaDTO>>> GetAllAsync();
        Task<IDataResult<IList<KazaDTO>>> GetAllKazaAsync(long Id);

        Task<IDataResult<KazaDTO>> AddAndGetAsync(KazaDTO addObject, long createdByUserId);


    }
}
