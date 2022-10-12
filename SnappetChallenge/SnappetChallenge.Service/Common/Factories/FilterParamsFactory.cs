using SnappetChallenge.Service.Common.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.Service.Common.Factories
{
    public class FilterParamsFactory
    {
        public static IFilterParams CreateFilterParam()
        {
            return new FilterParams();
        }
    }
}