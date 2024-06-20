using Garage.Types;

using System.Reflection;

namespace Garage.Search
{
    /// <summary>
    /// An interface defining a SearchFiler class
    /// </summary>
    public interface ISearchFilter
    {
        /// <summary>
        /// RegNumber property
        /// </summary>
        string? RegNumber { get; set; }

        /// <summary>
        /// Color property
        /// </summary>
        ColorType? Color { get; set; }

        /// <summary>
        /// Weels property
        /// </summary>
        int? Weels { get; set; }

        /// <summary>
        /// ExtraProp property
        /// </summary>
        int? ExtraProp { get; set; }

        /// <summary>
        /// Reset all properties
        /// </summary>
        void ResetAll();

        /// <summary>
        /// Need ToString in interface, remove warning
        /// </summary>
        /// <returns></returns>
        string ToString();
    }
}