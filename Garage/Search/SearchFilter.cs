using Garage.Types;

using System.Reflection;
using System.Runtime.CompilerServices;

namespace Garage.Search
{
    /// <summary>
    /// A class for storing searh filer parameters
    /// </summary>
    public class SearchFilter : ISearchFilter
    {
        /// <summary>
        /// RegNumber property
        /// </summary>
        public string? RegNumber { get; set; }

        /// <summary>
        /// Color property
        /// </summary>
        public ColorType? Color { get; set; }

        /// <summary>
        /// Weels property
        /// </summary>
        public int? Weels { get; set; }

        /// <summary>
        /// ExtraProp property
        /// </summary>
        public int? ExtraProp { get; set; }

        /// <summary>
        /// A default constructor, maybe not needed
        /// </summary>
        public SearchFilter(){}

        /// <summary>
        /// Reset all properties
        /// </summary>
        public void ResetAll()
        {
            RegNumber = null;
            Color = null;
            Weels = null;
            ExtraProp = null;
        }

        /// <summary>
        /// Need ToString in interface, remove warning
        /// </summary>
        /// <returns></returns>
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
