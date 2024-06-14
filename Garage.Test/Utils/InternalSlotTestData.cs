using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Test.Utils
{
    public class InternalSlotTestData
    {
        private static readonly List<object[]> Data =
        [
            new object[] { 0 },
            new object[] { 4 },
            new object[] { 9 },
            new object[] { 14 },
            new object[] { 19 }
        ];

        public static IEnumerable<object[]> TestData => Data;
    }
}
