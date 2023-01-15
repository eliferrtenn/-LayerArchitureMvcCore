using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Services.Abstract
{
    public interface IRisk_YontemService
    {
        Task<IDataResult<IList<Risk_YontemDTO>>> GetAllAsync();
    }
}
