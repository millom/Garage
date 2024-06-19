using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xunit.Sdk;

namespace Garage.Test.Utils
{
    public class ExernalToStringTestDataAttribute
        : BaseExernalTestDataAttribute
    {
        public ExernalToStringTestDataAttribute()
            : base("TestData/ToStringTestData.csv") {}
    }
}
