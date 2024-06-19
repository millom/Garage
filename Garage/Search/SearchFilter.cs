using Garage.Types;

using System.Reflection;
using System.Runtime.CompilerServices;

namespace Garage.Search
{
    public class SearchFilter : ISearchFilter
    {
        public string? RegNumber { get; set; }
        public ColorType? Color { get; set; }
        public int? Weels { get; set; }
        public int? ExtraProp { get; set; }

        public SearchFilter(){}

        public void ResetAll()
        {
            RegNumber = null;
            Color = null;
            Weels = null;
            ExtraProp = null;
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
