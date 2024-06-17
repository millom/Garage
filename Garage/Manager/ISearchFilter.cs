using System.Reflection;

namespace Garage.Manager
{
    internal interface ISearchFilter
    {
        int? Color { get; set; }
        int? ExtraProp { get; set; }
        string? RegNumber { get; set; }
        int? Weels { get; set; }
        PropertyInfo[] GetPublicInstanceProps();
    }
}