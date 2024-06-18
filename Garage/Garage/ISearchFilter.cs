using Garage.Types;

using System.Reflection;

namespace Garage.Garage
{
    internal interface ISearchFilter
    {
        ColorType? Color { get; set; }
        int? ExtraProp { get; set; }
        string? RegNumber { get; set; }
        int? Weels { get; set; }
        void ResetAll();
        PropertyInfo[] GetPublicInstanceProps();
    }
}