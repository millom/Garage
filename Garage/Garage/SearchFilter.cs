using Garage.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Garage.Garage
{
    internal class SearchFilter : ISearchFilter
    {
        public string? RegNumber { get; set; }
        public int? Color { get; set; }
        public int? Weels { get; set; }
        public int? ExtraProp { get; set; }

        public PropertyInfo[] GetPublicInstanceProps()
        {
            return GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
        }

        public override string ToString()
        {
            return
                $"RegNr:      {(RegNumber != null ? RegNumber : "---")}\n" +
                $"Color:      {(Color != null ? Color : "---")}\n" +
                $"Weels:      {(Weels != null ? Weels : "---")}\n" +
                $"ExtraProp:  {(ExtraProp != null ? ExtraProp : "---")}";
        }
    }
}
