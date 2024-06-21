namespace Garage.Search
{
    internal interface ISearchFilterItemBase<T>
        : ISearchFilterItemLimitBase
    {
        T Value { get; set; }
    }
}