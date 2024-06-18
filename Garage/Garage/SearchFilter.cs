using Garage.Types;

using System.Reflection;

namespace Garage.Garage
{
    internal class SearchFilter : ISearchFilter
    {
        public string? RegNumber { get; set; }
        public ColorType? Color { get; set; }
        public int? Weels { get; set; }
        public int? ExtraProp { get; set; }

        public PropertyInfo[] GetPublicInstanceProps()
        {
            return GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
        }

        public void ResetAll()
        {
            RegNumber   = null;
            Color       = null;
            Weels       = null;
            ExtraProp   = null;
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
