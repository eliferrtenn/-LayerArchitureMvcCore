using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Core.Utilities.Results
{
    public enum ResultStatus
    {
        [Description("success")]
        Success=0,
        [Description("error")]
        Error =1,
        [Description("warning")]
        Warning =2,
        [Description("info")]
        Info =3
    }
}
