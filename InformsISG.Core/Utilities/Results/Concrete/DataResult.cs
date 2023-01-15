using InformsISG.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Core.Utilities.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {

        public DataResult(ResultStatus resultStatus,T data)
        {
            ResultStatus = resultStatus;
            Data = data;
        }

        public DataResult(ResultStatus resultStatus, string message, T data)
        {
            ResultStatus = resultStatus;
            Message = message;
            Data = data;
        }

        public DataResult(ResultStatus resultStatus, string message,T data, Exception exception)
        {
            ResultStatus = resultStatus;
            Message = message;
            Exception = exception;
            Data = data;
        }

        public T Data { get; }

        public string Message{ get; }

       public ResultStatus ResultStatus { get; }

       public Exception Exception { get; }
    }
}
