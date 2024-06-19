using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xunit.Sdk;

namespace Garage.Test.Utils
{
    public class BaseExernalTestDataAttribute : DataAttribute
    {
        public BaseExernalTestDataAttribute(string filename)
        {
            _filename = filename;
        }

        private readonly string _filename;

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            //string[] csvLines = File.ReadAllLines("TestData/SlotsTestData.csv");
            string[] csvLines = File.ReadAllLines(_filename);
            foreach (var csvLine in csvLines)
            {
                IEnumerable<string> values = csvLine
                    .Split(',');
                yield return values.Cast<object>().ToArray();
            }
        }
    }
}
