using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IYaralanma_SekliService
    {
        Task<IResult> AddAsync(Yaralanma_SekliDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Yaralanma_SekliDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Yaralanma_SekliDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Yaralanma_SekliDTO>>> GetAllAsync();
    }
}
