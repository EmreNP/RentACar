using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{   
    public class DataResult<TData> : Result,IDataResult<TData> 
    {
        public TData Data { get; }

        public DataResult(bool success, string message, TData data) : base(success, message)
        {
            Data = data;
        }
        public DataResult(bool success, TData data) : base(success)
        {
            Data = data;
        }
    }
}
