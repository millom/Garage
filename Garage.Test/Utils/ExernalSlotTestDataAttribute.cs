using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xunit.Sdk;

namespace Garage.Test.Utils
{
    public class ExernalSlotTestDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            string[] csvLines = File.ReadAllLines("TestData/SlotsTestData.csv");
            foreach (var csvLine in csvLines)
            {
                IEnumerable<int> values = csvLine
                    .Split(',')
                    .Select(n => int.Parse(n));
                yield return values.Cast<object>().ToArray();
            }
        }
    }
}
