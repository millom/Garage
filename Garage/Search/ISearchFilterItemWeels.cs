namespace Garage.Search
{
    public interface ISearchFilterItemWeels<T>
        : ISearchFilterItemBase<int> where T : struct, IComparable<T>
    {
    }
}