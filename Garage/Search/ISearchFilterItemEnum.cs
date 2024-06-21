using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Search
{
    internal interface ISearchFilterItemEnum<T>
        : ISearchFilterItemBase<T> where T : struct, Enum
    {
    }
}
