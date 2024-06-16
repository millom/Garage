using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xunit.Sdk;

namespace Garage.Test.Utils
{
    public class InternalSlotTestDataAttribute: DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { -1 };
            yield return new object[] { 20 };
        }
    }
}
