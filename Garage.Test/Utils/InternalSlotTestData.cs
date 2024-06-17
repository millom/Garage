using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Test.Utils
{
    public class InternalSlotTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { -1 };
                yield return new object[] { 20 };
            }
        }
    }
}
