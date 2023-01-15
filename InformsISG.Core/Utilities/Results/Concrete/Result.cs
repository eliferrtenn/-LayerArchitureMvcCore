using InformsISG.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }

        public Result(ResultStatus resultStatus,string message)
        {
            ResultStatus = resultStatus;
            Message = message;
        }

        public Result(ResultStatus resultStatus, string message,Exception exception)
        {
            ResultStatus = resultStatus;
            Message = message;
            Exception = exception;
        }
        public string Message { get ; }

        public ResultStatus ResultStatus { get; }

        public Exception Exception { get; }
     
    }
}
