namespace Garage.Search
{
    internal interface ISearchFilterItemString<T>
        : ISearchFilterItemBase<T> where T : IComparable, IConvertible, IEquatable<T>
    {
    }
}