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
                //var testCases = new List<object[]>();
                foreach (var csvLine in csvLines)
                {
                    IEnumerable<int> values = csvLine
                        .Split(',')
                        .Select(n => int.Parse(n));
                    //object[] testCase = 
                    yield return values.Cast<object>().ToArray();
                    //testCases.Add(testCase);
                }

                //yield return new object[] { 0 };
                //yield return new object[] { 4 };
                //yield return new object[] { 9 };
                //yield return new object[] { 14 };
                //yield return new object[] { 19 };
                //yield return new object[] { -1 };
                //yield return new object[] { 20 };
            }
        }
    }
}
