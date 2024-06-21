namespace Garage.Search
{
    internal abstract class SearchFilterItemBase<T>(string name, T value)
        : ISearchFilterItemBase<T>
    {
        public string Name { get; } = name;

        public T Value { get; set; } = value;

        public abstract string GetLimitsString();
    }
}