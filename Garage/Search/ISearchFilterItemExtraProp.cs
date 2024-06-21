namespace Garage.Search
{
    internal interface ISearchFilterItemExtraProp<T>
        : ISearchFilterItemBase<T> where T : struct, IComparable<T>
    {
    }
}