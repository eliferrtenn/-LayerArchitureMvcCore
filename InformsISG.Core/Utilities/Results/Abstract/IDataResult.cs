using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Core.Utilities.Results.Abstract
{
    //hem entitiy hem de entitiy listesi için =  out 
    public interface IDataResult<out T> : IResult
    {
        public T Data { get; }
    }
}
