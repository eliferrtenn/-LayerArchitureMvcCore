using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Core.Utilities.Results.Abstract
{
    public interface IResult
    {
        public string Message { get;}
        public ResultStatus ResultStatus { get;}
        public Exception Exception { get; }
    }
}
