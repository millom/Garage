using Garage.Types;

namespace Garage.Search
{
    /// <summary>
    /// An interface defining a SearchFiler class
    /// </summary>
    public interface ISearchFilter
    {
        IEnumerable<ISearchFilterItemLimitBase> Filters { get; }

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