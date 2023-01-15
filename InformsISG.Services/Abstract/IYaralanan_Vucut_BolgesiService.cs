using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IYaralanan_Vucut_BolgesiService
    {
        Task<IResult> AddAsync(Yaralanan_Vucut_BolgesiDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Yaralanan_Vucut_BolgesiDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Yaralanan_Vucut_BolgesiDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Yaralanan_Vucut_BolgesiDTO>>> GetAllAsync();
    }
}
