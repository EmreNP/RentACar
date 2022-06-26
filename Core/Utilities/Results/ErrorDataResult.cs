using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<TData> : DataResult<TData>
    {
        public ErrorDataResult(string message,TData data):base(false,message,data)
        {

        }
        public ErrorDataResult(TData data) : base(false, data)
        {

        }
        public ErrorDataResult(string message) : base(false, message, default)
        {

        }
        public ErrorDataResult() : base(false, default)
        {

        }


    }
}
