using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Test.Utils
{
    public class ExernalSlotTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
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
}
