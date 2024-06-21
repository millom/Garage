namespace Garage.Types
{
    /// <summary>
    /// Enum defining types of fuel
    /// </summary>
    public enum FuelType
    {
        /// <summary>
        /// No value, used for filtering
        /// Not a legal value for objects
        /// </summary>
        ANY             = 0,

        /// <summary>
        /// Electricity
        /// </summary>
        ELECTRICITY     = 1,

        /// <summary>
        /// Gasoline
        /// </summary>
        GASOLINE        = 2,

        /// <summary>
        /// Diesel
        /// </summary>
        DIESEL          = 3
    }
}