using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<TData> : DataResult<TData>
    {
        private IResult result;

        public SuccessDataResult(string message, TData data) : base(true, message, data)
        {

        }
        public SuccessDataResult(TData data) : base(true, data)
        {


        }
        public SuccessDataResult(string message) : base(true, message, default)
        {

        }
        public SuccessDataResult() : base(true, default)
        {

        }

    }
}
