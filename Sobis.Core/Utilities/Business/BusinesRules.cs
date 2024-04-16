using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sobis.Core.Utilities.Results.Abstract;

namespace Sobis.Core.Utilities.Business
{
    public class BusinesRules
    {
        public static IResult GetResult(params IResult[] results)
        {
            foreach (var result in results)
            {
                if (!result.IsSuccess)
                {
                    return result;
                }
            }
            return null;
        }
    }
}
