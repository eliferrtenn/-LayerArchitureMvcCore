using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IMakine_Ekipman_Bakim_PlanlariService
    {
        Task<IResult> AddAsync(Makine_Ekipman_Bakim_PlanlariDTO addObject, long createdByUserId);
        Task<IResult> UpdateAsync(Makine_Ekipman_Bakim_PlanlariDTO updateObject, long modifiedByUserId);
        Task<IResult> DeleteAsync(long Id, long deletedByUserId);
        Task<IResult> HardDeleteAsync(long Id);
        Task<IDataResult<Makine_Ekipman_Bakim_PlanlariDTO>> GetAsync(long Id);
        Task<IDataResult<IList<Makine_Ekipman_Bakim_PlanlariDTO>>> GetAllAsync();
        Task<IDataResult<IList<Makine_Ekipman_Bakim_PlanlariDTO>>> GetBeklemeAsync();
        Task<IDataResult<IList<Makine_Ekipman_Bakim_PlanlariDTO>>> GetEkipman(long Id);

        Task<IDataResult<Makine_Ekipman_Bakim_PlanlariDTO>> AddAndGetAsync(Makine_Ekipman_Bakim_PlanlariDTO addObject, long createdByUserId);

        Task<IDataResult<IList<Makine_Ekipman_Bakim_PlanlariDTO>>> GetAllTimeRedBirim();
        Task<IDataResult<IList<Makine_Ekipman_Bakim_PlanlariDTO>>> GetAllTimeRedIsgUzman();


        
    }
}
