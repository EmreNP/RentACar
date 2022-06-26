using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] Logics)
        {
            foreach(var logic in Logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;

        }
    }
}
